/*
 * Copyright 2026-present Coinbase Global, Inc.
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
  using CoinbaseSdk.Prime.Model;

  public class SubmitDepositTravelRuleDataRequest(string portfolioId, string transactionId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;
    [JsonIgnore]
    public string TransactionId { get; set; } = transactionId;
    [JsonPropertyName("originator")]
    public TravelRuleParty Originator { get; set; }
    [JsonPropertyName("beneficiary")]
    public TravelRuleParty Beneficiary { get; set; }
    [JsonPropertyName("is_self")]
    public bool? IsSelf { get; set; }
    [JsonPropertyName("opt_out_of_ownership_verification")]
    public bool? OptOutOfOwnershipVerification { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _transactionId;
      private TravelRuleParty _originator;
      private TravelRuleParty _beneficiary;
      private bool? _isSelf;
      private bool? _optOutOfOwnershipVerification;

      public Builder WithPortfolioId(string value)
      {
        _portfolioId = value;
        return this;
      }

      public Builder WithTransactionId(string value)
      {
        _transactionId = value;
        return this;
      }

      public Builder WithOriginator(TravelRuleParty value)
      {
        _originator = value;
        return this;
      }

      public Builder WithBeneficiary(TravelRuleParty value)
      {
        _beneficiary = value;
        return this;
      }

      public Builder WithIsSelf(bool? value)
      {
        _isSelf = value;
        return this;
      }

      public Builder WithOptOutOfOwnershipVerification(bool? value)
      {
        _optOutOfOwnershipVerification = value;
        return this;
      }

      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
        if (string.IsNullOrWhiteSpace(_transactionId))
        {
          throw new CoinbaseClientException("TransactionId is required");
        }
      }

      public SubmitDepositTravelRuleDataRequest Build()
      {
        Validate();
        var request = new SubmitDepositTravelRuleDataRequest(_portfolioId!, _transactionId!)
        {
          Originator = _originator,
          Beneficiary = _beneficiary,
          IsSelf = _isSelf,
          OptOutOfOwnershipVerification = _optOutOfOwnershipVerification,
        };
        return request;
      }
    }
  }
}
