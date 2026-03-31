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

namespace CoinbaseSdk.Prime.Allocations
{
  using System.Net;
  using CoinbaseSdk.Core.Client;
  using CoinbaseSdk.Core.Http;
  using CoinbaseSdk.Core.Service;

  public class AllocationsService(ICoinbaseClient client) : CoinbaseService(client), IAllocationsService
  {
    public CreateAllocationResponse CreateAllocation(CreateAllocationRequest request, CallOptions? callOptions = null)
    {
      return Request<CreateAllocationResponse>(
        HttpMethod.Post,
        $"/allocations",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<CreateAllocationResponse> CreateAllocationAsync(
      CreateAllocationRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateAllocationResponse>(
        HttpMethod.Post,
        $"/allocations",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public CreateNetAllocationResponse CreateNetAllocation(CreateNetAllocationRequest request, CallOptions? callOptions = null)
    {
      return Request<CreateNetAllocationResponse>(
        HttpMethod.Post,
        $"/allocations/net",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<CreateNetAllocationResponse> CreateNetAllocationAsync(
      CreateNetAllocationRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateNetAllocationResponse>(
        HttpMethod.Post,
        $"/allocations/net",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public GetAllocationResponse GetAllocation(GetAllocationRequest request, CallOptions? callOptions = null)
    {
      return Request<GetAllocationResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/allocations/{request.AllocationId}",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<GetAllocationResponse> GetAllocationAsync(
      GetAllocationRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetAllocationResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/allocations/{request.AllocationId}",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public ListAllocationsByClientNettingIdResponse ListAllocationsByClientNettingId(ListAllocationsByClientNettingIdRequest request, CallOptions? callOptions = null)
    {
      return Request<ListAllocationsByClientNettingIdResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/allocations/net/{request.NettingId}",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<ListAllocationsByClientNettingIdResponse> ListAllocationsByClientNettingIdAsync(
      ListAllocationsByClientNettingIdRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListAllocationsByClientNettingIdResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/allocations/net/{request.NettingId}",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public ListPortfolioAllocationsResponse ListPortfolioAllocations(ListPortfolioAllocationsRequest request, CallOptions? callOptions = null)
    {
      return Request<ListPortfolioAllocationsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/allocations",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<ListPortfolioAllocationsResponse> ListPortfolioAllocationsAsync(
      ListPortfolioAllocationsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListPortfolioAllocationsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/allocations",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

  }
}
