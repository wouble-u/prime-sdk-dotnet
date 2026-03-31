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

namespace CoinbaseSdk.Prime.Portfolios
{
  using System.Net;
  using CoinbaseSdk.Core.Client;
  using CoinbaseSdk.Core.Http;
  using CoinbaseSdk.Core.Service;

  public class PortfoliosService(ICoinbaseClient client) : CoinbaseService(client), IPortfoliosService
  {
    public GetPortfolioResponse GetPortfolio(GetPortfolioRequest request, CallOptions? callOptions = null)
    {
      return Request<GetPortfolioResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<GetPortfolioResponse> GetPortfolioAsync(
      GetPortfolioRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetPortfolioResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public GetPortfolioCounterpartyResponse GetPortfolioCounterparty(GetPortfolioCounterpartyRequest request, CallOptions? callOptions = null)
    {
      return Request<GetPortfolioCounterpartyResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/counterparty",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<GetPortfolioCounterpartyResponse> GetPortfolioCounterpartyAsync(
      GetPortfolioCounterpartyRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetPortfolioCounterpartyResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/counterparty",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public ListPortfoliosResponse ListPortfolios(CallOptions? callOptions = null)
    {
      return Request<ListPortfoliosResponse>(
        HttpMethod.Get,
        $"/portfolios",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<ListPortfoliosResponse> ListPortfoliosAsync(
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListPortfoliosResponse>(
        HttpMethod.Get,
        $"/portfolios",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

  }
}
