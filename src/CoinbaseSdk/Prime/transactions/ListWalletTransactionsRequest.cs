/*
 * Copyright 2024-present Coinbase Global, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace CoinbaseSdk.Prime.Transactions
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Common;
  using CoinbaseSdk.Prime.Model.Enums;

  public class ListWalletTransactionsRequest(string portfolioId, string walletId) : PaginatedRequest
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;
    [JsonIgnore]
    public string WalletId { get; set; } = walletId;
    [JsonPropertyName("types")]
    public string?[] Types { get; set; } = [];
    [JsonPropertyName("start_time")]
    public string? StartTime { get; set; }
    [JsonPropertyName("end_time")]
    public string? EndTime { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _walletId;
      private string?[]? _types;
      private string? _startTime;
      private string? _endTime;
      private string? _cursor;
      private SortDirection? _sortDirection;
      private int? _limit;

      public Builder WithPortfolioId(string value)
      {
        _portfolioId = value;
        return this;
      }

      public Builder WithWalletId(string value)
      {
        _walletId = value;
        return this;
      }

      public Builder WithTypes(string?[] value)
      {
        _types = value;
        return this;
      }

      public Builder WithStartTime(string? value)
      {
        _startTime = value;
        return this;
      }

      public Builder WithEndTime(string? value)
      {
        _endTime = value;
        return this;
      }

      public Builder WithCursor(string cursor)
      { _cursor = cursor; return this; }

      public Builder WithSortDirection(SortDirection sortDirection)
      { _sortDirection = sortDirection; return this; }

      public Builder WithLimit(int limit)
      { _limit = limit; return this; }

      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
        if (string.IsNullOrWhiteSpace(_walletId))
        {
          throw new CoinbaseClientException("WalletId is required");
        }
      }

      public ListWalletTransactionsRequest Build()
      {
        Validate();
        var request = new ListWalletTransactionsRequest(_portfolioId!, _walletId!)
        {
          Types = _types,
          StartTime = _startTime,
          EndTime = _endTime,
          Cursor = _cursor,
          SortDirection = _sortDirection,
          Limit = _limit,
        };
        return request;
      }
    }
  }
}
