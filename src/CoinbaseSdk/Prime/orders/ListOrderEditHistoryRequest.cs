/*
 * Copyright 2025-present Coinbase Global, Inc.
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

namespace CoinbaseSdk.Prime.Orders
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;

  /// <summary>
  /// List Order Edit History
  /// List edit history for a specific order
  /// </summary>
  public class ListOrderEditHistoryRequest(string portfolioId, string orderId)
  {
    /// <summary>
    /// The portfolio ID
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// The order ID
    /// </summary>
    [JsonIgnore]
    public string OrderId { get; set; } = orderId;

    public class Builder
    {
      private string? _portfolioId;
      private string? _orderId;

      /// <summary>
      /// The portfolio ID
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// The order ID
      /// </summary>
      public Builder WithOrderId(string orderId)
      {
        _orderId = orderId;
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
        if (string.IsNullOrWhiteSpace(_orderId))
        {
          throw new CoinbaseClientException("OrderId is required");
        }
      }

      /// <summary>
      /// Builds a new <see cref="ListOrderEditHistoryRequest"/>.
      /// </summary>
      public ListOrderEditHistoryRequest Build()
      {
        Validate();
        return new ListOrderEditHistoryRequest(_portfolioId!, _orderId!)
        {
        };
      }
    }
  }
}
