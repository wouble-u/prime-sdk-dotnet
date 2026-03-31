/*
 * Copyright 2026-present Coinbase Global, Inc.
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

namespace CoinbaseSdk.Prime.Transactions
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Model;

  /// <summary>
  /// Submit Deposit Travel Rule Data
  /// Submit travel rule data for an existing deposit transaction.
  /// </summary>
  public class SubmitDepositTravelRuleDataRequest(string portfolioId, string transactionId)
  {
    /// <summary>
    /// The portfolio ID that owns the transaction
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// The transaction ID associated with the entry
    /// </summary>
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

      /// <summary>
      /// The portfolio ID that owns the transaction
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// The transaction ID associated with the entry
      /// </summary>
      public Builder WithTransactionId(string transactionId)
      {
        _transactionId = transactionId;
        return this;
      }

      public Builder WithOriginator(TravelRuleParty originator)
      {
        _originator = originator;
        return this;
      }

      public Builder WithBeneficiary(TravelRuleParty beneficiary)
      {
        _beneficiary = beneficiary;
        return this;
      }

      public Builder WithIsSelf(bool? isSelf)
      {
        _isSelf = isSelf;
        return this;
      }

      public Builder WithOptOutOfOwnershipVerification(bool? optOutOfOwnershipVerification)
      {
        _optOutOfOwnershipVerification = optOutOfOwnershipVerification;
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
        if (string.IsNullOrWhiteSpace(_transactionId))
        {
          throw new CoinbaseClientException("TransactionId is required");
        }
      }

      /// <summary>
      /// Builds a new <see cref="SubmitDepositTravelRuleDataRequest"/>.
      /// </summary>
      public SubmitDepositTravelRuleDataRequest Build()
      {
        Validate();
        return new SubmitDepositTravelRuleDataRequest(_portfolioId!, _transactionId!)
        {
          Originator = _originator,
          Beneficiary = _beneficiary,
          IsSelf = _isSelf,
          OptOutOfOwnershipVerification = _optOutOfOwnershipVerification,
        };
      }
    }
  }
}
