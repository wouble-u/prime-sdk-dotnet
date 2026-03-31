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
  /// List Interest Accruals
  /// Lists interest accruals for an entity between the specified date range given
  /// </summary>
  public class ListInterestAccrualsRequest(string entityId)
  {
    /// <summary>
    /// The unique ID of the entity
    /// </summary>
    [JsonIgnore]
    public string EntityId { get; set; } = entityId;

    /// <summary>
    /// The unique ID of the portfolio
    /// </summary>
    [JsonPropertyName("portfolio_id")]
    public string? PortfolioId { get; set; }

    /// <summary>
    /// The start date of the range to query for in RFC3339 format
    /// </summary>
    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    /// <summary>
    /// The end date of the range to query for in RFC3339 format
    /// </summary>
    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    public class Builder
    {
      private string? _entityId;
      private string? _portfolioId;
      private string? _startDate;
      private string? _endDate;

      /// <summary>
      /// The unique ID of the entity
      /// </summary>
      public Builder WithEntityId(string entityId)
      {
        _entityId = entityId;
        return this;
      }

      /// <summary>
      /// The unique ID of the portfolio
      /// </summary>
      public Builder WithPortfolioId(string? portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// The start date of the range to query for in RFC3339 format
      /// </summary>
      public Builder WithStartDate(string? startDate)
      {
        _startDate = startDate;
        return this;
      }

      /// <summary>
      /// The end date of the range to query for in RFC3339 format
      /// </summary>
      public Builder WithEndDate(string? endDate)
      {
        _endDate = endDate;
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
      /// Builds a new <see cref="ListInterestAccrualsRequest"/>.
      /// </summary>
      public ListInterestAccrualsRequest Build()
      {
        Validate();
        return new ListInterestAccrualsRequest(_entityId!)
        {
          PortfolioId = _portfolioId,
          StartDate = _startDate,
          EndDate = _endDate,
        };
      }
    }
  }
}
