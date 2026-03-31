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
  /// Schedule Entity Futures Sweep
  /// Schedule a sweep for a given entity from FCM wallet to USD Spot wallet. Only one pending sweep is allowed at a time per entity.
  /// </summary>
  public class ScheduleEntityFuturesSweepRequest(string entityId)
  {
    /// <summary>
    /// Entity ID
    /// </summary>
    [JsonIgnore]
    public string EntityId { get; set; } = entityId;

    /// <summary>
    /// Amount. Default to sweep all if not provided
    /// </summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>
    /// Currency. Required
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    public class Builder
    {
      private string? _entityId;
      private string? _amount;
      private string? _currency;

      /// <summary>
      /// Entity ID
      /// </summary>
      public Builder WithEntityId(string entityId)
      {
        _entityId = entityId;
        return this;
      }

      /// <summary>
      /// Amount. Default to sweep all if not provided
      /// </summary>
      public Builder WithAmount(string? amount)
      {
        _amount = amount;
        return this;
      }

      /// <summary>
      /// Currency. Required
      /// </summary>
      public Builder WithCurrency(string? currency)
      {
        _currency = currency;
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
      /// Builds a new <see cref="ScheduleEntityFuturesSweepRequest"/>.
      /// </summary>
      public ScheduleEntityFuturesSweepRequest Build()
      {
        Validate();
        return new ScheduleEntityFuturesSweepRequest(_entityId!)
        {
          Amount = _amount,
          Currency = _currency,
        };
      }
    }
  }
}
