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
  using CoinbaseSdk.Prime.Model.Enums;

  /// <summary>
  /// A successful response.
  /// </summary>
  public class GetOrderPreviewResponse
  {
    /// <summary>
    /// The ID of the portfolio that owns the order
    /// </summary>
    [JsonPropertyName("portfolio_id")]
    public string? PortfolioId { get; set; }

    /// <summary>
    /// The ID of the product being traded by the order
    /// </summary>
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    [JsonPropertyName("side")]
    public OrderSide Side { get; set; }

    [JsonPropertyName("type")]
    public OrderType Type { get; set; }

    /// <summary>
    /// Order size in base asset units (either `base_quantity` or `quote_value` is required)
    /// </summary>
    [JsonPropertyName("base_quantity")]
    public string? BaseQuantity { get; set; }

    /// <summary>
    /// Order size in quote asset units, i.e. the amount the user wants to spend (when buying) or receive (when selling); the quantity in base units will be determined based on the market liquidity and indicated `quote_value`. Either `base_quantity` or `quote_value` is required
    /// </summary>
    [JsonPropertyName("quote_value")]
    public string? QuoteValue { get; set; }

    /// <summary>
    /// The limit price (required for TWAP, VWAP, LIMIT, and STOP_LIMIT orders)
    /// </summary>
    [JsonPropertyName("limit_price")]
    public string? LimitPrice { get; set; }

    /// <summary>
    /// The start time of the order in UTC (only applies to TWAP orders.)
    /// </summary>
    [JsonPropertyName("start_time")]
    public string? StartTime { get; set; }

    /// <summary>
    /// The expiry time of the order in UTC (TWAP, VWAP, LIMIT and STOP_LIMIT GTD only). Required for TWAP and VWAP orders if historical_pov is unspecified
    /// </summary>
    [JsonPropertyName("expiry_time")]
    public string? ExpiryTime { get; set; }

    [JsonPropertyName("time_in_force")]
    public TimeInForceType TimeInForce { get; set; }

    /// <summary>
    /// Indicate the total commission paid on this order in quote currency - only applicable if the order has any fills
    /// </summary>
    [JsonPropertyName("commission")]
    public string? Commission { get; set; }

    /// <summary>
    /// How much slippage is expected
    /// </summary>
    [JsonPropertyName("slippage")]
    public string? Slippage { get; set; }

    /// <summary>
    /// Current best bid for order book
    /// </summary>
    [JsonPropertyName("best_bid")]
    public string? BestBid { get; set; }

    /// <summary>
    /// Current best ask for order book
    /// </summary>
    [JsonPropertyName("best_ask")]
    public string? BestAsk { get; set; }

    /// <summary>
    /// Indicate expected average filled price based on the current order book
    /// </summary>
    [JsonPropertyName("average_filled_price")]
    public string? AverageFilledPrice { get; set; }

    /// <summary>
    /// Order quantity + fees
    /// </summary>
    [JsonPropertyName("order_total")]
    public string? OrderTotal { get; set; }

    /// <summary>
    /// The estimated participation rate for a TWAP/VWAP order. This field can be specified instead of expiry time, and will be used to compute the expiry time of the order based on historical participation rate.
    /// </summary>
    [JsonPropertyName("historical_pov")]
    public string? HistoricalPov { get; set; }

    /// <summary>
    /// Raise Exact order flag
    /// </summary>
    [JsonPropertyName("is_raise_exact")]
    public bool? IsRaiseExact { get; set; }

    /// <summary>
    /// Stop price for the order
    /// </summary>
    [JsonPropertyName("stop_price")]
    public string? StopPrice { get; set; }

    /// <summary>
    /// The maximum order size that will show up on venue order books.
    /// </summary>
    [JsonPropertyName("display_size")]
    public string? DisplaySize { get; set; }

    /// <summary>
    /// The maximum order size that will show up on venue order books (in quote currency).
    /// </summary>
    [JsonPropertyName("display_quote_size")]
    public string? DisplayQuoteSize { get; set; }

    /// <summary>
    /// The maximum order size that will show up on venue order books (in base currency).
    /// </summary>
    [JsonPropertyName("display_base_size")]
    public string? DisplayBaseSize { get; set; }

    public GetOrderPreviewResponse() { }
  }
}
