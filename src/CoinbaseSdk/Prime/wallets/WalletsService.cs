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

namespace CoinbaseSdk.Prime.Wallets
{
  using System.Net;
  using CoinbaseSdk.Core.Client;
  using CoinbaseSdk.Core.Http;
  using CoinbaseSdk.Core.Service;

  public class WalletsService(ICoinbaseClient client) : CoinbaseService(client), IWalletsService
  {
    public CreateWalletResponse CreateWallet(CreateWalletRequest request, CallOptions? callOptions = null)
    {
      return Request<CreateWalletResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<CreateWalletResponse> CreateWalletAsync(
      CreateWalletRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateWalletResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public CreateWalletDepositAddressResponse CreateWalletDepositAddress(CreateWalletDepositAddressRequest request, CallOptions? callOptions = null)
    {
      return Request<CreateWalletDepositAddressResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/addresses",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<CreateWalletDepositAddressResponse> CreateWalletDepositAddressAsync(
      CreateWalletDepositAddressRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateWalletDepositAddressResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/addresses",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public GetWalletResponse GetWallet(GetWalletRequest request, CallOptions? callOptions = null)
    {
      return Request<GetWalletResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<GetWalletResponse> GetWalletAsync(
      GetWalletRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetWalletResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public GetWalletDepositInstructionsResponse GetWalletDepositInstructions(GetWalletDepositInstructionsRequest request, CallOptions? callOptions = null)
    {
      return Request<GetWalletDepositInstructionsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/deposit_instructions",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<GetWalletDepositInstructionsResponse> GetWalletDepositInstructionsAsync(
      GetWalletDepositInstructionsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetWalletDepositInstructionsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/deposit_instructions",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public ListWalletAddressesResponse ListWalletAddresses(ListWalletAddressesRequest request, CallOptions? callOptions = null)
    {
      return Request<ListWalletAddressesResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/addresses",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<ListWalletAddressesResponse> ListWalletAddressesAsync(
      ListWalletAddressesRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListWalletAddressesResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/addresses",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public ListWalletsResponse ListWallets(ListWalletsRequest request, CallOptions? callOptions = null)
    {
      return Request<ListWalletsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<ListWalletsResponse> ListWalletsAsync(
      ListWalletsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListWalletsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

  }
}
