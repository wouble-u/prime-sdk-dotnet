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

namespace CoinbaseSdk.Prime.Wallets
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;

  /// <summary>
  /// Create Wallet Deposit Address
  /// Creates a new deposit address for a wallet. Only applicable to wallets that support multiple deposit addresses on a given network
  /// </summary>
  public class CreateWalletDepositAddressRequest(string portfolioId, string walletId)
  {
    /// <summary>
    /// The ID of the portfolio that owns the wallet
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// The wallet ID for which to create the deposit address
    /// </summary>
    [JsonIgnore]
    public string WalletId { get; set; } = walletId;

    /// <summary>
    /// The network name and type
    /// </summary>
    [JsonPropertyName("network_id")]
    public string? NetworkId { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _walletId;
      private string? _networkId;

      /// <summary>
      /// The ID of the portfolio that owns the wallet
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// The wallet ID for which to create the deposit address
      /// </summary>
      public Builder WithWalletId(string walletId)
      {
        _walletId = walletId;
        return this;
      }

      /// <summary>
      /// The network name and type
      /// </summary>
      public Builder WithNetworkId(string? networkId)
      {
        _networkId = networkId;
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
      /// Builds a new <see cref="CreateWalletDepositAddressRequest"/>.
      /// </summary>
      public CreateWalletDepositAddressRequest Build()
      {
        Validate();
        return new CreateWalletDepositAddressRequest(_portfolioId!, _walletId!)
        {
          NetworkId = _networkId,
        };
      }
    }
  }
}
