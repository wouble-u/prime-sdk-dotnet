/*
 * Copyright 2024-present Coinbase Global, Inc.
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

namespace CoinbaseSdk.Prime.Activities
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Common;
  using CoinbaseSdk.Prime.Model.Enums;

  /// <summary>
  /// List Activities
  /// List all activities associated with a given portfolio.
  /// </summary>
  public class ListActivitiesRequest(string portfolioId) : PaginatedRequest
  {
    /// <summary>
    /// Portfolio to retrieve activities for.
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// Filter by list of currencies
    /// </summary>
    [JsonPropertyName("symbols")]
    public string?[] Symbols { get; set; } = [];

    /// <summary>
    /// Filter by list of activity categories [order, transaction, account, allocation, lending]
    /// </summary>
    [JsonPropertyName("categories")]
    public ActivityCategory?[] Categories { get; set; } = [];

    /// <summary>
    /// Filter by list of statuses
    /// </summary>
    [JsonPropertyName("statuses")]
    public ActivityStatus?[] Statuses { get; set; } = [];

    /// <summary>
    /// Filter created time by start date (RFC3339 format)
    /// </summary>
    [JsonPropertyName("start_time")]
    public string? StartTime { get; set; }

    /// <summary>
    /// Filter created time by end date (RFC3339 format)
    /// </summary>
    [JsonPropertyName("end_time")]
    public string? EndTime { get; set; }

    /// <summary>
    /// Flag to request retrieval of all activities across all networks for a given symbol
    /// </summary>
    [JsonPropertyName("get_network_unified_activities")]
    public bool? GetNetworkUnifiedActivities { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string?[]? _symbols;
      private ActivityCategory?[]? _categories;
      private ActivityStatus?[]? _statuses;
      private string? _startTime;
      private string? _endTime;
      private bool? _getNetworkUnifiedActivities;
      private string? _cursor;
      private SortDirection? _sortDirection;
      private int? _limit;

      /// <summary>
      /// Portfolio to retrieve activities for.
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// Filter by list of currencies
      /// </summary>
      public Builder WithSymbols(string?[] symbols)
      {
        _symbols = symbols;
        return this;
      }

      /// <summary>
      /// Filter by list of activity categories [order, transaction, account, allocation, lending]
      /// </summary>
      public Builder WithCategories(ActivityCategory?[] categories)
      {
        _categories = categories;
        return this;
      }

      /// <summary>
      /// Filter by list of statuses
      /// </summary>
      public Builder WithStatuses(ActivityStatus?[] statuses)
      {
        _statuses = statuses;
        return this;
      }

      /// <summary>
      /// Filter created time by start date (RFC3339 format)
      /// </summary>
      public Builder WithStartTime(string? startTime)
      {
        _startTime = startTime;
        return this;
      }

      /// <summary>
      /// Filter created time by end date (RFC3339 format)
      /// </summary>
      public Builder WithEndTime(string? endTime)
      {
        _endTime = endTime;
        return this;
      }

      /// <summary>
      /// Flag to request retrieval of all activities across all networks for a given symbol
      /// </summary>
      public Builder WithGetNetworkUnifiedActivities(bool? getNetworkUnifiedActivities)
      {
        _getNetworkUnifiedActivities = getNetworkUnifiedActivities;
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
      /// Builds a new <see cref="ListActivitiesRequest"/>.
      /// </summary>
      public ListActivitiesRequest Build()
      {
        Validate();
        return new ListActivitiesRequest(_portfolioId!)
        {
          Symbols = _symbols,
          Categories = _categories,
          Statuses = _statuses,
          StartTime = _startTime,
          EndTime = _endTime,
          GetNetworkUnifiedActivities = _getNetworkUnifiedActivities,
          Cursor = _cursor,
          SortDirection = _sortDirection,
          Limit = _limit,
        };
      }
    }
  }
}
