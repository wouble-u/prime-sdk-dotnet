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

namespace CoinbaseSdk.Prime.Allocations
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;

    /// <summary>
    /// Get Net Allocations by Netting ID.
    /// </summary>
  public class ListAllocationsByClientNettingIdRequest(string portfolioId, string nettingId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    [JsonIgnore]
    public string NettingId { get; set; } = nettingId;

    public class ListAllocationsByClientNettingIdRequestBuilder
    {
      private string? _portfolioId;
      private string? _nettingId;

      public ListAllocationsByClientNettingIdRequestBuilder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      public ListAllocationsByClientNettingIdRequestBuilder WithNettingId(string nettingId)
      {
        _nettingId = nettingId;
        return this;
      }

      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
        if (string.IsNullOrWhiteSpace(_nettingId))
        {
          throw new CoinbaseClientException("NettingId is required");
        }
      }

      public ListAllocationsByClientNettingIdRequest Build()
      {
        Validate();
        return new ListAllocationsByClientNettingIdRequest(_portfolioId!, _nettingId!)
        {
        };
      }
    }
  }
}
