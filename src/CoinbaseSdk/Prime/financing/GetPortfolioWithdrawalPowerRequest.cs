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
  /// Get Portfolio Withdrawal Power
  /// Returns the nominal quantity of a given asset that can be withdrawn based on holdings and current portfolio equity.
  /// </summary>
  public class GetPortfolioWithdrawalPowerRequest(string portfolioId)
  {
    /// <summary>
    /// The unique ID of the portfolio
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// The currency symbol
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _symbol;

      /// <summary>
      /// The unique ID of the portfolio
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// The currency symbol
      /// </summary>
      public Builder WithSymbol(string? symbol)
      {
        _symbol = symbol;
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
      /// Builds a new <see cref="GetPortfolioWithdrawalPowerRequest"/>.
      /// </summary>
      public GetPortfolioWithdrawalPowerRequest Build()
      {
        Validate();
        return new GetPortfolioWithdrawalPowerRequest(_portfolioId!)
        {
          Symbol = _symbol,
        };
      }
    }
  }
}
