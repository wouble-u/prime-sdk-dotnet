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

namespace CoinbaseSdk.Prime.Financing
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Prime.Model;
  public class GetMarginInformationResponse
  {
    [JsonPropertyName("margin_information")]
    public MarginInformation? MarginInformation { get; set; }

    [JsonPropertyName("margin_summary")]
    public MarginSummary? MarginSummary { get; set; }

    public GetMarginInformationResponse() { }

    public class GetMarginInformationResponseBuilder
    {
      private MarginInformation? _marginInformation;
      private MarginSummary? _marginSummary;

      public GetMarginInformationResponseBuilder WithMarginInformation(MarginInformation marginInformation)
      {
        this._marginInformation = marginInformation;
        return this;
      }

      public GetMarginInformationResponseBuilder WithMarginSummary(MarginSummary marginSummary)
      {
        this._marginSummary = marginSummary;
        return this;
      }

      public GetMarginInformationResponse Build()
      {
        return new GetMarginInformationResponse
        {
          MarginInformation = this._marginInformation,
          MarginSummary = this._marginSummary
        };
      }
    }
  }
}