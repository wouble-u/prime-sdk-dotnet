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
  using CoinbaseSdk.Prime.Model;

  public class AcceptQuoteRequest(string portfolioId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    [JsonPropertyName("quote_id")]
    public string? QuoteId { get; set; }

    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    [JsonPropertyName("client_order_id")]
    public string? ClientOrderId { get; set; }

    [JsonPropertyName("settl_currency")]
    public string? SettlCurrency { get; set; }

    public OrderSide? Side { get; set; }

    public class AcceptQuoteRequestBuilder(string portfolioId)
    {
      private string _portfolioId = portfolioId;
      private string? _quoteId;
      private string? _productId;
      private string? _clientOrderId;
      private string? _settlCurrency;
      private OrderSide? _side;

      public AcceptQuoteRequestBuilder WithQuoteId(string quoteId)
      {
        this._quoteId = quoteId;
        return this;
      }

      public AcceptQuoteRequestBuilder WithProductId(string productId)
      {
        this._productId = productId;
        return this;
      }

      public AcceptQuoteRequestBuilder WithClientOrderId(string clientOrderId)
      {
        this._clientOrderId = clientOrderId;
        return this;
      }

      public AcceptQuoteRequestBuilder WithSettlCurrency(string settlCurrency)
      {
        this._settlCurrency = settlCurrency;
        return this;
      }

      public AcceptQuoteRequestBuilder WithSide(OrderSide side)
      {
        this._side = side;
        return this;
      }

      public AcceptQuoteRequest Build()
      {
        return new AcceptQuoteRequest(_portfolioId)
        {
          QuoteId = _quoteId,
          ProductId = _productId,
          ClientOrderId = _clientOrderId,
          SettlCurrency = _settlCurrency,
          Side = _side
        };
      }
    }
  }
}