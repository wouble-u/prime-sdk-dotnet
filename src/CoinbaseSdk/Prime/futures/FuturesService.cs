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
  using System.Net;
  using CoinbaseSdk.Core.Client;
  using CoinbaseSdk.Core.Http;
  using CoinbaseSdk.Core.Service;

  public class FuturesService(ICoinbaseClient client) : CoinbaseService(client), IFuturesService
  {
    public CancelEntityFuturesSweepResponse CancelEntityFuturesSweep(CancelEntityFuturesSweepRequest request, CallOptions? callOptions = null)
    {
      return Request<CancelEntityFuturesSweepResponse>(
        HttpMethod.Delete,
        $"/entities/{request.EntityId}/futures/sweeps",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<CancelEntityFuturesSweepResponse> CancelEntityFuturesSweepAsync(
      CancelEntityFuturesSweepRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CancelEntityFuturesSweepResponse>(
        HttpMethod.Delete,
        $"/entities/{request.EntityId}/futures/sweeps",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public GetFcmBalanceResponse GetFcmBalance(GetFcmBalanceRequest request, CallOptions? callOptions = null)
    {
      return Request<GetFcmBalanceResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/balance_summary",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<GetFcmBalanceResponse> GetFcmBalanceAsync(
      GetFcmBalanceRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetFcmBalanceResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/balance_summary",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public GetFcmEquityResponse GetFcmEquity(GetFcmEquityRequest request, CallOptions? callOptions = null)
    {
      return Request<GetFcmEquityResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/equity",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<GetFcmEquityResponse> GetFcmEquityAsync(
      GetFcmEquityRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetFcmEquityResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/equity",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public GetFcmMarginCallDetailsResponse GetFcmMarginCallDetails(GetFcmMarginCallDetailsRequest request, CallOptions? callOptions = null)
    {
      return Request<GetFcmMarginCallDetailsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/margin_call_details",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<GetFcmMarginCallDetailsResponse> GetFcmMarginCallDetailsAsync(
      GetFcmMarginCallDetailsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetFcmMarginCallDetailsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/margin_call_details",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public GetFcmRiskLimitsResponse GetFcmRiskLimits(GetFcmRiskLimitsRequest request, CallOptions? callOptions = null)
    {
      return Request<GetFcmRiskLimitsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/risk_limits",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<GetFcmRiskLimitsResponse> GetFcmRiskLimitsAsync(
      GetFcmRiskLimitsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetFcmRiskLimitsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/risk_limits",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public GetFcmSettingsResponse GetFcmSettings(GetFcmSettingsRequest request, CallOptions? callOptions = null)
    {
      return Request<GetFcmSettingsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/settings",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<GetFcmSettingsResponse> GetFcmSettingsAsync(
      GetFcmSettingsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetFcmSettingsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/settings",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public GetPositionsResponse GetPositions(GetPositionsRequest request, CallOptions? callOptions = null)
    {
      return Request<GetPositionsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/positions",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<GetPositionsResponse> GetPositionsAsync(
      GetPositionsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetPositionsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/positions",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public ListEntityFuturesSweepsResponse ListEntityFuturesSweeps(ListEntityFuturesSweepsRequest request, CallOptions? callOptions = null)
    {
      return Request<ListEntityFuturesSweepsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/sweeps",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<ListEntityFuturesSweepsResponse> ListEntityFuturesSweepsAsync(
      ListEntityFuturesSweepsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListEntityFuturesSweepsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/sweeps",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public ScheduleEntityFuturesSweepResponse ScheduleEntityFuturesSweep(ScheduleEntityFuturesSweepRequest request, CallOptions? callOptions = null)
    {
      return Request<ScheduleEntityFuturesSweepResponse>(
        HttpMethod.Post,
        $"/entities/{request.EntityId}/futures/sweeps",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<ScheduleEntityFuturesSweepResponse> ScheduleEntityFuturesSweepAsync(
      ScheduleEntityFuturesSweepRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ScheduleEntityFuturesSweepResponse>(
        HttpMethod.Post,
        $"/entities/{request.EntityId}/futures/sweeps",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public SetAutoSweepResponse SetAutoSweep(SetAutoSweepRequest request, CallOptions? callOptions = null)
    {
      return Request<SetAutoSweepResponse>(
        HttpMethod.Post,
        $"/entities/{request.EntityId}/futures/auto_sweep",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<SetAutoSweepResponse> SetAutoSweepAsync(
      SetAutoSweepRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<SetAutoSweepResponse>(
        HttpMethod.Post,
        $"/entities/{request.EntityId}/futures/auto_sweep",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public SetFcmSettingsResponse SetFcmSettings(SetFcmSettingsRequest request, CallOptions? callOptions = null)
    {
      return Request<SetFcmSettingsResponse>(
        HttpMethod.Post,
        $"/entities/{request.EntityId}/futures/settings",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<SetFcmSettingsResponse> SetFcmSettingsAsync(
      SetFcmSettingsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<SetFcmSettingsResponse>(
        HttpMethod.Post,
        $"/entities/{request.EntityId}/futures/settings",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

  }
}
