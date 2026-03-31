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

namespace CoinbaseSdk.Prime.Orders
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Common;
  using CoinbaseSdk.Prime.Model.Enums;

  /// <summary>
  /// List Portfolio Fills
  /// Retrieve fills on a given portfolio. This endpoint requires a start_date, and returns a payload with a default limit of 100 if not specified by the user. The maximum allowed limit is 3000.
  /// </summary>
  public class ListPortfolioFillsRequest(string portfolioId) : PaginatedRequest
  {
    /// <summary>
    /// The portfolio ID associated with the order
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// A start date for the fills to be queried from
    /// </summary>
    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    /// <summary>
    /// An end date for the fills to be queried until
    /// </summary>
    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _startDate;
      private string? _endDate;
      private string? _cursor;
      private SortDirection? _sortDirection;
      private int? _limit;

      /// <summary>
      /// The portfolio ID associated with the order
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// A start date for the fills to be queried from
      /// </summary>
      public Builder WithStartDate(string? startDate)
      {
        _startDate = startDate;
        return this;
      }

      /// <summary>
      /// An end date for the fills to be queried until
      /// </summary>
      public Builder WithEndDate(string? endDate)
      {
        _endDate = endDate;
        return this;
      }

      public Builder WithCursor(string cursor)
      {
        _cursor = cursor;
        return this;
      }

      public Builder WithSortDirection(SortDirection sortDirection)
      {
        _sortDirection = sortDirection;
        return this;
      }

      public Builder WithLimit(int limit)
      {
        _limit = limit;
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
      /// Builds a new <see cref="ListPortfolioFillsRequest"/>.
      /// </summary>
      public ListPortfolioFillsRequest Build()
      {
        Validate();
        return new ListPortfolioFillsRequest(_portfolioId!)
        {
          StartDate = _startDate,
          EndDate = _endDate,
          Cursor = _cursor,
          SortDirection = _sortDirection,
          Limit = _limit,
        };
      }
    }
  }
}
