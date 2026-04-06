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
  using CoinbaseSdk.Core.Http;

  public interface IBalancesService
  {
    /// <summary>
    /// List Entity Balances.
    /// </summary>
    public ListEntityBalancesResponse ListEntityBalances(
      ListEntityBalancesRequest request,
      CallOptions? options = null);

    public Task<ListEntityBalancesResponse> ListEntityBalancesAsync(
      ListEntityBalancesRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// List Portfolio Balances.
    /// </summary>
    public ListPortfolioBalancesResponse ListPortfolioBalances(
      ListPortfolioBalancesRequest request,
      CallOptions? options = null);

    public Task<ListPortfolioBalancesResponse> ListPortfolioBalancesAsync(
      ListPortfolioBalancesRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Wallet Balance.
    /// </summary>
    public GetWalletBalanceResponse GetWalletBalance(
      GetWalletBalanceRequest request,
      CallOptions? options = null);

    public Task<GetWalletBalanceResponse> GetWalletBalanceAsync(
      GetWalletBalanceRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// List Onchain Wallet Balances.
    /// </summary>
    public ListOnchainWalletBalancesResponse ListOnchainWalletBalances(
      ListOnchainWalletBalancesRequest request,
      CallOptions? options = null);

    public Task<ListOnchainWalletBalancesResponse> ListOnchainWalletBalancesAsync(
      ListOnchainWalletBalancesRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);
  }
}
