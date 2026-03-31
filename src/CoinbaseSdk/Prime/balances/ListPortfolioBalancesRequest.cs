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

namespace CoinbaseSdk.Prime.Balances
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Common;
  using CoinbaseSdk.Prime.Model.Enums;

  /// <summary>
  /// List Portfolio Balances
  /// List all balances for a specific portfolio.
  /// </summary>
  public class ListPortfolioBalancesRequest(string portfolioId) : PaginatedRequest
  {
    /// <summary>
    /// The portfolio ID
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// A list of symbols by which to filter the response
    /// </summary>
    [JsonPropertyName("symbols")]
    public string[] Symbols { get; set; } = [];

    /// <summary>
    /// A type by which to filter balances
    /// - UNKNOWN_BALANCE_TYPE: nil
    /// - TRADING_BALANCES: Trading balances
    /// - VAULT_BALANCES: Vault balances
    /// - TOTAL_BALANCES: Total balances (The sum of vault and trading + prime custody)
    /// - PRIME_CUSTODY_BALANCES: Prime custody balances
    /// - UNIFIED_TOTAL_BALANCES: Unified total balance across networks and wallet types (vault + trading + prime custody)
    /// </summary>
    [JsonPropertyName("balance_type")]
    public PortfolioBalanceType? BalanceType { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string[]? _symbols;
      private PortfolioBalanceType? _balanceType;
      private string? _cursor;
      private SortDirection? _sortDirection;
      private int? _limit;

      /// <summary>
      /// The portfolio ID
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// A list of symbols by which to filter the response
      /// </summary>
      public Builder WithSymbols(string[] symbols)
      {
        _symbols = symbols;
        return this;
      }

      /// <summary>
      /// A type by which to filter balances
      /// - UNKNOWN_BALANCE_TYPE: nil
      /// - TRADING_BALANCES: Trading balances
      /// - VAULT_BALANCES: Vault balances
      /// - TOTAL_BALANCES: Total balances (The sum of vault and trading + prime custody)
      /// - PRIME_CUSTODY_BALANCES: Prime custody balances
      /// - UNIFIED_TOTAL_BALANCES: Unified total balance across networks and wallet types (vault + trading + prime custody)
      /// </summary>
      public Builder WithBalanceType(PortfolioBalanceType? balanceType)
      {
        _balanceType = balanceType;
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
      /// Builds a new <see cref="ListPortfolioBalancesRequest"/>.
      /// </summary>
      public ListPortfolioBalancesRequest Build()
      {
        Validate();
        return new ListPortfolioBalancesRequest(_portfolioId!)
        {
          Symbols = _symbols,
          BalanceType = _balanceType,
          Cursor = _cursor,
          SortDirection = _sortDirection,
          Limit = _limit,
        };
      }
    }
  }
}
