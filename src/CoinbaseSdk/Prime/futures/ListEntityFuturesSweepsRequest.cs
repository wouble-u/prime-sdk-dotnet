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
  /// List Entity Futures Sweeps
  /// Retrieve fcm sweeps in open status, including pending and processing sweeps.
  /// </summary>
  public class ListEntityFuturesSweepsRequest(string entityId)
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
      /// Builds a new <see cref="ListEntityFuturesSweepsRequest"/>.
      /// </summary>
      public ListEntityFuturesSweepsRequest Build()
      {
        Validate();
        return new ListEntityFuturesSweepsRequest(_entityId!)
        {
        };
      }
    }
  }
}
