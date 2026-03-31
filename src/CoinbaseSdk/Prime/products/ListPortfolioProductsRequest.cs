/*
 * Copyright 2024-present Coinbase Global, Inc.
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

namespace CoinbaseSdk.Prime.Products
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Common;
  using CoinbaseSdk.Prime.Model.Enums;

  /// <summary>
  /// List Portfolio Products
  /// List tradable products for a given portfolio.
  /// </summary>
  public class ListPortfolioProductsRequest(string portfolioId) : PaginatedRequest
  {
    /// <summary>
    /// The portfolio ID
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// Filter by product type (SPOT, FUTURE). If unset, returns all types available for your portfolio. Futures products require additional entitlements.
    /// - UNKNOWN_PRODUCT_TYPE: Unknown product type
    /// - SPOT: Spot product
    /// - FUTURE: Future product
    /// </summary>
    [JsonPropertyName("product_type")]
    public string? ProductType { get; set; }

    /// <summary>
    /// Filter by contract expiry type (EXPIRING or PERPETUAL). Only applicable when product_type = FUTURE. If unset, returns all futures kinds.
    /// - CONTRACT_EXPIRY_TYPE_UNSPECIFIED: Unspecified contract expiry type
    /// - CONTRACT_EXPIRY_TYPE_EXPIRING: Expiring futures contract
    /// - CONTRACT_EXPIRY_TYPE_PERPETUAL: Perpetual futures contract (no expiry)
    /// </summary>
    [JsonPropertyName("contract_expiry_type")]
    public string? ContractExpiryType { get; set; }

    /// <summary>
    /// Filter by expiry status for expiring futures. If unset, returns all expiring futures.
    /// - EXPIRING_CONTRACT_STATUS_UNKNOWN: Unknown/unset — returns all expiring contracts (backward compatible default)
    /// - EXPIRING_CONTRACT_STATUS_UNEXPIRED: Only unexpired contracts (contract_expiry is in the future)
    /// - EXPIRING_CONTRACT_STATUS_EXPIRED: Only expired contracts (contract_expiry is in the past)
    /// - EXPIRING_CONTRACT_STATUS_ALL: All contracts regardless of expiry status
    /// </summary>
    [JsonPropertyName("expiring_contract_status")]
    public string? ExpiringContractStatus { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _productType;
      private string? _contractExpiryType;
      private string? _expiringContractStatus;
      private string? _cursor;
      private SortDirection? _sortDirection;
      private int? _limit;

      /// <summary>
      /// The portfolio ID
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// Filter by product type (SPOT, FUTURE). If unset, returns all types available for your portfolio. Futures products require additional entitlements.
      /// - UNKNOWN_PRODUCT_TYPE: Unknown product type
      /// - SPOT: Spot product
      /// - FUTURE: Future product
      /// </summary>
      public Builder WithProductType(string? productType)
      {
        _productType = productType;
        return this;
      }

      /// <summary>
      /// Filter by contract expiry type (EXPIRING or PERPETUAL). Only applicable when product_type = FUTURE. If unset, returns all futures kinds.
      /// - CONTRACT_EXPIRY_TYPE_UNSPECIFIED: Unspecified contract expiry type
      /// - CONTRACT_EXPIRY_TYPE_EXPIRING: Expiring futures contract
      /// - CONTRACT_EXPIRY_TYPE_PERPETUAL: Perpetual futures contract (no expiry)
      /// </summary>
      public Builder WithContractExpiryType(string? contractExpiryType)
      {
        _contractExpiryType = contractExpiryType;
        return this;
      }

      /// <summary>
      /// Filter by expiry status for expiring futures. If unset, returns all expiring futures.
      /// - EXPIRING_CONTRACT_STATUS_UNKNOWN: Unknown/unset — returns all expiring contracts (backward compatible default)
      /// - EXPIRING_CONTRACT_STATUS_UNEXPIRED: Only unexpired contracts (contract_expiry is in the future)
      /// - EXPIRING_CONTRACT_STATUS_EXPIRED: Only expired contracts (contract_expiry is in the past)
      /// - EXPIRING_CONTRACT_STATUS_ALL: All contracts regardless of expiry status
      /// </summary>
      public Builder WithExpiringContractStatus(string? expiringContractStatus)
      {
        _expiringContractStatus = expiringContractStatus;
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
      }

      /// <summary>
      /// Builds a new <see cref="ListPortfolioProductsRequest"/>.
      /// </summary>
      public ListPortfolioProductsRequest Build()
      {
        Validate();
        return new ListPortfolioProductsRequest(_portfolioId!)
        {
          ProductType = _productType,
          ContractExpiryType = _contractExpiryType,
          ExpiringContractStatus = _expiringContractStatus,
          Cursor = _cursor,
          SortDirection = _sortDirection,
          Limit = _limit,
        };
      }
    }
  }
}
