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

  /// <summary>
  /// Get Transaction Travel Rule Data
  /// (Beta) Get fulfilled travel rule data for a transaction.
  /// </summary>
  public class GetTransactionTravelRuleDataRequest(string portfolioId, string transactionId)
  {
    /// <summary>
    /// The portfolio ID that owns the transaction
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// The transaction ID to look up travel rule data for
    /// </summary>
    [JsonIgnore]
    public string TransactionId { get; set; } = transactionId;

    public class Builder
    {
      private string? _portfolioId;
      private string? _transactionId;

      /// <summary>
      /// The portfolio ID that owns the transaction
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// The transaction ID to look up travel rule data for
      /// </summary>
      public Builder WithTransactionId(string transactionId)
      {
        _transactionId = transactionId;
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
      /// Builds a new <see cref="GetTransactionTravelRuleDataRequest"/>.
      /// </summary>
      public GetTransactionTravelRuleDataRequest Build()
      {
        Validate();
        return new GetTransactionTravelRuleDataRequest(_portfolioId!, _transactionId!)
        {
        };
      }
    }
  }
}
