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

namespace CoinbaseSdk.Prime.Balances
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;

  public class ListPortfolioBalancesRequest(string portfolioId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;
    [JsonPropertyName("symbols")]
    public string? Symbols { get; set; }
    [JsonPropertyName("balance_type")]
    public string? BalanceType { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _symbols;
      private string? _balanceType;

      public Builder WithPortfolioId(string value)
      {
        _portfolioId = value;
        return this;
      }

      public Builder WithSymbols(string? value)
      {
        _symbols = value;
        return this;
      }

      public Builder WithBalanceType(string? value)
      {
        _balanceType = value;
        return this;
      }

      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
      }

      public ListPortfolioBalancesRequest Build()
      {
        Validate();
        var request = new ListPortfolioBalancesRequest(_portfolioId!)
        {
          Symbols = _symbols,
          BalanceType = _balanceType,
        };
        return request;
      }
    }
  }
}
