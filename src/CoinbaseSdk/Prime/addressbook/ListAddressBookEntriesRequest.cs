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

namespace CoinbaseSdk.Prime.AddressBook
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Common;
  using CoinbaseSdk.Prime.Model.Enums;

  /// <summary>
  /// Get Address Book
  /// Gets a list of address book addresses.
  /// </summary>
  public class ListAddressBookEntriesRequest(string portfolioId) : PaginatedRequest
  {
    /// <summary>
    /// Portfolio ID
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// Cryptocurrency symbol -- if nothing is passed, all addresses are returned
    /// </summary>
    [JsonPropertyName("currency_symbol")]
    public string? CurrencySymbol { get; set; }

    /// <summary>
    /// Query string that matches the address name
    /// </summary>
    [JsonPropertyName("search")]
    public string? Search { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _currencySymbol;
      private string? _search;
      private string? _cursor;
      private SortDirection? _sortDirection;
      private int? _limit;

      /// <summary>
      /// Portfolio ID
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// Cryptocurrency symbol -- if nothing is passed, all addresses are returned
      /// </summary>
      public Builder WithCurrencySymbol(string? currencySymbol)
      {
        _currencySymbol = currencySymbol;
        return this;
      }

      /// <summary>
      /// Query string that matches the address name
      /// </summary>
      public Builder WithSearch(string? search)
      {
        _search = search;
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
      /// Builds a new <see cref="ListAddressBookEntriesRequest"/>.
      /// </summary>
      public ListAddressBookEntriesRequest Build()
      {
        Validate();
        return new ListAddressBookEntriesRequest(_portfolioId!)
        {
          CurrencySymbol = _currencySymbol,
          Search = _search,
          Cursor = _cursor,
          SortDirection = _sortDirection,
          Limit = _limit,
        };
      }
    }
  }
}
