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
  /// Get Entity Locate Availabilities
  /// Get currencies available to be located with their corresponding amount and rate.
  /// </summary>
  public class GetEntityLocateAvailabilitiesRequest(string entityId)
  {
    /// <summary>
    /// The unique ID of the entity
    /// </summary>
    [JsonIgnore]
    public string EntityId { get; set; } = entityId;

    /// <summary>
    /// Deprecated: Use locate_date instead
    /// </summary>
    [JsonPropertyName("conversion_date")]
    public string? ConversionDate { get; set; }

    /// <summary>
    /// The date of the locate availability in YYYY-MM-DD format
    /// </summary>
    [JsonPropertyName("locate_date")]
    public string? LocateDate { get; set; }

    public class Builder
    {
      private string? _entityId;
      private string? _conversionDate;
      private string? _locateDate;

      /// <summary>
      /// The unique ID of the entity
      /// </summary>
      public Builder WithEntityId(string entityId)
      {
        _entityId = entityId;
        return this;
      }

      /// <summary>
      /// Deprecated: Use locate_date instead
      /// </summary>
      public Builder WithConversionDate(string? conversionDate)
      {
        _conversionDate = conversionDate;
        return this;
      }

      /// <summary>
      /// The date of the locate availability in YYYY-MM-DD format
      /// </summary>
      public Builder WithLocateDate(string? locateDate)
      {
        _locateDate = locateDate;
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
      /// Builds a new <see cref="GetEntityLocateAvailabilitiesRequest"/>.
      /// </summary>
      public GetEntityLocateAvailabilitiesRequest Build()
      {
        Validate();
        return new GetEntityLocateAvailabilitiesRequest(_entityId!)
        {
          ConversionDate = _conversionDate,
          LocateDate = _locateDate,
        };
      }
    }
  }
}
