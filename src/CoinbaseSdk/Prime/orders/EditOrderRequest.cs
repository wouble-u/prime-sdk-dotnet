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

namespace CoinbaseSdk.Prime.Orders
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;

  /// <summary>
  /// Edit Order (Beta)
  /// Edit an open order. This feature is in beta please reach out to your Coinbase Prime account manager for more information.
  /// </summary>
  public class EditOrderRequest(string portfolioId, string orderId)
  {
    /// <summary>
    /// The ID of the portfolio that owns the order
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// The ID of the order being edited
    /// </summary>
    [JsonIgnore]
    public string OrderId { get; set; } = orderId;

    /// <summary>
    /// Deprecated: The product ID of the order being edited
    /// </summary>
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    /// <summary>
    /// The client order ID of the order being edited
    /// </summary>
    [JsonPropertyName("orig_client_order_id")]
    public string? OrigClientOrderId { get; set; }

    /// <summary>
    /// The updated version of the client order ID
    /// </summary>
    [JsonPropertyName("client_order_id")]
    public string? ClientOrderId { get; set; }

    /// <summary>
    /// Order size in base asset units (either `base_quantity` or `quote_value` is required)
    /// </summary>
    [JsonPropertyName("base_quantity")]
    public string? BaseQuantity { get; set; }

    /// <summary>
    /// Order size in quote asset units, i.e. the amount the user wants to spend (when buying) or receive (when selling); the quantity in base units will be determined based on the market liquidity and indicated `quote_value` (either `base_quantity` or `quote_value` is required)
    /// </summary>
    [JsonPropertyName("quote_value")]
    public string? QuoteValue { get; set; }

    /// <summary>
    /// The limit price (required for TWAP, VWAP, LIMIT, and STOP_LIMIT orders)
    /// </summary>
    [JsonPropertyName("limit_price")]
    public string? LimitPrice { get; set; }

    /// <summary>
    /// The expiry time of the order in UTC (TWAP, VWAP, LIMIT, and STOP_LIMIT GTD only)
    /// </summary>
    [JsonPropertyName("expiry_time")]
    public string? ExpiryTime { get; set; }

    /// <summary>
    /// The maximum order size that will show up on venue order books. Specifying a value here effectively makes a LIMIT order into an "iceberg" style order.
    /// </summary>
    [JsonPropertyName("display_quote_size")]
    public string? DisplayQuoteSize { get; set; }

    /// <summary>
    /// The maximum order size that will show up on venue order books. Specifying a value here effectively makes a LIMIT order into an "iceberg" style order.
    /// </summary>
    [JsonPropertyName("display_base_size")]
    public string? DisplayBaseSize { get; set; }

    /// <summary>
    /// Specifies the stop price at which the order activates. The order is activated if the last trade price on Coinbase Exchange crosses the stop price specified on the order
    /// </summary>
    [JsonPropertyName("stop_price")]
    public string? StopPrice { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _orderId;
      private string? _productId;
      private string? _origClientOrderId;
      private string? _clientOrderId;
      private string? _baseQuantity;
      private string? _quoteValue;
      private string? _limitPrice;
      private string? _expiryTime;
      private string? _displayQuoteSize;
      private string? _displayBaseSize;
      private string? _stopPrice;

      /// <summary>
      /// The ID of the portfolio that owns the order
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// The ID of the order being edited
      /// </summary>
      public Builder WithOrderId(string orderId)
      {
        _orderId = orderId;
        return this;
      }

      /// <summary>
      /// Deprecated: The product ID of the order being edited
      /// </summary>
      public Builder WithProductId(string? productId)
      {
        _productId = productId;
        return this;
      }

      /// <summary>
      /// The client order ID of the order being edited
      /// </summary>
      public Builder WithOrigClientOrderId(string? origClientOrderId)
      {
        _origClientOrderId = origClientOrderId;
        return this;
      }

      /// <summary>
      /// The updated version of the client order ID
      /// </summary>
      public Builder WithClientOrderId(string? clientOrderId)
      {
        _clientOrderId = clientOrderId;
        return this;
      }

      /// <summary>
      /// Order size in base asset units (either `base_quantity` or `quote_value` is required)
      /// </summary>
      public Builder WithBaseQuantity(string? baseQuantity)
      {
        _baseQuantity = baseQuantity;
        return this;
      }

      /// <summary>
      /// Order size in quote asset units, i.e. the amount the user wants to spend (when buying) or receive (when selling); the quantity in base units will be determined based on the market liquidity and indicated `quote_value` (either `base_quantity` or `quote_value` is required)
      /// </summary>
      public Builder WithQuoteValue(string? quoteValue)
      {
        _quoteValue = quoteValue;
        return this;
      }

      /// <summary>
      /// The limit price (required for TWAP, VWAP, LIMIT, and STOP_LIMIT orders)
      /// </summary>
      public Builder WithLimitPrice(string? limitPrice)
      {
        _limitPrice = limitPrice;
        return this;
      }

      /// <summary>
      /// The expiry time of the order in UTC (TWAP, VWAP, LIMIT, and STOP_LIMIT GTD only)
      /// </summary>
      public Builder WithExpiryTime(string? expiryTime)
      {
        _expiryTime = expiryTime;
        return this;
      }

      /// <summary>
      /// The maximum order size that will show up on venue order books. Specifying a value here effectively makes a LIMIT order into an "iceberg" style order.
      /// </summary>
      public Builder WithDisplayQuoteSize(string? displayQuoteSize)
      {
        _displayQuoteSize = displayQuoteSize;
        return this;
      }

      /// <summary>
      /// The maximum order size that will show up on venue order books. Specifying a value here effectively makes a LIMIT order into an "iceberg" style order.
      /// </summary>
      public Builder WithDisplayBaseSize(string? displayBaseSize)
      {
        _displayBaseSize = displayBaseSize;
        return this;
      }

      /// <summary>
      /// Specifies the stop price at which the order activates. The order is activated if the last trade price on Coinbase Exchange crosses the stop price specified on the order
      /// </summary>
      public Builder WithStopPrice(string? stopPrice)
      {
        _stopPrice = stopPrice;
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
        if (string.IsNullOrWhiteSpace(_orderId))
        {
          throw new CoinbaseClientException("OrderId is required");
        }
      }

      /// <summary>
      /// Builds a new <see cref="EditOrderRequest"/>.
      /// </summary>
      public EditOrderRequest Build()
      {
        Validate();
        return new EditOrderRequest(_portfolioId!, _orderId!)
        {
          ProductId = _productId,
          OrigClientOrderId = _origClientOrderId,
          ClientOrderId = _clientOrderId,
          BaseQuantity = _baseQuantity,
          QuoteValue = _quoteValue,
          LimitPrice = _limitPrice,
          ExpiryTime = _expiryTime,
          DisplayQuoteSize = _displayQuoteSize,
          DisplayBaseSize = _displayBaseSize,
          StopPrice = _stopPrice,
        };
      }
    }
  }
}
