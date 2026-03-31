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

  /// <summary>
  /// Request to unstake currency across a portfolio
  /// Creates an execution request to unstake funds across a portfolio.  This will unstake funds in one or more wallets in the portfolio, with a total bonded balance up to the requested unstake amount.
  /// </summary>
  public class CreatePortfolioUnstakeRequest(string portfolioId)
  {
    /// <summary>
    /// The portfolio ID
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// The client generated idempotency key (uuid required) for requested execution. Subsequent requests using the same key will not create new transactions.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// The currency symbol to unstake
    /// </summary>
    [JsonPropertyName("currency_symbol")]
    public string? CurrencySymbol { get; set; }

    /// <summary>
    /// The quantity of the chosen currency to unstake
    /// </summary>
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

      /// <summary>
      /// The portfolio ID
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// The client generated idempotency key (uuid required) for requested execution. Subsequent requests using the same key will not create new transactions.
      /// </summary>
      public Builder WithIdempotencyKey(string? idempotencyKey)
      {
        _idempotencyKey = idempotencyKey;
        return this;
      }

      /// <summary>
      /// The currency symbol to unstake
      /// </summary>
      public Builder WithCurrencySymbol(string? currencySymbol)
      {
        _currencySymbol = currencySymbol;
        return this;
      }

      /// <summary>
      /// The quantity of the chosen currency to unstake
      /// </summary>
      public Builder WithAmount(string? amount)
      {
        _amount = amount;
        return this;
      }

      public Builder WithMetadata(PortfolioStakingMetadata metadata)
      {
        _metadata = metadata;
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
      /// Builds a new <see cref="CreatePortfolioUnstakeRequest"/>.
      /// </summary>
      public CreatePortfolioUnstakeRequest Build()
      {
        Validate();
        return new CreatePortfolioUnstakeRequest(_portfolioId!)
        {
          IdempotencyKey = _idempotencyKey,
          CurrencySymbol = _currencySymbol,
          Amount = _amount,
          Metadata = _metadata,
        };
      }
    }
  }
}
