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

namespace CoinbaseSdk.Prime.Model
{
  using System.Text.Json.Serialization;
  public class MarginSummaryHistorical
  {
    [JsonPropertyName("conversion_datetime")]
    public string? ConversionDatetime { get; set; }

    [JsonPropertyName("conversion_date")]
    public string? ConversionDate { get; set; }

    [JsonPropertyName("margin_summary")]
    public MarginSummary? MarginSummary { get; set; }

    public MarginSummaryHistorical() { }

    public class MarginSummaryHistoricalBuilder
    {
      private string? _conversionDatetime;
      private string? _conversionDate;
      private MarginSummary? _marginSummary;

      public MarginSummaryHistoricalBuilder WithConversionDatetime(string conversionDatetime)
      {
        this._conversionDatetime = conversionDatetime;
        return this;
      }

      public MarginSummaryHistoricalBuilder WithConversionDate(string conversionDate)
      {
        this._conversionDate = conversionDate;
        return this;
      }

      public MarginSummaryHistoricalBuilder WithMarginSummary(MarginSummary marginSummary)
      {
        this._marginSummary = marginSummary;
        return this;
      }

      public MarginSummaryHistorical Build()
      {
        return new MarginSummaryHistorical
        {
          ConversionDatetime = this._conversionDatetime,
          ConversionDate = this._conversionDate,
          MarginSummary = this._marginSummary
        };
      }
    }
  }
}