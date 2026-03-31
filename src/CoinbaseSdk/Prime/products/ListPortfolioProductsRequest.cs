/*
 * Copyright 2024-present Coinbase Global, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace CoinbaseSdk.Prime.Products
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Common;
  using CoinbaseSdk.Prime.Model.Enums;

  public class ListPortfolioProductsRequest(string portfolioId) : PaginatedRequest
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;
    [JsonPropertyName("product_type")]
    public string? ProductType { get; set; }
    [JsonPropertyName("contract_expiry_type")]
    public string? ContractExpiryType { get; set; }
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

      public Builder WithPortfolioId(string value)
      {
        _portfolioId = value;
        return this;
      }

      public Builder WithProductType(string? value)
      {
        _productType = value;
        return this;
      }

      public Builder WithContractExpiryType(string? value)
      {
        _contractExpiryType = value;
        return this;
      }

      public Builder WithExpiringContractStatus(string? value)
      {
        _expiringContractStatus = value;
        return this;
      }

      public Builder WithCursor(string cursor)
      { _cursor = cursor; return this; }

      public Builder WithSortDirection(SortDirection sortDirection)
      { _sortDirection = sortDirection; return this; }

      public Builder WithLimit(int limit)
      { _limit = limit; return this; }

      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
      }

      public ListPortfolioProductsRequest Build()
      {
        Validate();
        var request = new ListPortfolioProductsRequest(_portfolioId!)
        {
          ProductType = _productType,
          ContractExpiryType = _contractExpiryType,
          ExpiringContractStatus = _expiringContractStatus,
          Cursor = _cursor,
          SortDirection = _sortDirection,
          Limit = _limit,
        };
        return request;
      }
    }
  }
}
