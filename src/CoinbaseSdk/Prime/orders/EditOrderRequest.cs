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

  public class EditOrderRequest(string portfolioId, string orderId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;
    [JsonIgnore]
    public string OrderId { get; set; } = orderId;
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }
    [JsonPropertyName("orig_client_order_id")]
    public string? OrigClientOrderId { get; set; }
    [JsonPropertyName("client_order_id")]
    public string? ClientOrderId { get; set; }
    [JsonPropertyName("base_quantity")]
    public string? BaseQuantity { get; set; }
    [JsonPropertyName("quote_value")]
    public string? QuoteValue { get; set; }
    [JsonPropertyName("limit_price")]
    public string? LimitPrice { get; set; }
    [JsonPropertyName("expiry_time")]
    public string? ExpiryTime { get; set; }
    [JsonPropertyName("display_quote_size")]
    public string? DisplayQuoteSize { get; set; }
    [JsonPropertyName("display_base_size")]
    public string? DisplayBaseSize { get; set; }
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

      public Builder WithPortfolioId(string value)
      {
        _portfolioId = value;
        return this;
      }

      public Builder WithOrderId(string value)
      {
        _orderId = value;
        return this;
      }

      public Builder WithProductId(string? value)
      {
        _productId = value;
        return this;
      }

      public Builder WithOrigClientOrderId(string? value)
      {
        _origClientOrderId = value;
        return this;
      }

      public Builder WithClientOrderId(string? value)
      {
        _clientOrderId = value;
        return this;
      }

      public Builder WithBaseQuantity(string? value)
      {
        _baseQuantity = value;
        return this;
      }

      public Builder WithQuoteValue(string? value)
      {
        _quoteValue = value;
        return this;
      }

      public Builder WithLimitPrice(string? value)
      {
        _limitPrice = value;
        return this;
      }

      public Builder WithExpiryTime(string? value)
      {
        _expiryTime = value;
        return this;
      }

      public Builder WithDisplayQuoteSize(string? value)
      {
        _displayQuoteSize = value;
        return this;
      }

      public Builder WithDisplayBaseSize(string? value)
      {
        _displayBaseSize = value;
        return this;
      }

      public Builder WithStopPrice(string? value)
      {
        _stopPrice = value;
        return this;
      }

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

      public EditOrderRequest Build()
      {
        Validate();
        var request = new EditOrderRequest(_portfolioId!, _orderId!)
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
        return request;
      }
    }
  }
}
