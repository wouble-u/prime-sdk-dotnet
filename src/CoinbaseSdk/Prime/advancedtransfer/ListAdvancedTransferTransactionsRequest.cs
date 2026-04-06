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

namespace CoinbaseSdk.Prime.AdvancedTransfer
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;

    /// <summary>
    /// List transactions associated with an Advanced Transfer.
    /// </summary>
  public class ListAdvancedTransferTransactionsRequest(string portfolioId, string advancedTransferId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    [JsonIgnore]
    public string AdvancedTransferId { get; set; } = advancedTransferId;

    public class ListAdvancedTransferTransactionsRequestBuilder
    {
      private string? _portfolioId;
      private string? _advancedTransferId;

      public ListAdvancedTransferTransactionsRequestBuilder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      public ListAdvancedTransferTransactionsRequestBuilder WithAdvancedTransferId(string advancedTransferId)
      {
        _advancedTransferId = advancedTransferId;
        return this;
      }

      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
        if (string.IsNullOrWhiteSpace(_advancedTransferId))
        {
          throw new CoinbaseClientException("AdvancedTransferId is required");
        }
      }

      public ListAdvancedTransferTransactionsRequest Build()
      {
        Validate();
        return new ListAdvancedTransferTransactionsRequest(_portfolioId!, _advancedTransferId!)
        {
        };
      }
    }
  }
}
