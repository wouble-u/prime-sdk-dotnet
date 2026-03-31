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
  /// Get Allocation by ID
  /// Retrieve an allocation by allocation ID.
  /// </summary>
  public class GetAllocationRequest(string portfolioId, string allocationId)
  {
    /// <summary>
    /// The portfolio ID of the allocation
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// The ID of the allocation
    /// </summary>
    [JsonIgnore]
    public string AllocationId { get; set; } = allocationId;

    public class Builder
    {
      private string? _portfolioId;
      private string? _allocationId;

      /// <summary>
      /// The portfolio ID of the allocation
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// The ID of the allocation
      /// </summary>
      public Builder WithAllocationId(string allocationId)
      {
        _allocationId = allocationId;
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
        if (string.IsNullOrWhiteSpace(_allocationId))
        {
          throw new CoinbaseClientException("AllocationId is required");
        }
      }

      /// <summary>
      /// Builds a new <see cref="GetAllocationRequest"/>.
      /// </summary>
      public GetAllocationRequest Build()
      {
        Validate();
        return new GetAllocationRequest(_portfolioId!, _allocationId!)
        {
        };
      }
    }
  }
}
