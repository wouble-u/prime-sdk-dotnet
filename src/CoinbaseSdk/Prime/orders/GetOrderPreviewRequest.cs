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
  using CoinbaseSdk.Prime.Model.Enums;

  /// <summary>
  /// Get Order Preview
  /// Retrieve an order preview.
  /// </summary>
  public class GetOrderPreviewRequest(string portfolioId)
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

    [JsonPropertyName("type")]
    public OrderType Type { get; set; }

    [JsonPropertyName("base_quantity")]
    public string? BaseQuantity { get; set; }

    [JsonPropertyName("quote_value")]
    public string? QuoteValue { get; set; }

    [JsonPropertyName("limit_price")]
    public string? LimitPrice { get; set; }

    [JsonPropertyName("start_time")]
    public string? StartTime { get; set; }

    [JsonPropertyName("expiry_time")]
    public string? ExpiryTime { get; set; }

    [JsonPropertyName("time_in_force")]
    public TimeInForceType TimeInForce { get; set; }

    [JsonPropertyName("is_raise_exact")]
    public bool? IsRaiseExact { get; set; }

    [JsonPropertyName("historical_pov")]
    public string? HistoricalPov { get; set; }

    [JsonPropertyName("stop_price")]
    public string? StopPrice { get; set; }

    [JsonPropertyName("settl_currency")]
    public string? SettlCurrency { get; set; }

    /// <summary>
    /// Specifies whether the order is treated as a post only order.
    /// </summary>
    [JsonPropertyName("postOnly")]
    public bool? PostOnly { get; set; }

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

    [JsonPropertyName("peg_offset_type")]
    public PegOffsetType PegOffsetType { get; set; }

    [JsonPropertyName("offset")]
    public string? Offset { get; set; }

    /// <summary>
    /// next: 21
    /// </summary>
    [JsonPropertyName("wig_level")]
    public string? WigLevel { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _productId;
      private OrderSide _side;
      private OrderType _type;
      private string? _baseQuantity;
      private string? _quoteValue;
      private string? _limitPrice;
      private string? _startTime;
      private string? _expiryTime;
      private TimeInForceType _timeInForce;
      private bool? _isRaiseExact;
      private string? _historicalPov;
      private string? _stopPrice;
      private string? _settlCurrency;
      private bool? _postOnly;
      private string? _displayQuoteSize;
      private string? _displayBaseSize;
      private PegOffsetType _pegOffsetType;
      private string? _offset;
      private string? _wigLevel;

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

      public Builder WithType(OrderType type)
      {
        _type = type;
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

      public Builder WithStartTime(string? startTime)
      {
        _startTime = startTime;
        return this;
      }

      public Builder WithExpiryTime(string? expiryTime)
      {
        _expiryTime = expiryTime;
        return this;
      }

      public Builder WithTimeInForce(TimeInForceType timeInForce)
      {
        _timeInForce = timeInForce;
        return this;
      }

      public Builder WithIsRaiseExact(bool? isRaiseExact)
      {
        _isRaiseExact = isRaiseExact;
        return this;
      }

      public Builder WithHistoricalPov(string? historicalPov)
      {
        _historicalPov = historicalPov;
        return this;
      }

      public Builder WithStopPrice(string? stopPrice)
      {
        _stopPrice = stopPrice;
        return this;
      }

      public Builder WithSettlCurrency(string? settlCurrency)
      {
        _settlCurrency = settlCurrency;
        return this;
      }

      /// <summary>
      /// Specifies whether the order is treated as a post only order.
      /// </summary>
      public Builder WithPostOnly(bool? postOnly)
      {
        _postOnly = postOnly;
        return this;
      }

      /// <summary>
      /// The maximum order size that will show up on venue order books (in quote currency).
      /// </summary>
      public Builder WithDisplayQuoteSize(string? displayQuoteSize)
      {
        _displayQuoteSize = displayQuoteSize;
        return this;
      }

      /// <summary>
      /// The maximum order size that will show up on venue order books (in base currency).
      /// </summary>
      public Builder WithDisplayBaseSize(string? displayBaseSize)
      {
        _displayBaseSize = displayBaseSize;
        return this;
      }

      public Builder WithPegOffsetType(PegOffsetType pegOffsetType)
      {
        _pegOffsetType = pegOffsetType;
        return this;
      }

      public Builder WithOffset(string? offset)
      {
        _offset = offset;
        return this;
      }

      /// <summary>
      /// next: 21
      /// </summary>
      public Builder WithWigLevel(string? wigLevel)
      {
        _wigLevel = wigLevel;
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
      /// Builds a new <see cref="GetOrderPreviewRequest"/>.
      /// </summary>
      public GetOrderPreviewRequest Build()
      {
        Validate();
        return new GetOrderPreviewRequest(_portfolioId!)
        {
          ProductId = _productId,
          Side = _side,
          Type = _type,
          BaseQuantity = _baseQuantity,
          QuoteValue = _quoteValue,
          LimitPrice = _limitPrice,
          StartTime = _startTime,
          ExpiryTime = _expiryTime,
          TimeInForce = _timeInForce,
          IsRaiseExact = _isRaiseExact,
          HistoricalPov = _historicalPov,
          StopPrice = _stopPrice,
          SettlCurrency = _settlCurrency,
          PostOnly = _postOnly,
          DisplayQuoteSize = _displayQuoteSize,
          DisplayBaseSize = _displayBaseSize,
          PegOffsetType = _pegOffsetType,
          Offset = _offset,
          WigLevel = _wigLevel,
        };
      }
    }
  }
}
