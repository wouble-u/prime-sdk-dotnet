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
  using CoinbaseSdk.Core.Http;

  public interface IStakingService
  {
    public ClaimStakingRewardsResponse ClaimStakingRewards(ClaimStakingRewardsRequest request, CallOptions? callOptions = null);

    public Task<ClaimStakingRewardsResponse> ClaimStakingRewardsAsync(
      ClaimStakingRewardsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public CreatePortfolioStakeResponse CreatePortfolioStake(CreatePortfolioStakeRequest request, CallOptions? callOptions = null);

    public Task<CreatePortfolioStakeResponse> CreatePortfolioStakeAsync(
      CreatePortfolioStakeRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public CreatePortfolioUnstakeResponse CreatePortfolioUnstake(CreatePortfolioUnstakeRequest request, CallOptions? callOptions = null);

    public Task<CreatePortfolioUnstakeResponse> CreatePortfolioUnstakeAsync(
      CreatePortfolioUnstakeRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public CreateStakeResponse CreateStake(CreateStakeRequest request, CallOptions? callOptions = null);

    public Task<CreateStakeResponse> CreateStakeAsync(
      CreateStakeRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public CreateUnstakeResponse CreateUnstake(CreateUnstakeRequest request, CallOptions? callOptions = null);

    public Task<CreateUnstakeResponse> CreateUnstakeAsync(
      CreateUnstakeRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public GetStakingStatusResponse GetStakingStatus(GetStakingStatusRequest request, CallOptions? callOptions = null);

    public Task<GetStakingStatusResponse> GetStakingStatusAsync(
      GetStakingStatusRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public GetUnstakingStatusResponse GetUnstakingStatus(GetUnstakingStatusRequest request, CallOptions? callOptions = null);

    public Task<GetUnstakingStatusResponse> GetUnstakingStatusAsync(
      GetUnstakingStatusRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public ListTransactionValidatorsResponse ListTransactionValidators(ListTransactionValidatorsRequest request, CallOptions? callOptions = null);

    public Task<ListTransactionValidatorsResponse> ListTransactionValidatorsAsync(
      ListTransactionValidatorsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public PreviewUnstakeResponse PreviewUnstake(PreviewUnstakeRequest request, CallOptions? callOptions = null);

    public Task<PreviewUnstakeResponse> PreviewUnstakeAsync(
      PreviewUnstakeRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

  }
}
