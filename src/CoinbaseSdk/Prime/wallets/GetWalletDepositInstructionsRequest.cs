/*
 * Copyright 2024-present Coinbase Global, Inc.
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

namespace CoinbaseSdk.Prime.Wallets
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;

  public class GetWalletDepositInstructionsRequest(string portfolioId, string walletId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;
    [JsonIgnore]
    public string WalletId { get; set; } = walletId;
    [JsonPropertyName("deposit_type")]
    public string? DepositType { get; set; }
    [JsonPropertyName("network.id")]
    public string? NetworkId { get; set; }
    [JsonPropertyName("network.type")]
    public string? NetworkType { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _walletId;
      private string? _depositType;
      private string? _networkId;
      private string? _networkType;

      public Builder WithPortfolioId(string value)
      {
        _portfolioId = value;
        return this;
      }

      public Builder WithWalletId(string value)
      {
        _walletId = value;
        return this;
      }

      public Builder WithDepositType(string? value)
      {
        _depositType = value;
        return this;
      }

      public Builder WithNetworkId(string? value)
      {
        _networkId = value;
        return this;
      }

      public Builder WithNetworkType(string? value)
      {
        _networkType = value;
        return this;
      }

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

      public GetWalletDepositInstructionsRequest Build()
      {
        Validate();
        var request = new GetWalletDepositInstructionsRequest(_portfolioId!, _walletId!)
        {
          DepositType = _depositType,
          NetworkId = _networkId,
          NetworkType = _networkType,
        };
        return request;
      }
    }
  }
}
