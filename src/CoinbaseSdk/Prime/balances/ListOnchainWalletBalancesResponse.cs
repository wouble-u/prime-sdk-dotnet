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
  using CoinbaseSdk.Prime.Common;
  public class ListOnchainWalletBalancesResponse
  {
    public OnchainWalletBalance[] Balances { get; set; } = [];
    public Pagination? Pagination { get; set; }

    public ListOnchainWalletBalancesResponse() { }

    public class ListOnchainWalletBalancesResponseBuilder
    {
      private OnchainWalletBalance[] _balances = Array.Empty<OnchainWalletBalance>();
      private Pagination? _pagination;

      public ListOnchainWalletBalancesResponseBuilder WithBalances(OnchainWalletBalance[] balances)
      {
        this._balances = balances;
        return this;
      }

      public ListOnchainWalletBalancesResponseBuilder WithPagination(Pagination? pagination)
      {
        this._pagination = pagination;
        return this;
      }

      public ListOnchainWalletBalancesResponse Build()
      {
        return new ListOnchainWalletBalancesResponse
        {
          Balances = this._balances,
          Pagination = this._pagination
        };
      }
    }
  }
}
