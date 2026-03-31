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

namespace CoinbaseSdk.Prime.Transactions
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;

  public class CreateTransferRequest(string portfolioId, string walletId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;
    [JsonIgnore]
    public string WalletId { get; set; } = walletId;
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }
    [JsonPropertyName("destination")]
    public string? Destination { get; set; }
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }
    [JsonPropertyName("currency_symbol")]
    public string? CurrencySymbol { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _walletId;
      private string? _amount;
      private string? _destination;
      private string? _idempotencyKey;
      private string? _currencySymbol;

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

      public Builder WithAmount(string? value)
      {
        _amount = value;
        return this;
      }

      public Builder WithDestination(string? value)
      {
        _destination = value;
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

      public CreateTransferRequest Build()
      {
        Validate();
        var request = new CreateTransferRequest(_portfolioId!, _walletId!)
        {
          Amount = _amount,
          Destination = _destination,
          IdempotencyKey = _idempotencyKey,
          CurrencySymbol = _currencySymbol,
        };
        return request;
      }
    }
  }
}
