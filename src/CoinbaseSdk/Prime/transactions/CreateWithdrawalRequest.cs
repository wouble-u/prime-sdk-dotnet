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
  using CoinbaseSdk.Prime.Model.Enums;
  using CoinbaseSdk.Prime.Model;

  public class CreateWithdrawalRequest(string portfolioId, string walletId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;
    [JsonIgnore]
    public string WalletId { get; set; } = walletId;
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }
    [JsonPropertyName("destination_type")]
    public DestinationType DestinationType { get; set; }
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }
    [JsonPropertyName("currency_symbol")]
    public string? CurrencySymbol { get; set; }
    [JsonPropertyName("payment_method")]
    public PaymentMethodDestination PaymentMethod { get; set; }
    [JsonPropertyName("blockchain_address")]
    public BlockchainAddress BlockchainAddress { get; set; }
    [JsonPropertyName("counterparty")]
    public CounterpartyDestination Counterparty { get; set; }
    [JsonPropertyName("travel_rule_data")]
    public TravelRuleData TravelRuleData { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _walletId;
      private string? _amount;
      private DestinationType _destinationType;
      private string? _idempotencyKey;
      private string? _currencySymbol;
      private PaymentMethodDestination _paymentMethod;
      private BlockchainAddress _blockchainAddress;
      private CounterpartyDestination _counterparty;
      private TravelRuleData _travelRuleData;

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

      public Builder WithDestinationType(DestinationType value)
      {
        _destinationType = value;
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

      public Builder WithPaymentMethod(PaymentMethodDestination value)
      {
        _paymentMethod = value;
        return this;
      }

      public Builder WithBlockchainAddress(BlockchainAddress value)
      {
        _blockchainAddress = value;
        return this;
      }

      public Builder WithCounterparty(CounterpartyDestination value)
      {
        _counterparty = value;
        return this;
      }

      public Builder WithTravelRuleData(TravelRuleData value)
      {
        _travelRuleData = value;
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

      public CreateWithdrawalRequest Build()
      {
        Validate();
        var request = new CreateWithdrawalRequest(_portfolioId!, _walletId!)
        {
          Amount = _amount,
          DestinationType = _destinationType,
          IdempotencyKey = _idempotencyKey,
          CurrencySymbol = _currencySymbol,
          PaymentMethod = _paymentMethod,
          BlockchainAddress = _blockchainAddress,
          Counterparty = _counterparty,
          TravelRuleData = _travelRuleData,
        };
        return request;
      }
    }
  }
}
