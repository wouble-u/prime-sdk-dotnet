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

  public class AcceptQuoteRequest(string portfolioId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }
    [JsonPropertyName("side")]
    public OrderSide Side { get; set; }
    [JsonPropertyName("client_order_id")]
    public string? ClientOrderId { get; set; }
    [JsonPropertyName("quote_id")]
    public string? QuoteId { get; set; }
    [JsonPropertyName("settl_currency")]
    public string? SettlCurrency { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _productId;
      private OrderSide _side;
      private string? _clientOrderId;
      private string? _quoteId;
      private string? _settlCurrency;

      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      public Builder WithProductId(string? productId)
      {
        _productId = productId;
        return this;
      }

      public Builder WithSide(OrderSide side)
      {
        _side = side;
        return this;
      }

      public Builder WithClientOrderId(string? clientOrderId)
      {
        _clientOrderId = clientOrderId;
        return this;
      }

      public Builder WithQuoteId(string? quoteId)
      {
        _quoteId = quoteId;
        return this;
      }

      public Builder WithSettlCurrency(string? settlCurrency)
      {
        _settlCurrency = settlCurrency;
        return this;
      }

      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
      }

      public AcceptQuoteRequest Build()
      {
        Validate();
        var request = new AcceptQuoteRequest(_portfolioId!)
        {
          ProductId = _productId,
          Side = _side,
          ClientOrderId = _clientOrderId,
          QuoteId = _quoteId,
          SettlCurrency = _settlCurrency,
        };
        return request;
      }
    }
  }
}
