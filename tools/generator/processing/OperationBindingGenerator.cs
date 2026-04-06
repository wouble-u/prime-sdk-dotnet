/*
 * Copyright 2026-present Coinbase Global, Inc.
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

using CoinbaseSdk.Tools.Generator.Spec;
using YamlDotNet.RepresentationModel;

namespace CoinbaseSdk.Tools.Generator.Processing;

public static class OperationBindingGenerator
{
  private const string OperationIdPrefix = "PrimeRESTAPI_";

  /// <summary>
  /// Manual SDK method names where prefix strip, acronym normalization, List-summary heuristic,
  /// and Web3 rename are not enough to match the public SDK surface.
  /// </summary>
  private static readonly Dictionary<string, string> ManualSdkMethodByOperationId = new(StringComparer.Ordinal)
  {
    ["PrimeRESTAPI_GetAllocationsByClientNettingId"] = "ListAllocationsByClientNettingId",
    ["PrimeRESTAPI_GetBuyingPower"] = "GetPortfolioBuyingPower",
    ["PrimeRESTAPI_GetEntityAssets"] = "ListAssets",
    ["PrimeRESTAPI_GetEntityUsers"] = "ListUsers",
    ["PrimeRESTAPI_GetFuturesSweeps"] = "ListEntityFuturesSweeps",
    ["PrimeRESTAPI_GetLocateAvailabilities"] = "GetEntityLocateAvailabilities",
    ["PrimeRESTAPI_GetMarginSummaries"] = "ListMarginCallSummaries",
    ["PrimeRESTAPI_GetOrders"] = "ListPortfolioOrders",
    ["PrimeRESTAPI_GetPortfolioActivities"] = "ListActivities",
    ["PrimeRESTAPI_GetPortfolioAddressBook"] = "ListAddressBookEntries",
    ["PrimeRESTAPI_GetPortfolioInterestAccruals"] = "ListInterestAccrualsForPortfolio",
    ["PrimeRESTAPI_GetPortfolioCounterpartyID"] = "GetPortfolioCounterparty",
    ["PrimeRESTAPI_GetPostTradeCredit"] = "GetPortfolioCreditInformation",
    ["PrimeRESTAPI_GetTFTieredPricingFees"] = "GetTradeFinanceTieredPricingFees",
    ["PrimeRESTAPI_GetWithdrawalPower"] = "GetPortfolioWithdrawalPower",
    ["PrimeRESTAPI_CancelFuturesSweep"] = "CancelEntityFuturesSweep",
    ["PrimeRESTAPI_ScheduleFuturesSweep"] = "ScheduleEntityFuturesSweep",
    ["PrimeRESTAPI_CreatePortfolioAddressBookEntry"] = "CreateAddressBookEntry",
    ["PrimeRESTAPI_CreateOnchainAddressGroup"] = "CreateOnchainAddressBookEntry",
    ["PrimeRESTAPI_UpdateOnchainAddressGroup"] = "UpdateOnchainAddressBookEntry",
    ["PrimeRESTAPI_CreateQuoteRequest"] = "CreateQuote",
    ["PrimeRESTAPI_CreateWalletTransfer"] = "CreateTransfer",
    ["PrimeRESTAPI_CreateWalletWithdrawal"] = "CreateWithdrawal",
    ["PrimeRESTAPI_ListTFObligations"] = "ListTradeFinanceObligations",
    ["PrimeRESTAPI_OrderPreview"] = "GetOrderPreview",
    ["PrimeRESTAPI_PortfolioStakingInitiate"] = "CreatePortfolioStake",
    ["PrimeRESTAPI_PortfolioStakingUnstake"] = "CreatePortfolioUnstake",
    ["PrimeRESTAPI_StakingClaimRewards"] = "ClaimStakingRewards",
    ["PrimeRESTAPI_StakingInitiate"] = "CreateStake",
    ["PrimeRESTAPI_StakingUnstake"] = "CreateUnstake",
    ["PrimeRESTAPI_GetEntityPaymentMethodDetails"] = "GetEntityPaymentMethod"
  };

  public static List<SdkOperationBinding> DeriveAll(
    ParsedOpenApiDocument doc,
    GeneratorConfiguration cfg,
    SharedTransforms transforms)
  {
    var list = new List<SdkOperationBinding>();
    foreach (var op in doc.OperationsById.Values.OrderBy(o => o.OperationId, StringComparer.Ordinal))
    {
      list.Add(DeriveOne(doc.Root, cfg, transforms, op));
    }

    return list;
  }

  private static SdkOperationBinding DeriveOne(
    YamlMappingNode root,
    GeneratorConfiguration cfg,
    SharedTransforms transforms,
    ParsedOperation op)
  {
    var sdkMethod = DeriveSdkMethod(op, transforms);
    var service = ResolveServiceKey(cfg, op);
    var omitRequest = DeriveOmitRequest(op);
    var paramOverrides = DeriveParamTypeOverrides(root, transforms, op);
    // Response-shape pagination hints are not used here: some POST bodies embed cursor/limit
    // in JSON; forcing PaginatedRequest would duplicate those properties. Use
    // operations-overrides.json for the rare GET cases (e.g. ListPortfolioBalances).
    var forcePaginated = false;

    return new SdkOperationBinding
    {
      OperationId = op.OperationId,
      SdkMethod = sdkMethod,
      Service = service,
      OmitRequest = omitRequest,
      ForcePaginated = forcePaginated,
      ParamTypeOverrides = paramOverrides
    };
  }

  private static string DeriveSdkMethod(ParsedOperation op, SharedTransforms transforms)
  {
    if (ManualSdkMethodByOperationId.TryGetValue(op.OperationId, out var manual))
    {
      return manual;
    }

    var name = op.OperationId;
    if (name.StartsWith(OperationIdPrefix, StringComparison.Ordinal))
    {
      name = name[OperationIdPrefix.Length..];
    }

    name = transforms.NormalizeAcronyms(name);
    name = transforms.ApplyWeb3ToOnchainName(name);

    if (op.HttpMethod == "GET" &&
        !string.IsNullOrEmpty(op.Summary) &&
        op.Summary.StartsWith("List ", StringComparison.Ordinal) &&
        name.StartsWith("Get", StringComparison.Ordinal))
    {
      name = string.Concat("List", name.AsSpan(3));
    }

    return name;
  }

  private static string ResolveServiceKey(GeneratorConfiguration cfg, ParsedOperation op)
  {
    if (string.Equals(op.OperationId, "PrimeRESTAPI_ListAdvancedTransferTransactions", StringComparison.Ordinal))
    {
      return "advancedtransfer";
    }

    foreach (var tag in op.Tags)
    {
      if (cfg.TagToFolder.TryGetValue(tag, out var folder) &&
          cfg.Services.ContainsKey(folder))
      {
        return folder;
      }
    }

    throw new InvalidOperationException(
      $"Operation '{op.OperationId}' has no tag mapped in generator-config.json tagToFolder " +
      $"(tags: {string.Join(", ", op.Tags.Select(t => "'" + t + "'"))}).");
  }

  private static bool DeriveOmitRequest(ParsedOperation op)
  {
    return op.Parameters.Count == 0 && op.RequestBodyJsonSchema == null;
  }

  /// <summary>
  /// Derives query-parameter CLR overrides. Inline string enums stay <c>string?</c> in
  /// <see cref="OpenApiSchemaCodegen"/>; explicit enum typing is supplied via
  /// <c>operations-overrides.json</c> where the SDK surface requires it.
  /// </summary>
  private static Dictionary<string, string> DeriveParamTypeOverrides(
    YamlMappingNode root,
    SharedTransforms transforms,
    ParsedOperation op)
  {
    var result = new Dictionary<string, string>(StringComparer.Ordinal);
    foreach (var p in op.Parameters.Where(x => x.In == "query"))
    {
      if (p.Name == "symbols" &&
          p.Schema.Children.ContainsKey(new YamlScalarNode("type")) &&
          p.Schema.Children[new YamlScalarNode("type")] is YamlScalarNode tn &&
          tn.Value == "string")
      {
        var symbolsDefaultClr = OpenApiSchemaCodegen.ToClrType(root, p.Schema, transforms, out _, out _);
        if (symbolsDefaultClr != "string[]")
        {
          result["symbols"] = "string[]";
        }
      }
    }

    return result;
  }
}
