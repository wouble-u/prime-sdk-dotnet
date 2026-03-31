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

  public class GetCandlesRequest(string portfolioId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }
    [JsonPropertyName("start_time")]
    public string? StartTime { get; set; }
    [JsonPropertyName("end_time")]
    public string? EndTime { get; set; }
    [JsonPropertyName("granularity")]
    public string? Granularity { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _productId;
      private string? _startTime;
      private string? _endTime;
      private string? _granularity;

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

      public Builder WithStartTime(string? value)
      {
        _startTime = value;
        return this;
      }

      public Builder WithEndTime(string? value)
      {
        _endTime = value;
        return this;
      }

      public Builder WithGranularity(string? value)
      {
        _granularity = value;
        return this;
      }

      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
      }

      public GetCandlesRequest Build()
      {
        Validate();
        var request = new GetCandlesRequest(_portfolioId!)
        {
          ProductId = _productId,
          StartTime = _startTime,
          EndTime = _endTime,
          Granularity = _granularity,
        };
        return request;
      }
    }
  }
}
