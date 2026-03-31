/*
 * Copyright 2025-present Coinbase Global, Inc.
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

namespace CoinbaseSdk.Prime.Balances
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Common;
  using CoinbaseSdk.Prime.Model.Enums;

  /// <summary>
  /// List Onchain Wallet Balances
  /// Query balances for a specific onchain wallet.
  /// </summary>
  public class ListOnchainWalletBalancesRequest(string portfolioId, string walletId) : PaginatedRequest
  {
    /// <summary>
    /// Portfolio to retrieve balances for.
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// Onchain wallet to retrieve balances for.
    /// </summary>
    [JsonIgnore]
    public string WalletId { get; set; } = walletId;

    /// <summary>
    /// Visibility statuses to filter balances on. Leaving this field empty will return only VISIBLE balances.
    /// - UNKNOWN_VISIBILITY_STATUS: nil
    /// - VISIBLE: Visible
    /// - HIDDEN: Hidden
    /// - SPAM: Spam
    /// </summary>
    [JsonPropertyName("visibility_statuses")]
    public string?[] VisibilityStatuses { get; set; } = [];

    public class Builder
    {
      private string? _portfolioId;
      private string? _walletId;
      private string?[]? _visibilityStatuses;
      private string? _cursor;
      private SortDirection? _sortDirection;
      private int? _limit;

      /// <summary>
      /// Portfolio to retrieve balances for.
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// Onchain wallet to retrieve balances for.
      /// </summary>
      public Builder WithWalletId(string walletId)
      {
        _walletId = walletId;
        return this;
      }

      /// <summary>
      /// Visibility statuses to filter balances on. Leaving this field empty will return only VISIBLE balances.
      /// - UNKNOWN_VISIBILITY_STATUS: nil
      /// - VISIBLE: Visible
      /// - HIDDEN: Hidden
      /// - SPAM: Spam
      /// </summary>
      public Builder WithVisibilityStatuses(string?[] visibilityStatuses)
      {
        _visibilityStatuses = visibilityStatuses;
        return this;
      }

      public Builder WithCursor(string cursor)
      {
        _cursor = cursor;
        return this;
      }

      public Builder WithSortDirection(SortDirection sortDirection)
      {
        _sortDirection = sortDirection;
        return this;
      }

      public Builder WithLimit(int limit)
      {
        _limit = limit;
        return this;
      }

      /// <summary>
      /// Validates required path parameters before building the request.
      /// </summary>
      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
        if (string.IsNullOrWhiteSpace(_walletId))
        {
          throw new CoinbaseClientException("WalletId is required");
        }
      }

      /// <summary>
      /// Builds a new <see cref="ListOnchainWalletBalancesRequest"/>.
      /// </summary>
      public ListOnchainWalletBalancesRequest Build()
      {
        Validate();
        return new ListOnchainWalletBalancesRequest(_portfolioId!, _walletId!)
        {
          VisibilityStatuses = _visibilityStatuses,
          Cursor = _cursor,
          SortDirection = _sortDirection,
          Limit = _limit,
        };
      }
    }
  }
}
