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

namespace CoinbaseSdk.Prime.Model
{
  using System.Text.Json.Serialization;
  public class Conversion
  {
    [JsonPropertyName("conversion_details")]
    public ConversionDetails? ConversionDetails { get; set; }

    [JsonPropertyName("short_collateral")]
    public ShortCollateral? ShortCollateral { get; set; }

    [JsonPropertyName("conversion_datetime")]
    public string? ConversionDatetime { get; set; }

    [JsonPropertyName("portfolio_id")]
    public string? PortfolioId { get; set; }

    public Conversion() { }

    public class ConversionBuilder
    {
      private ConversionDetails? _conversionDetails;
      private ShortCollateral? _shortCollateral;
      private string? _conversionDatetime;
      private string? _portfolioId;

      public ConversionBuilder WithConversionDetails(ConversionDetails conversionDetails)
      {
        this._conversionDetails = conversionDetails;
        return this;
      }

      public ConversionBuilder WithShortCollateral(ShortCollateral shortCollateral)
      {
        this._shortCollateral = shortCollateral;
        return this;
      }

      public ConversionBuilder WithConversionDatetime(string conversionDatetime)
      {
        this._conversionDatetime = conversionDatetime;
        return this;
      }

      public ConversionBuilder WithPortfolioId(string portfolioId)
      {
        this._portfolioId = portfolioId;
        return this;
      }

      public Conversion Build()
      {
        return new Conversion
        {
          ConversionDetails = this._conversionDetails,
          ShortCollateral = this._shortCollateral,
          ConversionDatetime = this._conversionDatetime,
          PortfolioId = this._portfolioId
        };
      }
    }
  }
}