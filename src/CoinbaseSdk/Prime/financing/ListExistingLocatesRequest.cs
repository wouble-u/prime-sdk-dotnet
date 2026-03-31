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

namespace CoinbaseSdk.Prime.Financing
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;

  public class ListExistingLocatesRequest(string portfolioId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;
    [JsonPropertyName("locate_ids")]
    public string?[] LocateIds { get; set; } = [];
    [JsonPropertyName("conversion_date")]
    public string? ConversionDate { get; set; }
    [JsonPropertyName("locate_date")]
    public string? LocateDate { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string?[]? _locateIds;
      private string? _conversionDate;
      private string? _locateDate;

      public Builder WithPortfolioId(string value)
      {
        _portfolioId = value;
        return this;
      }

      public Builder WithLocateIds(string?[] value)
      {
        _locateIds = value;
        return this;
      }

      public Builder WithConversionDate(string? value)
      {
        _conversionDate = value;
        return this;
      }

      public Builder WithLocateDate(string? value)
      {
        _locateDate = value;
        return this;
      }

      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
      }

      public ListExistingLocatesRequest Build()
      {
        Validate();
        var request = new ListExistingLocatesRequest(_portfolioId!)
        {
          LocateIds = _locateIds,
          ConversionDate = _conversionDate,
          LocateDate = _locateDate,
        };
        return request;
      }
    }
  }
}
