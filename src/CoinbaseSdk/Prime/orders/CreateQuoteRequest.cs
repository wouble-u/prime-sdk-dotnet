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
  using CoinbaseSdk.Prime.Model.Enums;

  /// <summary>
  /// Create Quote Request
  /// A Quote Request is the start of the RFQ process. Coinbase Prime sends a Quote Request to Liquidity Providers (LPs) on behalf of a customer looking to participate in an RFQ trade.
  /// Always required: portfolio_id, product_id, side, client_quote_id, and limit_price. One of either base_quantity or quote_value is always required.
  /// </summary>
  public class CreateQuoteRequest(string portfolioId)
  {
    /// <summary>
    /// The ID of the portfolio that owns the order
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    [JsonPropertyName("side")]
    public OrderSide Side { get; set; }

    /// <summary>
    /// A client-generated order ID used for reference purposes (note: order will be rejected if this ID is not unique among all currently active orders)
    /// </summary>
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

      /// <summary>
      /// The ID of the portfolio that owns the order
      /// </summary>
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

      /// <summary>
      /// A client-generated order ID used for reference purposes (note: order will be rejected if this ID is not unique among all currently active orders)
      /// </summary>
      public Builder WithClientQuoteId(string? clientQuoteId)
      {
        _clientQuoteId = clientQuoteId;
        return this;
      }

      public Builder WithBaseQuantity(string? baseQuantity)
      {
        _baseQuantity = baseQuantity;
        return this;
      }

      public Builder WithQuoteValue(string? quoteValue)
      {
        _quoteValue = quoteValue;
        return this;
      }

      public Builder WithLimitPrice(string? limitPrice)
      {
        _limitPrice = limitPrice;
        return this;
      }

      public Builder WithSettlCurrency(string? settlCurrency)
      {
        _settlCurrency = settlCurrency;
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
      /// Builds a new <see cref="CreateQuoteRequest"/>.
      /// </summary>
      public CreateQuoteRequest Build()
      {
        Validate();
        return new CreateQuoteRequest(_portfolioId!)
        {
          ProductId = _productId,
          Side = _side,
          ClientQuoteId = _clientQuoteId,
          BaseQuantity = _baseQuantity,
          QuoteValue = _quoteValue,
          LimitPrice = _limitPrice,
          SettlCurrency = _settlCurrency,
        };
      }
    }
  }
}
