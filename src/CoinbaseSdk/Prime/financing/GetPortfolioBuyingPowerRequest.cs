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

  /// <summary>
  /// Get Portfolio Buying Power
  /// Returns the size of a buy trade that can be performed based on existing holdings and available credit. The result will differ for different assets due to asset specific credit configurations and caps. Note that this result is changing based on asset price fluctuations, so may be rejected when submitted.
  /// </summary>
  public class GetPortfolioBuyingPowerRequest(string portfolioId)
  {
    /// <summary>
    /// The unique ID of the portfolio
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// The symbol for the base currency
    /// </summary>
    [JsonPropertyName("base_currency")]
    public string? BaseCurrency { get; set; }

    /// <summary>
    /// The symbol for the quote currency
    /// </summary>
    [JsonPropertyName("quote_currency")]
    public string? QuoteCurrency { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _baseCurrency;
      private string? _quoteCurrency;

      /// <summary>
      /// The unique ID of the portfolio
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// The symbol for the base currency
      /// </summary>
      public Builder WithBaseCurrency(string? baseCurrency)
      {
        _baseCurrency = baseCurrency;
        return this;
      }

      /// <summary>
      /// The symbol for the quote currency
      /// </summary>
      public Builder WithQuoteCurrency(string? quoteCurrency)
      {
        _quoteCurrency = quoteCurrency;
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
      /// Builds a new <see cref="GetPortfolioBuyingPowerRequest"/>.
      /// </summary>
      public GetPortfolioBuyingPowerRequest Build()
      {
        Validate();
        return new GetPortfolioBuyingPowerRequest(_portfolioId!)
        {
          BaseCurrency = _baseCurrency,
          QuoteCurrency = _quoteCurrency,
        };
      }
    }
  }
}
