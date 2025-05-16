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

namespace CoinbaseSdk.Prime.Balances
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Prime.Model;

  public class ListEntityBalancesRequest(string entityId)
  {
    [JsonIgnore]
    public string EntityId { get; set; } = entityId;

    public string? Symbol { get; set; }

    public string? Cursor { get; set; }

    [JsonPropertyName("sort_direction")]
    public string? SortDirection { get; set; }

    public int? Limit { get; set; }

    [JsonPropertyName("aggregation_type")]
    public BalanceType? AggregationType { get; set; }

    public class ListEntityBalancesRequestBuilder(string entityId)
    {
      private string _entityId = entityId;
      private string? _symbol;
      private string? _cursor;
      private string? _sortDirection;
      private int? _limit;
      private BalanceType? _aggregationType;

      public ListEntityBalancesRequestBuilder WithSymbol(string? symbol)
      {
        this._symbol = symbol;
        return this;
      }

      public ListEntityBalancesRequestBuilder WithCursor(string? cursor)
      {
        this._cursor = cursor;
        return this;
      }

      public ListEntityBalancesRequestBuilder WithSortDirection(string? sortDirection)
      {
        this._sortDirection = sortDirection;
        return this;
      }

      public ListEntityBalancesRequestBuilder WithLimit(int? limit)
      {
        this._limit = limit;
        return this;
      }

      public ListEntityBalancesRequestBuilder WithAggregationType(BalanceType? aggregationType)
      {
        this._aggregationType = aggregationType;
        return this;
      }

      public ListEntityBalancesRequestBuilder WithPagination(Pagination pagination)
      {
        this._cursor = pagination.NextCursor;
        this._sortDirection = pagination.SortDirection;
        return this;
      }

      public ListEntityBalancesRequest Build()
      {
        return new ListEntityBalancesRequest(this._entityId)
        {
          Symbol = this._symbol,
          Cursor = this._cursor,
          SortDirection = this._sortDirection,
          Limit = this._limit,
          AggregationType = this._aggregationType
        };
      }
    }
  }
}