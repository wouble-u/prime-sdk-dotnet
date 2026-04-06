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

namespace CoinbaseSdk.Prime.Transactions
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Common;
  using CoinbaseSdk.Prime.Model.Enums;

    /// <summary>
    /// List Portfolio Transactions.
    /// </summary>
  public class ListPortfolioTransactionsRequest(string portfolioId) : PaginatedRequest
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    [JsonPropertyName("symbols")]
    public string? Symbols { get; set; }

    [JsonPropertyName("types")]
    public string[] Types { get; set; } = [];

    [JsonPropertyName("start_time")]
    public string? StartTime { get; set; }

    [JsonPropertyName("end_time")]
    public string? EndTime { get; set; }

    [JsonPropertyName("get_network_unified_transactions")]
    public bool? GetNetworkUnifiedTransactions { get; set; }

    [JsonPropertyName("travel_rule_status")]
    public string[] TravelRuleStatus { get; set; } = [];

    public class ListPortfolioTransactionsRequestBuilder
    {
      private string? _portfolioId;
      private string? _symbols;
      private string[]? _types;
      private string? _startTime;
      private string? _endTime;
      private bool? _getNetworkUnifiedTransactions;
      private string[]? _travelRuleStatus;
      private string? _cursor;
      private SortDirection? _sortDirection;
      private int? _limit;

      public ListPortfolioTransactionsRequestBuilder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      public ListPortfolioTransactionsRequestBuilder WithSymbols(string? symbols)
      {
        _symbols = symbols;
        return this;
      }

      public ListPortfolioTransactionsRequestBuilder WithTypes(string[] types)
      {
        _types = types;
        return this;
      }

      public ListPortfolioTransactionsRequestBuilder WithStartTime(string? startTime)
      {
        _startTime = startTime;
        return this;
      }

      public ListPortfolioTransactionsRequestBuilder WithEndTime(string? endTime)
      {
        _endTime = endTime;
        return this;
      }

      public ListPortfolioTransactionsRequestBuilder WithGetNetworkUnifiedTransactions(bool? getNetworkUnifiedTransactions)
      {
        _getNetworkUnifiedTransactions = getNetworkUnifiedTransactions;
        return this;
      }

      public ListPortfolioTransactionsRequestBuilder WithTravelRuleStatus(string[] travelRuleStatus)
      {
        _travelRuleStatus = travelRuleStatus;
        return this;
      }

      public ListPortfolioTransactionsRequestBuilder WithCursor(string cursor)
      {
        _cursor = cursor;
        return this;
      }

      public ListPortfolioTransactionsRequestBuilder WithSortDirection(SortDirection sortDirection)
      {
        _sortDirection = sortDirection;
        return this;
      }

      public ListPortfolioTransactionsRequestBuilder WithLimit(int limit)
      {
        _limit = limit;
        return this;
      }

      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
      }

      public ListPortfolioTransactionsRequest Build()
      {
        Validate();
        return new ListPortfolioTransactionsRequest(_portfolioId!)
        {
          Symbols = _symbols,
          Types = _types ?? [],
          StartTime = _startTime,
          EndTime = _endTime,
          GetNetworkUnifiedTransactions = _getNetworkUnifiedTransactions,
          TravelRuleStatus = _travelRuleStatus ?? [],
          Cursor = _cursor,
          SortDirection = _sortDirection,
          Limit = _limit,
        };
      }
    }
  }
}
