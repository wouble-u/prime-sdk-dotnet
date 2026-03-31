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

  /// <summary>
  /// List Portfolio Orders
  /// List historical orders for a given portfolio. This endpoint returns a payload with a default limit of 100 if not specified by the user. The maximum allowed limit is 3000. &lt;br /&gt;&lt;br /&gt;**Caution:** Currently, you cannot query open orders with this endpoint: use List Open Orders if you have less than 1000 open orders, otherwise use Websocket API, or FIX API to stream open orders.
  /// </summary>
  public class ListPortfolioOrdersRequest(string portfolioId) : PaginatedRequest
  {
    /// <summary>
    /// Portfolio ID
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// List of statuses by which to filter the response
    /// - UNKNOWN_ORDER_STATUS: nil value
    /// - OPEN: The order is open but unfilled
    /// - FILLED: The order was filled
    /// - CANCELLED: The order was cancelled
    /// - EXPIRED: The order has expired
    /// - FAILED: Order submission failed
    /// - PENDING: The order has been sent but is not yet confirmed
    /// </summary>
    [JsonPropertyName("order_statuses")]
    public string?[] OrderStatuses { get; set; } = [];

    /// <summary>
    /// List of products by which to filter the response
    /// </summary>
    [JsonPropertyName("product_ids")]
    public string?[] ProductIds { get; set; } = [];

    /// <summary>
    /// Order type by which to filter the response
    /// - UNKNOWN_ORDER_TYPE: nil value
    /// - MARKET: A [market order](https://en.wikipedia.org/wiki/Order_(exchange)#Market_order)
    /// - LIMIT: A [limit order](https://en.wikipedia.org/wiki/Order_(exchange)#Limit_order)
    /// - TWAP: A [time-weighted average price order](https://en.wikipedia.org/wiki/Time-weighted_average_price)
    /// - BLOCK: A [block trade](https://en.wikipedia.org/wiki/Block_trade)
    /// - VWAP: A [volume-weighted average price order](https://en.wikipedia.org/wiki/Volume-weighted_average_price)
    /// - STOP_LIMIT: A [conditional order combined of stop order and limit order](https://en.wikipedia.org/wiki/Order_(exchange)#Stop-limit_order)
    /// - RFQ: A [request for quote](https://en.wikipedia.org/wiki/Request_for_quote)
    /// - PEG: A pegged order that dynamically adjust based on market conditions while maintaining execution discretion and avoiding adverse selection
    /// </summary>
    [JsonPropertyName("order_type")]
    public string? OrderType { get; set; }

    /// <summary>
    /// An order side to filter on.
    /// - UNKNOWN_ORDER_SIDE: nil value
    /// - BUY: Buy order
    /// - SELL: Sell order
    /// </summary>
    [JsonPropertyName("order_side")]
    public string? OrderSide { get; set; }

    /// <summary>
    /// A start date for the orders to be queried from
    /// </summary>
    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    /// <summary>
    /// An end date for the orders to be queried from
    /// </summary>
    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    public class Builder
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

      /// <summary>
      /// Portfolio ID
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// List of statuses by which to filter the response
      /// - UNKNOWN_ORDER_STATUS: nil value
      /// - OPEN: The order is open but unfilled
      /// - FILLED: The order was filled
      /// - CANCELLED: The order was cancelled
      /// - EXPIRED: The order has expired
      /// - FAILED: Order submission failed
      /// - PENDING: The order has been sent but is not yet confirmed
      /// </summary>
      public Builder WithOrderStatuses(string?[] orderStatuses)
      {
        _orderStatuses = orderStatuses;
        return this;
      }

      /// <summary>
      /// List of products by which to filter the response
      /// </summary>
      public Builder WithProductIds(string?[] productIds)
      {
        _productIds = productIds;
        return this;
      }

      /// <summary>
      /// Order type by which to filter the response
      /// - UNKNOWN_ORDER_TYPE: nil value
      /// - MARKET: A [market order](https://en.wikipedia.org/wiki/Order_(exchange)#Market_order)
      /// - LIMIT: A [limit order](https://en.wikipedia.org/wiki/Order_(exchange)#Limit_order)
      /// - TWAP: A [time-weighted average price order](https://en.wikipedia.org/wiki/Time-weighted_average_price)
      /// - BLOCK: A [block trade](https://en.wikipedia.org/wiki/Block_trade)
      /// - VWAP: A [volume-weighted average price order](https://en.wikipedia.org/wiki/Volume-weighted_average_price)
      /// - STOP_LIMIT: A [conditional order combined of stop order and limit order](https://en.wikipedia.org/wiki/Order_(exchange)#Stop-limit_order)
      /// - RFQ: A [request for quote](https://en.wikipedia.org/wiki/Request_for_quote)
      /// - PEG: A pegged order that dynamically adjust based on market conditions while maintaining execution discretion and avoiding adverse selection
      /// </summary>
      public Builder WithOrderType(string? orderType)
      {
        _orderType = orderType;
        return this;
      }

      /// <summary>
      /// An order side to filter on.
      /// - UNKNOWN_ORDER_SIDE: nil value
      /// - BUY: Buy order
      /// - SELL: Sell order
      /// </summary>
      public Builder WithOrderSide(string? orderSide)
      {
        _orderSide = orderSide;
        return this;
      }

      /// <summary>
      /// A start date for the orders to be queried from
      /// </summary>
      public Builder WithStartDate(string? startDate)
      {
        _startDate = startDate;
        return this;
      }

      /// <summary>
      /// An end date for the orders to be queried from
      /// </summary>
      public Builder WithEndDate(string? endDate)
      {
        _endDate = endDate;
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
      /// Builds a new <see cref="ListPortfolioOrdersRequest"/>.
      /// </summary>
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
