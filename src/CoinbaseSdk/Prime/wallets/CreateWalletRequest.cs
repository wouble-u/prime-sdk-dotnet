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
  using CoinbaseSdk.Prime.Model.Enums;
  using CoinbaseSdk.Prime.Model;

  public class CreateWalletRequest(string portfolioId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }
    [JsonPropertyName("wallet_type")]
    public WalletType WalletType { get; set; }
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }
    [JsonPropertyName("network_family")]
    public NetworkFamily NetworkFamily { get; set; }
    [JsonPropertyName("network")]
    public Network Network { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _name;
      private string? _symbol;
      private WalletType _walletType;
      private string? _idempotencyKey;
      private NetworkFamily _networkFamily;
      private Network _network;

      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      public Builder WithName(string? name)
      {
        _name = name;
        return this;
      }

      public Builder WithSymbol(string? symbol)
      {
        _symbol = symbol;
        return this;
      }

      public Builder WithWalletType(WalletType walletType)
      {
        _walletType = walletType;
        return this;
      }

      public Builder WithIdempotencyKey(string? idempotencyKey)
      {
        _idempotencyKey = idempotencyKey;
        return this;
      }

      public Builder WithNetworkFamily(NetworkFamily networkFamily)
      {
        _networkFamily = networkFamily;
        return this;
      }

      public Builder WithNetwork(Network network)
      {
        _network = network;
        return this;
      }

      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
      }

      public CreateWalletRequest Build()
      {
        Validate();
        var request = new CreateWalletRequest(_portfolioId!)
        {
          Name = _name,
          Symbol = _symbol,
          WalletType = _walletType,
          IdempotencyKey = _idempotencyKey,
          NetworkFamily = _networkFamily,
          Network = _network,
        };
        return request;
      }
    }
  }
}
