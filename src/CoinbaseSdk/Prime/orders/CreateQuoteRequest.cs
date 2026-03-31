/*
 * Copyright 2025-present Coinbase Global, Inc.
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

namespace CoinbaseSdk.Prime.Orders
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Model.Enums;

  public class CreateQuoteRequest(string portfolioId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }
    [JsonPropertyName("side")]
    public OrderSide Side { get; set; }
    [JsonPropertyName("client_quote_id")]
    public string? ClientQuoteId { get; set; }
    [JsonPropertyName("base_quantity")]
    public string? BaseQuantity { get; set; }
    [JsonPropertyName("quote_value")]
    public string? QuoteValue { get; set; }
    [JsonPropertyName("limit_price")]
    public string? LimitPrice { get; set; }
    [JsonPropertyName("settl_currency")]
    public string? SettlCurrency { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _productId;
      private OrderSide _side;
      private string? _clientQuoteId;
      private string? _baseQuantity;
      private string? _quoteValue;
      private string? _limitPrice;
      private string? _settlCurrency;

      public Builder WithPortfolioId(string value)
      {
        _portfolioId = value;
        return this;
      }

      public Builder WithProductId(string? value)
      {
        _productId = value;
        return this;
      }

      public Builder WithSide(OrderSide value)
      {
        _side = value;
        return this;
      }

      public Builder WithClientQuoteId(string? value)
      {
        _clientQuoteId = value;
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

      public Builder WithSettlCurrency(string? value)
      {
        _settlCurrency = value;
        return this;
      }

      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
      }

      public CreateQuoteRequest Build()
      {
        Validate();
        var request = new CreateQuoteRequest(_portfolioId!)
        {
          ProductId = _productId,
          Side = _side,
          ClientQuoteId = _clientQuoteId,
          BaseQuantity = _baseQuantity,
          QuoteValue = _quoteValue,
          LimitPrice = _limitPrice,
          SettlCurrency = _settlCurrency,
        };
        return request;
      }
    }
  }
}
