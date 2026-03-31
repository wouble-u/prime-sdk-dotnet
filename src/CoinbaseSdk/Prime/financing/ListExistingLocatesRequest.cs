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
  /// List Existing Locates
  /// List locates for the portfolio
  /// </summary>
  public class ListExistingLocatesRequest(string portfolioId)
  {
    /// <summary>
    /// The unique ID of the portfolio
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// The IDs of specific locates to filter for
    /// </summary>
    [JsonPropertyName("locate_ids")]
    public string?[] LocateIds { get; set; } = [];

    /// <summary>
    /// Deprecated: Use locate_date instead
    /// </summary>
    [JsonPropertyName("conversion_date")]
    public string? ConversionDate { get; set; }

    /// <summary>
    /// The date of the locates in YYYY-MM-DD format
    /// </summary>
    [JsonPropertyName("locate_date")]
    public string? LocateDate { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string?[]? _locateIds;
      private string? _conversionDate;
      private string? _locateDate;

      /// <summary>
      /// The unique ID of the portfolio
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// The IDs of specific locates to filter for
      /// </summary>
      public Builder WithLocateIds(string?[] locateIds)
      {
        _locateIds = locateIds;
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
      /// The date of the locates in YYYY-MM-DD format
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
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
      }

      /// <summary>
      /// Builds a new <see cref="ListExistingLocatesRequest"/>.
      /// </summary>
      public ListExistingLocatesRequest Build()
      {
        Validate();
        return new ListExistingLocatesRequest(_portfolioId!)
        {
          LocateIds = _locateIds,
          ConversionDate = _conversionDate,
          LocateDate = _locateDate,
        };
      }
    }
  }
}
