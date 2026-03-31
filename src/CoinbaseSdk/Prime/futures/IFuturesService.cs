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

namespace CoinbaseSdk.Prime.Futures
{
  using CoinbaseSdk.Core.Http;

  public interface IFuturesService
  {
    public CancelEntityFuturesSweepResponse CancelEntityFuturesSweep(CancelEntityFuturesSweepRequest request, CallOptions? callOptions = null);

    public Task<CancelEntityFuturesSweepResponse> CancelEntityFuturesSweepAsync(
      CancelEntityFuturesSweepRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public GetFcmBalanceResponse GetFcmBalance(GetFcmBalanceRequest request, CallOptions? callOptions = null);

    public Task<GetFcmBalanceResponse> GetFcmBalanceAsync(
      GetFcmBalanceRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public GetFcmEquityResponse GetFcmEquity(GetFcmEquityRequest request, CallOptions? callOptions = null);

    public Task<GetFcmEquityResponse> GetFcmEquityAsync(
      GetFcmEquityRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public GetFcmMarginCallDetailsResponse GetFcmMarginCallDetails(GetFcmMarginCallDetailsRequest request, CallOptions? callOptions = null);

    public Task<GetFcmMarginCallDetailsResponse> GetFcmMarginCallDetailsAsync(
      GetFcmMarginCallDetailsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public GetFcmRiskLimitsResponse GetFcmRiskLimits(GetFcmRiskLimitsRequest request, CallOptions? callOptions = null);

    public Task<GetFcmRiskLimitsResponse> GetFcmRiskLimitsAsync(
      GetFcmRiskLimitsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public GetFcmSettingsResponse GetFcmSettings(GetFcmSettingsRequest request, CallOptions? callOptions = null);

    public Task<GetFcmSettingsResponse> GetFcmSettingsAsync(
      GetFcmSettingsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public GetPositionsResponse GetPositions(GetPositionsRequest request, CallOptions? callOptions = null);

    public Task<GetPositionsResponse> GetPositionsAsync(
      GetPositionsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public ListEntityFuturesSweepsResponse ListEntityFuturesSweeps(ListEntityFuturesSweepsRequest request, CallOptions? callOptions = null);

    public Task<ListEntityFuturesSweepsResponse> ListEntityFuturesSweepsAsync(
      ListEntityFuturesSweepsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public ScheduleEntityFuturesSweepResponse ScheduleEntityFuturesSweep(ScheduleEntityFuturesSweepRequest request, CallOptions? callOptions = null);

    public Task<ScheduleEntityFuturesSweepResponse> ScheduleEntityFuturesSweepAsync(
      ScheduleEntityFuturesSweepRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public SetAutoSweepResponse SetAutoSweep(SetAutoSweepRequest request, CallOptions? callOptions = null);

    public Task<SetAutoSweepResponse> SetAutoSweepAsync(
      SetAutoSweepRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public SetFcmSettingsResponse SetFcmSettings(SetFcmSettingsRequest request, CallOptions? callOptions = null);

    public Task<SetFcmSettingsResponse> SetFcmSettingsAsync(
      SetFcmSettingsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

  }
}
