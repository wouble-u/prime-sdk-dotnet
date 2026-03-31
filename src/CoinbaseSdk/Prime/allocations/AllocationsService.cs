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

namespace CoinbaseSdk.Prime.Allocations
{
  using System.Net;
  using CoinbaseSdk.Core.Client;
  using CoinbaseSdk.Core.Http;
  using CoinbaseSdk.Core.Service;

  public class AllocationsService(ICoinbaseClient client) : CoinbaseService(client), IAllocationsService
  {
    /// <summary>
    /// Create Portfolio Allocations
    /// Create allocation for a given portfolio.
    /// </summary>
    public CreateAllocationResponse CreateAllocation(
      CreateAllocationRequest request,
      CallOptions? options = null)
    {
      return Request<CreateAllocationResponse>(
        HttpMethod.Post,
        $"/allocations",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Create Portfolio Allocations
    /// Create allocation for a given portfolio.
    /// </summary>
    public Task<CreateAllocationResponse> CreateAllocationAsync(
      CreateAllocationRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateAllocationResponse>(
        HttpMethod.Post,
        $"/allocations",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Create Portfolio Net Allocations
    /// Create net allocation for a given portfolio.
    /// </summary>
    public CreateNetAllocationResponse CreateNetAllocation(
      CreateNetAllocationRequest request,
      CallOptions? options = null)
    {
      return Request<CreateNetAllocationResponse>(
        HttpMethod.Post,
        $"/allocations/net",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Create Portfolio Net Allocations
    /// Create net allocation for a given portfolio.
    /// </summary>
    public Task<CreateNetAllocationResponse> CreateNetAllocationAsync(
      CreateNetAllocationRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateNetAllocationResponse>(
        HttpMethod.Post,
        $"/allocations/net",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// List Portfolio Allocations
    /// List historical allocations for a given portfolio.
    /// </summary>
    public ListPortfolioAllocationsResponse ListPortfolioAllocations(
      ListPortfolioAllocationsRequest request,
      CallOptions? options = null)
    {
      return Request<ListPortfolioAllocationsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/allocations",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// List Portfolio Allocations
    /// List historical allocations for a given portfolio.
    /// </summary>
    public Task<ListPortfolioAllocationsResponse> ListPortfolioAllocationsAsync(
      ListPortfolioAllocationsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListPortfolioAllocationsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/allocations",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get Net Allocations by Netting ID
    /// Retrieve an allocation by netting ID.
    /// </summary>
    public ListAllocationsByClientNettingIdResponse ListAllocationsByClientNettingId(
      ListAllocationsByClientNettingIdRequest request,
      CallOptions? options = null)
    {
      return Request<ListAllocationsByClientNettingIdResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/allocations/net/{request.NettingId}",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// Get Net Allocations by Netting ID
    /// Retrieve an allocation by netting ID.
    /// </summary>
    public Task<ListAllocationsByClientNettingIdResponse> ListAllocationsByClientNettingIdAsync(
      ListAllocationsByClientNettingIdRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListAllocationsByClientNettingIdResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/allocations/net/{request.NettingId}",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get Allocation by ID
    /// Retrieve an allocation by allocation ID.
    /// </summary>
    public GetAllocationResponse GetAllocation(
      GetAllocationRequest request,
      CallOptions? options = null)
    {
      return Request<GetAllocationResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/allocations/{request.AllocationId}",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// Get Allocation by ID
    /// Retrieve an allocation by allocation ID.
    /// </summary>
    public Task<GetAllocationResponse> GetAllocationAsync(
      GetAllocationRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetAllocationResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/allocations/{request.AllocationId}",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

  }
}
