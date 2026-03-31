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

namespace CoinbaseSdk.Prime.Staking
{
  using System.Net;
  using CoinbaseSdk.Core.Client;
  using CoinbaseSdk.Core.Http;
  using CoinbaseSdk.Core.Service;

  public class StakingService(ICoinbaseClient client) : CoinbaseService(client), IStakingService
  {
    /// <summary>
    /// Request to stake currency in a portfolio
    /// Creates an execution request to stake funds across a portfolio.  This will stake funds in one or more wallets in the portfolio, with a total bondable balance up to the requested stake amount.
    /// </summary>
    public CreatePortfolioStakeResponse CreatePortfolioStake(
      CreatePortfolioStakeRequest request,
      CallOptions? options = null)
    {
      return Request<CreatePortfolioStakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/staking/initiate",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Request to stake currency in a portfolio
    /// Creates an execution request to stake funds across a portfolio.  This will stake funds in one or more wallets in the portfolio, with a total bondable balance up to the requested stake amount.
    /// </summary>
    public Task<CreatePortfolioStakeResponse> CreatePortfolioStakeAsync(
      CreatePortfolioStakeRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreatePortfolioStakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/staking/initiate",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// List Transaction Validators
    /// List ETH 0x02 validators associated with wallet-level stake transactions for a given portfolio. It will not return data for unstake transactions, portfolio stake transactions, transactions which staked different currencies, or which staked to Ethereum 0x01 validators.
    /// </summary>
    public ListTransactionValidatorsResponse ListTransactionValidators(
      ListTransactionValidatorsRequest request,
      CallOptions? options = null)
    {
      return Request<ListTransactionValidatorsResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/staking/transaction-validators/query",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// List Transaction Validators
    /// List ETH 0x02 validators associated with wallet-level stake transactions for a given portfolio. It will not return data for unstake transactions, portfolio stake transactions, transactions which staked different currencies, or which staked to Ethereum 0x01 validators.
    /// </summary>
    public Task<ListTransactionValidatorsResponse> ListTransactionValidatorsAsync(
      ListTransactionValidatorsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListTransactionValidatorsResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/staking/transaction-validators/query",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Request to unstake currency across a portfolio
    /// Creates an execution request to unstake funds across a portfolio.  This will unstake funds in one or more wallets in the portfolio, with a total bonded balance up to the requested unstake amount.
    /// </summary>
    public CreatePortfolioUnstakeResponse CreatePortfolioUnstake(
      CreatePortfolioUnstakeRequest request,
      CallOptions? options = null)
    {
      return Request<CreatePortfolioUnstakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/staking/unstake",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Request to unstake currency across a portfolio
    /// Creates an execution request to unstake funds across a portfolio.  This will unstake funds in one or more wallets in the portfolio, with a total bonded balance up to the requested unstake amount.
    /// </summary>
    public Task<CreatePortfolioUnstakeResponse> CreatePortfolioUnstakeAsync(
      CreatePortfolioUnstakeRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreatePortfolioUnstakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/staking/unstake",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Claim Wallet Staking Rewards (Alpha)
    /// Request to claim staking rewards. This feature is in alpha. Please reach out to your Coinbase Prime account manager for more information
    /// </summary>
    public ClaimStakingRewardsResponse ClaimStakingRewards(
      ClaimStakingRewardsRequest request,
      CallOptions? options = null)
    {
      return Request<ClaimStakingRewardsResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/claim_rewards",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Claim Wallet Staking Rewards (Alpha)
    /// Request to claim staking rewards. This feature is in alpha. Please reach out to your Coinbase Prime account manager for more information
    /// </summary>
    public Task<ClaimStakingRewardsResponse> ClaimStakingRewardsAsync(
      ClaimStakingRewardsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ClaimStakingRewardsResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/claim_rewards",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Request to stake or delegate a wallet
    /// Creates an execution request to stake or delegate funds to a validator
    /// </summary>
    public CreateStakeResponse CreateStake(
      CreateStakeRequest request,
      CallOptions? options = null)
    {
      return Request<CreateStakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/initiate",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Request to stake or delegate a wallet
    /// Creates an execution request to stake or delegate funds to a validator
    /// </summary>
    public Task<CreateStakeResponse> CreateStakeAsync(
      CreateStakeRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateStakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/initiate",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Request to unstake a wallet
    /// Creates an execution request to unstake delegated or staked funds in a wallet
    /// </summary>
    public CreateUnstakeResponse CreateUnstake(
      CreateUnstakeRequest request,
      CallOptions? options = null)
    {
      return Request<CreateUnstakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/unstake",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Request to unstake a wallet
    /// Creates an execution request to unstake delegated or staked funds in a wallet
    /// </summary>
    public Task<CreateUnstakeResponse> CreateUnstakeAsync(
      CreateUnstakeRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateUnstakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/unstake",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get Staking Status
    /// Get staking status for a wallet. Returns estimated completion times for active staking requests.
    /// </summary>
    public GetStakingStatusResponse GetStakingStatus(
      GetStakingStatusRequest request,
      CallOptions? options = null)
    {
      return Request<GetStakingStatusResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/status",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// Get Staking Status
    /// Get staking status for a wallet. Returns estimated completion times for active staking requests.
    /// </summary>
    public Task<GetStakingStatusResponse> GetStakingStatusAsync(
      GetStakingStatusRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetStakingStatusResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/status",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get Unstaking Status
    /// Get unstaking estimates for a wallet. Returns estimated completion times for active unstaking requests.
    /// </summary>
    public GetUnstakingStatusResponse GetUnstakingStatus(
      GetUnstakingStatusRequest request,
      CallOptions? options = null)
    {
      return Request<GetUnstakingStatusResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/unstake/status",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// Get Unstaking Status
    /// Get unstaking estimates for a wallet. Returns estimated completion times for active unstaking requests.
    /// </summary>
    public Task<GetUnstakingStatusResponse> GetUnstakingStatusAsync(
      GetUnstakingStatusRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetUnstakingStatusResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/unstake/status",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Preview Unstake
    /// Previews an unstaking request with the given amount and returns the estimated amount that would be unstaked. This feature currently only supports ETH.
    /// </summary>
    public PreviewUnstakeResponse PreviewUnstake(
      PreviewUnstakeRequest request,
      CallOptions? options = null)
    {
      return Request<PreviewUnstakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/unstake/preview",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Preview Unstake
    /// Previews an unstaking request with the given amount and returns the estimated amount that would be unstaked. This feature currently only supports ETH.
    /// </summary>
    public Task<PreviewUnstakeResponse> PreviewUnstakeAsync(
      PreviewUnstakeRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<PreviewUnstakeResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/staking/unstake/preview",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

  }
}
