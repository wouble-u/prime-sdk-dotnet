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
  using CoinbaseSdk.Core.Error;

  public class GetPortfolioBuyingPowerRequest(string portfolioId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;
    [JsonPropertyName("base_currency")]
    public string? BaseCurrency { get; set; }
    [JsonPropertyName("quote_currency")]
    public string? QuoteCurrency { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _baseCurrency;
      private string? _quoteCurrency;

      public Builder WithPortfolioId(string value)
      {
        _portfolioId = value;
        return this;
      }

      public Builder WithBaseCurrency(string? value)
      {
        _baseCurrency = value;
        return this;
      }

      public Builder WithQuoteCurrency(string? value)
      {
        _quoteCurrency = value;
        return this;
      }

      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
      }

      public GetPortfolioBuyingPowerRequest Build()
      {
        Validate();
        var request = new GetPortfolioBuyingPowerRequest(_portfolioId!)
        {
          BaseCurrency = _baseCurrency,
          QuoteCurrency = _quoteCurrency,
        };
        return request;
      }
    }
  }
}
