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

namespace CoinbaseSdk.Prime.Staking
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Model.Enums;

  /// <summary>
  /// List Transaction Validators
  /// List ETH 0x02 validators associated with wallet-level stake transactions for a given portfolio. It will not return data for unstake transactions, portfolio stake transactions, transactions which staked different currencies, or which staked to Ethereum 0x01 validators.
  /// </summary>
  public class ListTransactionValidatorsRequest(string portfolioId)
  {
    /// <summary>
    /// The portfolio ID
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// List of transaction IDs to filter validators by. Maximum of 100 transaction IDs allowed per request.
    /// </summary>
    [JsonPropertyName("transaction_ids")]
    public string?[] TransactionIds { get; set; } = [];

    /// <summary>
    /// Cursor for pagination
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Maximum number of transaction-validator associations to return per page. Default is 100, maximum is 1000.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    [JsonPropertyName("sort_direction")]
    public SortDirection SortDirection { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string?[] _transactionIds;
      private string? _cursor;
      private int? _limit;
      private SortDirection _sortDirection;

      /// <summary>
      /// The portfolio ID
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// List of transaction IDs to filter validators by. Maximum of 100 transaction IDs allowed per request.
      /// </summary>
      public Builder WithTransactionIds(string?[] transactionIds)
      {
        _transactionIds = transactionIds;
        return this;
      }

      /// <summary>
      /// Cursor for pagination
      /// </summary>
      public Builder WithCursor(string? cursor)
      {
        _cursor = cursor;
        return this;
      }

      /// <summary>
      /// Maximum number of transaction-validator associations to return per page. Default is 100, maximum is 1000.
      /// </summary>
      public Builder WithLimit(int? limit)
      {
        _limit = limit;
        return this;
      }

      public Builder WithSortDirection(SortDirection sortDirection)
      {
        _sortDirection = sortDirection;
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
      /// Builds a new <see cref="ListTransactionValidatorsRequest"/>.
      /// </summary>
      public ListTransactionValidatorsRequest Build()
      {
        Validate();
        return new ListTransactionValidatorsRequest(_portfolioId!)
        {
          TransactionIds = _transactionIds,
          Cursor = _cursor,
          Limit = _limit,
          SortDirection = _sortDirection,
        };
      }
    }
  }
}
