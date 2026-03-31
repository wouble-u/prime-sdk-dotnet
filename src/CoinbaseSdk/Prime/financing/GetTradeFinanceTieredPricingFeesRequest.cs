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

namespace CoinbaseSdk.Prime.Financing
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;

  /// <summary>
  /// Get Trade Finance Tiered Pricing Fees
  /// Get trade finance tiered pricing fees for a given entity at a specific time, default to current time.
  /// </summary>
  public class GetTradeFinanceTieredPricingFeesRequest(string entityId)
  {
    /// <summary>
    /// The unique ID of the entity
    /// </summary>
    [JsonIgnore]
    public string EntityId { get; set; } = entityId;

    /// <summary>
    /// The fees on a specific effective date in RFC3339 format
    /// </summary>
    [JsonPropertyName("effective_at")]
    public string? EffectiveAt { get; set; }

    public class Builder
    {
      private string? _entityId;
      private string? _effectiveAt;

      /// <summary>
      /// The unique ID of the entity
      /// </summary>
      public Builder WithEntityId(string entityId)
      {
        _entityId = entityId;
        return this;
      }

      /// <summary>
      /// The fees on a specific effective date in RFC3339 format
      /// </summary>
      public Builder WithEffectiveAt(string? effectiveAt)
      {
        _effectiveAt = effectiveAt;
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
      /// Builds a new <see cref="GetTradeFinanceTieredPricingFeesRequest"/>.
      /// </summary>
      public GetTradeFinanceTieredPricingFeesRequest Build()
      {
        Validate();
        return new GetTradeFinanceTieredPricingFeesRequest(_entityId!)
        {
          EffectiveAt = _effectiveAt,
        };
      }
    }
  }
}
