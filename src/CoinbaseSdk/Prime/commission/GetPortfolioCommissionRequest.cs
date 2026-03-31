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

namespace CoinbaseSdk.Prime.Commission
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;

  /// <summary>
  /// Get Portfolio Commission
  /// Retrieve commission associated with a given portfolio.
  /// </summary>
  public class GetPortfolioCommissionRequest(string portfolioId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// Specific trading pair to check commission (e.g BTC-USD)
    /// </summary>
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _productId;

      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// Specific trading pair to check commission (e.g BTC-USD)
      /// </summary>
      public Builder WithProductId(string? productId)
      {
        _productId = productId;
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
      }

      /// <summary>
      /// Builds a new <see cref="GetPortfolioCommissionRequest"/>.
      /// </summary>
      public GetPortfolioCommissionRequest Build()
      {
        Validate();
        return new GetPortfolioCommissionRequest(_portfolioId!)
        {
          ProductId = _productId,
        };
      }
    }
  }
}
