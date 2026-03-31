/*
 * Copyright 2026-present Coinbase Global, Inc.
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

namespace CoinbaseSdk.Prime.Products
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;

  /// <summary>
  /// Get Public Product Candles (Beta)
  /// Get rates for a single product by product ID, grouped in buckets. This feature is in beta please reach out to your Coinbase Prime account manager for more information.
  /// </summary>
  public class GetCandlesRequest(string portfolioId)
  {
    /// <summary>
    /// The portfolio id requesting market data.
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// The trading pair.
    /// </summary>
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    /// <summary>
    /// Timestamp for starting range of aggregations
    /// </summary>
    [JsonPropertyName("start_time")]
    public string? StartTime { get; set; }

    /// <summary>
    /// Timestamp for ending range of aggregations
    /// </summary>
    [JsonPropertyName("end_time")]
    public string? EndTime { get; set; }

    /// <summary>
    /// The timeframe each candle represents.
    /// </summary>
    [JsonPropertyName("granularity")]
    public string? Granularity { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _productId;
      private string? _startTime;
      private string? _endTime;
      private string? _granularity;

      /// <summary>
      /// The portfolio id requesting market data.
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// The trading pair.
      /// </summary>
      public Builder WithProductId(string? productId)
      {
        _productId = productId;
        return this;
      }

      /// <summary>
      /// Timestamp for starting range of aggregations
      /// </summary>
      public Builder WithStartTime(string? startTime)
      {
        _startTime = startTime;
        return this;
      }

      /// <summary>
      /// Timestamp for ending range of aggregations
      /// </summary>
      public Builder WithEndTime(string? endTime)
      {
        _endTime = endTime;
        return this;
      }

      /// <summary>
      /// The timeframe each candle represents.
      /// </summary>
      public Builder WithGranularity(string? granularity)
      {
        _granularity = granularity;
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
      /// Builds a new <see cref="GetCandlesRequest"/>.
      /// </summary>
      public GetCandlesRequest Build()
      {
        Validate();
        return new GetCandlesRequest(_portfolioId!)
        {
          ProductId = _productId,
          StartTime = _startTime,
          EndTime = _endTime,
          Granularity = _granularity,
        };
      }
    }
  }
}
