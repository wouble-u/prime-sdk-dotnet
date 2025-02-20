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

namespace CoinbaseSdk.Prime.Balances
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Common;
  using CoinbaseSdk.Prime.Model;

  public class ListOnchainWalletBalancesRequest(string portfolioId, string walletId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    [JsonIgnore]
    public string WalletId { get; set; } = walletId;

    [JsonPropertyName("visibility_statuses")]
    public VisibilityStatus[] VisibilityStatuses { get; set; } = [];

    public string? Cursor { get; set; }

    public int? Limit { get; set; }

    public class ListOnchainWalletBalancesRequestBuilder
    {
      private string? _portfolioId;
      private string? _walletId;
      private VisibilityStatus[] _visibilityStatuses = [];
      private string? _cursor;
      private int? _limit;

      public ListOnchainWalletBalancesRequestBuilder WithPortfolioId(string portfolioId)
      {
        this._portfolioId = portfolioId;
        return this;
      }

      public ListOnchainWalletBalancesRequestBuilder WithWalletId(string walletId)
      {
        this._walletId = walletId;
        return this;
      }

      public ListOnchainWalletBalancesRequestBuilder WithVisibilityStatuses(VisibilityStatus[] visibilityStatuses)
      {
        this._visibilityStatuses = visibilityStatuses;
        return this;
      }

      public ListOnchainWalletBalancesRequestBuilder WithCursor(string cursor)
      {
        this._cursor = cursor;
        return this;
      }

      public ListOnchainWalletBalancesRequestBuilder WithLimit(int limit)
      {
        this._limit = limit;
        return this;
      }

      public ListOnchainWalletBalancesRequestBuilder WithPagination(Pagination pagination)
      {
        this._cursor = pagination.NextCursor;
        return this;
      }

      /// <summary>
      /// Validate the builder.
      /// </summary>
      /// <exception cref="CoinbaseClientException">Thrown when the
      /// <see cref="_portfolioId"/> or <see cref="_walletId"/> are null, empty
      /// or whitespace.</exception>
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
      /// Build the <see cref="ListOnchainWalletBalancesRequest"/>.
      /// </summary>
      /// <returns>The <see cref="ListOnchainWalletBalancesRequest"/>.</returns>
      /// <exception cref="CoinbaseClientException">Thrown when the required fields are not set.</exception>
      public ListOnchainWalletBalancesRequest Build()
      {
        Validate();
        return new ListOnchainWalletBalancesRequest(_portfolioId!, this._walletId!)
        {
          VisibilityStatuses = this._visibilityStatuses,
          Cursor = this._cursor,
          Limit = this._limit
        };
      }
    }
  }
}
