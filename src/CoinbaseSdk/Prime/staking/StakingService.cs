/*
 * Copyright 2025-present Coinbase Global, Inc.
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

namespace CoinbaseSdk.Prime.Staking
{
  using System.Net;
  using CoinbaseSdk.Core.Client;
  using CoinbaseSdk.Core.Http;
  using CoinbaseSdk.Core.Service;

  public class StakingService(ICoinbaseClient client) : CoinbaseService(client), IStakingService
  {
    public ClaimStakingRewardsResponse ClaimStakingRewards(ClaimStakingRewardsRequest request, CallOptions? callOptions = null)
    {
      return Request<ClaimStakingRewardsResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/claim_rewards",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<ClaimStakingRewardsResponse> ClaimStakingRewardsAsync(
      ClaimStakingRewardsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ClaimStakingRewardsResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/claim_rewards",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public CreatePortfolioStakeResponse CreatePortfolioStake(CreatePortfolioStakeRequest request, CallOptions? callOptions = null)
    {
      return Request<CreatePortfolioStakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/staking/initiate",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<CreatePortfolioStakeResponse> CreatePortfolioStakeAsync(
      CreatePortfolioStakeRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreatePortfolioStakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/staking/initiate",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public CreatePortfolioUnstakeResponse CreatePortfolioUnstake(CreatePortfolioUnstakeRequest request, CallOptions? callOptions = null)
    {
      return Request<CreatePortfolioUnstakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/staking/unstake",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<CreatePortfolioUnstakeResponse> CreatePortfolioUnstakeAsync(
      CreatePortfolioUnstakeRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreatePortfolioUnstakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/staking/unstake",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public CreateStakeResponse CreateStake(CreateStakeRequest request, CallOptions? callOptions = null)
    {
      return Request<CreateStakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/initiate",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<CreateStakeResponse> CreateStakeAsync(
      CreateStakeRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateStakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/initiate",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public CreateUnstakeResponse CreateUnstake(CreateUnstakeRequest request, CallOptions? callOptions = null)
    {
      return Request<CreateUnstakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/unstake",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<CreateUnstakeResponse> CreateUnstakeAsync(
      CreateUnstakeRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateUnstakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/unstake",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public GetStakingStatusResponse GetStakingStatus(GetStakingStatusRequest request, CallOptions? callOptions = null)
    {
      return Request<GetStakingStatusResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/status",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<GetStakingStatusResponse> GetStakingStatusAsync(
      GetStakingStatusRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetStakingStatusResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/status",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public GetUnstakingStatusResponse GetUnstakingStatus(GetUnstakingStatusRequest request, CallOptions? callOptions = null)
    {
      return Request<GetUnstakingStatusResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/unstake/status",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<GetUnstakingStatusResponse> GetUnstakingStatusAsync(
      GetUnstakingStatusRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetUnstakingStatusResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/unstake/status",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public ListTransactionValidatorsResponse ListTransactionValidators(ListTransactionValidatorsRequest request, CallOptions? callOptions = null)
    {
      return Request<ListTransactionValidatorsResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/staking/transaction-validators/query",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<ListTransactionValidatorsResponse> ListTransactionValidatorsAsync(
      ListTransactionValidatorsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListTransactionValidatorsResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/staking/transaction-validators/query",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public PreviewUnstakeResponse PreviewUnstake(PreviewUnstakeRequest request, CallOptions? callOptions = null)
    {
      return Request<PreviewUnstakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/unstake/preview",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<PreviewUnstakeResponse> PreviewUnstakeAsync(
      PreviewUnstakeRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<PreviewUnstakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/unstake/preview",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

  }
}
