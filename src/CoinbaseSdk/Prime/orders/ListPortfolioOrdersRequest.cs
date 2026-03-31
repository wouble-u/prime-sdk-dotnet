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

namespace CoinbaseSdk.Prime.Orders
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Common;
  using CoinbaseSdk.Prime.Model.Enums;

  public class ListPortfolioOrdersRequest(string portfolioId) : PaginatedRequest
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    [JsonPropertyName("order_statuses")]
    public string?[] OrderStatuses { get; set; } = [];

    [JsonPropertyName("product_ids")]
    public string?[] ProductIds { get; set; } = [];

    [JsonPropertyName("order_type")]
    public string? OrderType { get; set; }

    [JsonPropertyName("order_side")]
    public string? OrderSide { get; set; }

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    public class ListPortfolioOrdersRequestBuilder
    {
      private string? _portfolioId;
      private string?[]? _orderStatuses;
      private string?[]? _productIds;
      private string? _orderType;
      private string? _orderSide;
      private string? _startDate;
      private string? _endDate;
      private string? _cursor;
      private SortDirection? _sortDirection;
      private int? _limit;

      public ListPortfolioOrdersRequestBuilder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      public ListPortfolioOrdersRequestBuilder WithOrderStatuses(string?[] orderStatuses)
      {
        _orderStatuses = orderStatuses;
        return this;
      }

      public ListPortfolioOrdersRequestBuilder WithProductIds(string?[] productIds)
      {
        _productIds = productIds;
        return this;
      }

      public ListPortfolioOrdersRequestBuilder WithOrderType(string? orderType)
      {
        _orderType = orderType;
        return this;
      }

      public ListPortfolioOrdersRequestBuilder WithOrderSide(string? orderSide)
      {
        _orderSide = orderSide;
        return this;
      }

      public ListPortfolioOrdersRequestBuilder WithStartDate(string? startDate)
      {
        _startDate = startDate;
        return this;
      }

      public ListPortfolioOrdersRequestBuilder WithEndDate(string? endDate)
      {
        _endDate = endDate;
        return this;
      }

      public ListPortfolioOrdersRequestBuilder WithCursor(string cursor)
      {
        _cursor = cursor;
        return this;
      }

      public ListPortfolioOrdersRequestBuilder WithSortDirection(SortDirection sortDirection)
      {
        _sortDirection = sortDirection;
        return this;
      }

      public ListPortfolioOrdersRequestBuilder WithLimit(int limit)
      {
        _limit = limit;
        return this;
      }

      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
      }

      public ListPortfolioOrdersRequest Build()
      {
        Validate();
        return new ListPortfolioOrdersRequest(_portfolioId!)
        {
          OrderStatuses = _orderStatuses,
          ProductIds = _productIds,
          OrderType = _orderType,
          OrderSide = _orderSide,
          StartDate = _startDate,
          EndDate = _endDate,
          Cursor = _cursor,
          SortDirection = _sortDirection,
          Limit = _limit,
        };
      }
    }
  }
}
