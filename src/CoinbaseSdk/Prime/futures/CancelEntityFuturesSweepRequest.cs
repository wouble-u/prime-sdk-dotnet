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
  /// Cancel Entity Futures Sweep
  /// Cancel the pending sweep for a given entity. A user will only be able to have one pending sweep at a time. If the sweep is not found, a 404 will be returned.
  /// </summary>
  public class CancelEntityFuturesSweepRequest(string entityId)
  {
    /// <summary>
    /// Entity ID
    /// </summary>
    [JsonIgnore]
    public string EntityId { get; set; } = entityId;

    public class Builder
    {
      private string? _entityId;

      /// <summary>
      /// Entity ID
      /// </summary>
      public Builder WithEntityId(string entityId)
      {
        _entityId = entityId;
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
      /// Builds a new <see cref="CancelEntityFuturesSweepRequest"/>.
      /// </summary>
      public CancelEntityFuturesSweepRequest Build()
      {
        Validate();
        return new CancelEntityFuturesSweepRequest(_entityId!)
        {
        };
      }
    }
  }
}
