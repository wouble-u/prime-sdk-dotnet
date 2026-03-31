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

namespace CoinbaseSdk.Prime.Futures
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;

  /// <summary>
  /// Get Entity Positions
  /// Retrieve all active fcm positions for a given entity.
  /// </summary>
  public class GetPositionsRequest(string entityId)
  {
    /// <summary>
    /// Entity ID
    /// </summary>
    [JsonIgnore]
    public string EntityId { get; set; } = entityId;

    /// <summary>
    /// Product ID. Optional
    /// </summary>
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    public class Builder
    {
      private string? _entityId;
      private string? _productId;

      /// <summary>
      /// Entity ID
      /// </summary>
      public Builder WithEntityId(string entityId)
      {
        _entityId = entityId;
        return this;
      }

      /// <summary>
      /// Product ID. Optional
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
        if (string.IsNullOrWhiteSpace(_entityId))
        {
          throw new CoinbaseClientException("EntityId is required");
        }
      }

      /// <summary>
      /// Builds a new <see cref="GetPositionsRequest"/>.
      /// </summary>
      public GetPositionsRequest Build()
      {
        Validate();
        return new GetPositionsRequest(_entityId!)
        {
          ProductId = _productId,
        };
      }
    }
  }
}
