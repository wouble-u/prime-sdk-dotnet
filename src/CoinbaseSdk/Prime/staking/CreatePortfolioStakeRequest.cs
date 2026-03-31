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

namespace CoinbaseSdk.Prime.Staking
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Model;

  public class CreatePortfolioStakeRequest(string portfolioId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }
    [JsonPropertyName("currency_symbol")]
    public string? CurrencySymbol { get; set; }
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }
    [JsonPropertyName("metadata")]
    public PortfolioStakingMetadata Metadata { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _idempotencyKey;
      private string? _currencySymbol;
      private string? _amount;
      private PortfolioStakingMetadata _metadata;

      public Builder WithPortfolioId(string value)
      {
        _portfolioId = value;
        return this;
      }

      public Builder WithIdempotencyKey(string? value)
      {
        _idempotencyKey = value;
        return this;
      }

      public Builder WithCurrencySymbol(string? value)
      {
        _currencySymbol = value;
        return this;
      }

      public Builder WithAmount(string? value)
      {
        _amount = value;
        return this;
      }

      public Builder WithMetadata(PortfolioStakingMetadata value)
      {
        _metadata = value;
        return this;
      }

      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
      }

      public CreatePortfolioStakeRequest Build()
      {
        Validate();
        var request = new CreatePortfolioStakeRequest(_portfolioId!)
        {
          IdempotencyKey = _idempotencyKey,
          CurrencySymbol = _currencySymbol,
          Amount = _amount,
          Metadata = _metadata,
        };
        return request;
      }
    }
  }
}
