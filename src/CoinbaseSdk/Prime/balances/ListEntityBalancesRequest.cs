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
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Common;
  using CoinbaseSdk.Prime.Model.Enums;

  /// <summary>
  /// List Entity Balances
  /// List all balances for a specific entity.
  /// </summary>
  public class ListEntityBalancesRequest(string entityId) : PaginatedRequest
  {
    /// <summary>
    /// The entity ID
    /// </summary>
    [JsonIgnore]
    public string EntityId { get; set; } = entityId;

    /// <summary>
    /// A list of symbols by which to filter the response
    /// </summary>
    [JsonPropertyName("symbols")]
    public string? Symbols { get; set; }

    /// <summary>
    /// A type by which to filter aggregated balances, defaults to "TOTAL"
    /// - UNKNOWN_BALANCE_TYPE: nil
    /// - TRADING_BALANCES: Trading balances
    /// - VAULT_BALANCES: Vault balances
    /// - TOTAL_BALANCES: Total balances (The sum of vault and trading + prime custody)
    /// - PRIME_CUSTODY_BALANCES: Prime custody balances
    /// - UNIFIED_TOTAL_BALANCES: Unified total balance across networks and wallet types (vault + trading + prime custody)
    /// </summary>
    [JsonPropertyName("aggregation_type")]
    public string? AggregationType { get; set; }

    public class Builder
    {
      private string? _entityId;
      private string? _symbols;
      private string? _aggregationType;
      private string? _cursor;
      private SortDirection? _sortDirection;
      private int? _limit;

      /// <summary>
      /// The entity ID
      /// </summary>
      public Builder WithEntityId(string entityId)
      {
        _entityId = entityId;
        return this;
      }

      /// <summary>
      /// A list of symbols by which to filter the response
      /// </summary>
      public Builder WithSymbols(string? symbols)
      {
        _symbols = symbols;
        return this;
      }

      /// <summary>
      /// A type by which to filter aggregated balances, defaults to "TOTAL"
      /// - UNKNOWN_BALANCE_TYPE: nil
      /// - TRADING_BALANCES: Trading balances
      /// - VAULT_BALANCES: Vault balances
      /// - TOTAL_BALANCES: Total balances (The sum of vault and trading + prime custody)
      /// - PRIME_CUSTODY_BALANCES: Prime custody balances
      /// - UNIFIED_TOTAL_BALANCES: Unified total balance across networks and wallet types (vault + trading + prime custody)
      /// </summary>
      public Builder WithAggregationType(string? aggregationType)
      {
        _aggregationType = aggregationType;
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
        if (string.IsNullOrWhiteSpace(_entityId))
        {
          throw new CoinbaseClientException("EntityId is required");
        }
      }

      /// <summary>
      /// Builds a new <see cref="ListEntityBalancesRequest"/>.
      /// </summary>
      public ListEntityBalancesRequest Build()
      {
        Validate();
        return new ListEntityBalancesRequest(_entityId!)
        {
          Symbols = _symbols,
          AggregationType = _aggregationType,
          Cursor = _cursor,
          SortDirection = _sortDirection,
          Limit = _limit,
        };
      }
    }
  }
}
