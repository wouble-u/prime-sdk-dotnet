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
  using System.Net;
  using CoinbaseSdk.Core.Client;
  using CoinbaseSdk.Core.Http;
  using CoinbaseSdk.Core.Service;

  public class BalancesService(ICoinbaseClient client) : CoinbaseService(client), IBalancesService
  {
    public GetWalletBalanceResponse GetWalletBalance(GetWalletBalanceRequest request, CallOptions? callOptions = null)
    {
      return Request<GetWalletBalanceResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/balance",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<GetWalletBalanceResponse> GetWalletBalanceAsync(
      GetWalletBalanceRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetWalletBalanceResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/balance",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public ListEntityBalancesResponse ListEntityBalances(ListEntityBalancesRequest request, CallOptions? callOptions = null)
    {
      return Request<ListEntityBalancesResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/balances",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<ListEntityBalancesResponse> ListEntityBalancesAsync(
      ListEntityBalancesRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListEntityBalancesResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/balances",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public ListOnchainWalletBalancesResponse ListOnchainWalletBalances(ListOnchainWalletBalancesRequest request, CallOptions? callOptions = null)
    {
      return Request<ListOnchainWalletBalancesResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/web3_balances",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<ListOnchainWalletBalancesResponse> ListOnchainWalletBalancesAsync(
      ListOnchainWalletBalancesRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListOnchainWalletBalancesResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/web3_balances",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public ListPortfolioBalancesResponse ListPortfolioBalances(ListPortfolioBalancesRequest request, CallOptions? callOptions = null)
    {
      return Request<ListPortfolioBalancesResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/balances",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<ListPortfolioBalancesResponse> ListPortfolioBalancesAsync(
      ListPortfolioBalancesRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListPortfolioBalancesResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/balances",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

  }
}
