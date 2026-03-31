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

namespace CoinbaseSdk.Prime.Wallets
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Common;
  using CoinbaseSdk.Prime.Model.Enums;

  /// <summary>
  /// List Wallet Addresses
  /// Returns all deposit addresses associated with a wallet
  /// </summary>
  public class ListWalletAddressesRequest(string portfolioId, string walletId) : PaginatedRequest
  {
    /// <summary>
    /// The portfolio ID associated with the wallet
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// The wallet ID for which to retrieve all deposit addresses
    /// </summary>
    [JsonIgnore]
    public string WalletId { get; set; } = walletId;

    /// <summary>
    /// The blockchain network name and type, provide an empty network to retrieve addresses across all networks for this wallet
    /// </summary>
    [JsonPropertyName("network_id")]
    public string? NetworkId { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _walletId;
      private string? _networkId;
      private string? _cursor;
      private SortDirection? _sortDirection;
      private int? _limit;

      /// <summary>
      /// The portfolio ID associated with the wallet
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// The wallet ID for which to retrieve all deposit addresses
      /// </summary>
      public Builder WithWalletId(string walletId)
      {
        _walletId = walletId;
        return this;
      }

      /// <summary>
      /// The blockchain network name and type, provide an empty network to retrieve addresses across all networks for this wallet
      /// </summary>
      public Builder WithNetworkId(string? networkId)
      {
        _networkId = networkId;
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
        if (string.IsNullOrWhiteSpace(_walletId))
        {
          throw new CoinbaseClientException("WalletId is required");
        }
      }

      /// <summary>
      /// Builds a new <see cref="ListWalletAddressesRequest"/>.
      /// </summary>
      public ListWalletAddressesRequest Build()
      {
        Validate();
        return new ListWalletAddressesRequest(_portfolioId!, _walletId!)
        {
          NetworkId = _networkId,
          Cursor = _cursor,
          SortDirection = _sortDirection,
          Limit = _limit,
        };
      }
    }
  }
}
