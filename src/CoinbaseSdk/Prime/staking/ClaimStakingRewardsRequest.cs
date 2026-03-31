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
  /// Claim Wallet Staking Rewards (Alpha)
  /// Request to claim staking rewards. This feature is in alpha. Please reach out to your Coinbase Prime account manager for more information
  /// </summary>
  public class ClaimStakingRewardsRequest(string portfolioId, string walletId)
  {
    /// <summary>
    /// The portfolio ID
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// The wallet ID
    /// </summary>
    [JsonIgnore]
    public string WalletId { get; set; } = walletId;

    /// <summary>
    /// The client generated idempotency key for requested execution. Any subsequent requests with the same key will return the original response
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    [JsonPropertyName("inputs")]
    public WalletClaimRewardsInputs Inputs { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _walletId;
      private string? _idempotencyKey;
      private WalletClaimRewardsInputs _inputs;

      /// <summary>
      /// The portfolio ID
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// The wallet ID
      /// </summary>
      public Builder WithWalletId(string walletId)
      {
        _walletId = walletId;
        return this;
      }

      /// <summary>
      /// The client generated idempotency key for requested execution. Any subsequent requests with the same key will return the original response
      /// </summary>
      public Builder WithIdempotencyKey(string? idempotencyKey)
      {
        _idempotencyKey = idempotencyKey;
        return this;
      }

      public Builder WithInputs(WalletClaimRewardsInputs inputs)
      {
        _inputs = inputs;
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
        if (string.IsNullOrWhiteSpace(_walletId))
        {
          throw new CoinbaseClientException("WalletId is required");
        }
      }

      /// <summary>
      /// Builds a new <see cref="ClaimStakingRewardsRequest"/>.
      /// </summary>
      public ClaimStakingRewardsRequest Build()
      {
        Validate();
        return new ClaimStakingRewardsRequest(_portfolioId!, _walletId!)
        {
          IdempotencyKey = _idempotencyKey,
          Inputs = _inputs,
        };
      }
    }
  }
}
