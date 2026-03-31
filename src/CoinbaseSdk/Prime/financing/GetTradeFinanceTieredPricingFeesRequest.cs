/*
 * Copyright 2025-present Coinbase Global, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace CoinbaseSdk.Prime.Financing
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;

  public class GetTradeFinanceTieredPricingFeesRequest(string entityId)
  {
    [JsonIgnore]
    public string EntityId { get; set; } = entityId;
    [JsonPropertyName("effective_at")]
    public string? EffectiveAt { get; set; }

    public class Builder
    {
      private string? _entityId;
      private string? _effectiveAt;

      public Builder WithEntityId(string value)
      {
        _entityId = value;
        return this;
      }

      public Builder WithEffectiveAt(string? value)
      {
        _effectiveAt = value;
        return this;
      }

      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_entityId))
        {
          throw new CoinbaseClientException("EntityId is required");
        }
      }

      public GetTradeFinanceTieredPricingFeesRequest Build()
      {
        Validate();
        var request = new GetTradeFinanceTieredPricingFeesRequest(_entityId!)
        {
          EffectiveAt = _effectiveAt,
        };
        return request;
      }
    }
  }
}
