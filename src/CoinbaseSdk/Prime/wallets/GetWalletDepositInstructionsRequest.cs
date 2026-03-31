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

namespace CoinbaseSdk.Prime.Wallets
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;

  /// <summary>
  /// Get Wallet Deposit Instructions
  /// Retrieve a specific wallet's deposit instructions.
  /// </summary>
  public class GetWalletDepositInstructionsRequest(string portfolioId, string walletId)
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
    /// The deposit type
    /// - UNKNOWN_WALLET_DEPOSIT_TYPE: nil value
    /// - CRYPTO: A cryptocurrency deposit
    /// - WIRE: A wire deposit
    /// - SEN: DEPRECATED. A Silvergate Exchange Network deposit
    /// - SWIFT: A SWIFT deposit
    /// - SEPA: A SEPA deposit (Single Euro Payments Area)
    /// </summary>
    [JsonPropertyName("deposit_type")]
    public string? DepositType { get; set; }

    /// <summary>
    /// The name of the network
    /// The network id: base, bitcoin, ethereum, solana etc
    /// </summary>
    [JsonPropertyName("network.id")]
    public string? NetworkId { get; set; }

    /// <summary>
    /// The network type
    /// The network type: mainnet, testnet, etc
    /// </summary>
    [JsonPropertyName("network.type")]
    public string? NetworkType { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _walletId;
      private string? _depositType;
      private string? _networkId;
      private string? _networkType;

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
      /// The deposit type
      /// - UNKNOWN_WALLET_DEPOSIT_TYPE: nil value
      /// - CRYPTO: A cryptocurrency deposit
      /// - WIRE: A wire deposit
      /// - SEN: DEPRECATED. A Silvergate Exchange Network deposit
      /// - SWIFT: A SWIFT deposit
      /// - SEPA: A SEPA deposit (Single Euro Payments Area)
      /// </summary>
      public Builder WithDepositType(string? depositType)
      {
        _depositType = depositType;
        return this;
      }

      /// <summary>
      /// The name of the network
      /// The network id: base, bitcoin, ethereum, solana etc
      /// </summary>
      public Builder WithNetworkId(string? networkId)
      {
        _networkId = networkId;
        return this;
      }

      /// <summary>
      /// The network type
      /// The network type: mainnet, testnet, etc
      /// </summary>
      public Builder WithNetworkType(string? networkType)
      {
        _networkType = networkType;
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
      /// Builds a new <see cref="GetWalletDepositInstructionsRequest"/>.
      /// </summary>
      public GetWalletDepositInstructionsRequest Build()
      {
        Validate();
        return new GetWalletDepositInstructionsRequest(_portfolioId!, _walletId!)
        {
          DepositType = _depositType,
          NetworkId = _networkId,
          NetworkType = _networkType,
        };
      }
    }
  }
}
