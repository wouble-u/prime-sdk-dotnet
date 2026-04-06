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

namespace CoinbaseSdk.Prime.Transactions
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;

    /// <summary>
    /// Get Transaction by Transaction ID.
    /// </summary>
  public class GetTransactionRequest(string portfolioId, string transactionId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    [JsonIgnore]
    public string TransactionId { get; set; } = transactionId;

    public class GetTransactionRequestBuilder
    {
      private string? _portfolioId;
      private string? _transactionId;

      public GetTransactionRequestBuilder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      public GetTransactionRequestBuilder WithTransactionId(string transactionId)
      {
        _transactionId = transactionId;
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

      public GetTransactionRequest Build()
      {
        Validate();
        return new GetTransactionRequest(_portfolioId!, _transactionId!)
        {
        };
      }
    }
  }
}
