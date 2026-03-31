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

namespace CoinbaseSdk.Prime.Futures
{
  using System.Net;
  using CoinbaseSdk.Core.Client;
  using CoinbaseSdk.Core.Http;
  using CoinbaseSdk.Core.Service;

  public class FuturesService(ICoinbaseClient client) : CoinbaseService(client), IFuturesService
  {
    /// <summary>
    /// Set Auto Sweep
    /// Set auto sweep for a given entity.
    /// </summary>
    public SetAutoSweepResponse SetAutoSweep(
      SetAutoSweepRequest request,
      CallOptions? options = null)
    {
      return Request<SetAutoSweepResponse>(
        HttpMethod.Post,
        $"/entities/{request.EntityId}/futures/auto_sweep",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Set Auto Sweep
    /// Set auto sweep for a given entity.
    /// </summary>
    public Task<SetAutoSweepResponse> SetAutoSweepAsync(
      SetAutoSweepRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<SetAutoSweepResponse>(
        HttpMethod.Post,
        $"/entities/{request.EntityId}/futures/auto_sweep",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get Entity FCM Balance
    /// Retrieve fcm balance for a given entity.
    /// </summary>
    public GetFcmBalanceResponse GetFcmBalance(
      GetFcmBalanceRequest request,
      CallOptions? options = null)
    {
      return Request<GetFcmBalanceResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/balance_summary",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// Get Entity FCM Balance
    /// Retrieve fcm balance for a given entity.
    /// </summary>
    public Task<GetFcmBalanceResponse> GetFcmBalanceAsync(
      GetFcmBalanceRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetFcmBalanceResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/balance_summary",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get FCM Margin Call Details
    /// Retrieve the margin call details for a given entity.
    /// </summary>
    public GetFcmMarginCallDetailsResponse GetFcmMarginCallDetails(
      GetFcmMarginCallDetailsRequest request,
      CallOptions? options = null)
    {
      return Request<GetFcmMarginCallDetailsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/margin_call_details",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// Get FCM Margin Call Details
    /// Retrieve the margin call details for a given entity.
    /// </summary>
    public Task<GetFcmMarginCallDetailsResponse> GetFcmMarginCallDetailsAsync(
      GetFcmMarginCallDetailsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetFcmMarginCallDetailsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/margin_call_details",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get Entity Positions
    /// Retrieve all active fcm positions for a given entity.
    /// </summary>
    public GetPositionsResponse GetPositions(
      GetPositionsRequest request,
      CallOptions? options = null)
    {
      return Request<GetPositionsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/positions",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Get Entity Positions
    /// Retrieve all active fcm positions for a given entity.
    /// </summary>
    public Task<GetPositionsResponse> GetPositionsAsync(
      GetPositionsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetPositionsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/positions",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get FCM Risk Limits
    /// Retrieve the risk limits for a given entity.
    /// </summary>
    public GetFcmRiskLimitsResponse GetFcmRiskLimits(
      GetFcmRiskLimitsRequest request,
      CallOptions? options = null)
    {
      return Request<GetFcmRiskLimitsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/risk_limits",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// Get FCM Risk Limits
    /// Retrieve the risk limits for a given entity.
    /// </summary>
    public Task<GetFcmRiskLimitsResponse> GetFcmRiskLimitsAsync(
      GetFcmRiskLimitsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetFcmRiskLimitsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/risk_limits",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get FCM Settings
    /// Get settings related to FCM.
    /// </summary>
    public GetFcmSettingsResponse GetFcmSettings(
      GetFcmSettingsRequest request,
      CallOptions? options = null)
    {
      return Request<GetFcmSettingsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/settings",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// Get FCM Settings
    /// Get settings related to FCM.
    /// </summary>
    public Task<GetFcmSettingsResponse> GetFcmSettingsAsync(
      GetFcmSettingsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetFcmSettingsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/settings",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Set FCM Settings
    /// Update settings related to FCM.
    /// </summary>
    public SetFcmSettingsResponse SetFcmSettings(
      SetFcmSettingsRequest request,
      CallOptions? options = null)
    {
      return Request<SetFcmSettingsResponse>(
        HttpMethod.Post,
        $"/entities/{request.EntityId}/futures/settings",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Set FCM Settings
    /// Update settings related to FCM.
    /// </summary>
    public Task<SetFcmSettingsResponse> SetFcmSettingsAsync(
      SetFcmSettingsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<SetFcmSettingsResponse>(
        HttpMethod.Post,
        $"/entities/{request.EntityId}/futures/settings",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// List Entity Futures Sweeps
    /// Retrieve fcm sweeps in open status, including pending and processing sweeps.
    /// </summary>
    public ListEntityFuturesSweepsResponse ListEntityFuturesSweeps(
      ListEntityFuturesSweepsRequest request,
      CallOptions? options = null)
    {
      return Request<ListEntityFuturesSweepsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/sweeps",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// List Entity Futures Sweeps
    /// Retrieve fcm sweeps in open status, including pending and processing sweeps.
    /// </summary>
    public Task<ListEntityFuturesSweepsResponse> ListEntityFuturesSweepsAsync(
      ListEntityFuturesSweepsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListEntityFuturesSweepsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/sweeps",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Schedule Entity Futures Sweep
    /// Schedule a sweep for a given entity from FCM wallet to USD Spot wallet. Only one pending sweep is allowed at a time per entity.
    /// </summary>
    public ScheduleEntityFuturesSweepResponse ScheduleEntityFuturesSweep(
      ScheduleEntityFuturesSweepRequest request,
      CallOptions? options = null)
    {
      return Request<ScheduleEntityFuturesSweepResponse>(
        HttpMethod.Post,
        $"/entities/{request.EntityId}/futures/sweeps",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Schedule Entity Futures Sweep
    /// Schedule a sweep for a given entity from FCM wallet to USD Spot wallet. Only one pending sweep is allowed at a time per entity.
    /// </summary>
    public Task<ScheduleEntityFuturesSweepResponse> ScheduleEntityFuturesSweepAsync(
      ScheduleEntityFuturesSweepRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ScheduleEntityFuturesSweepResponse>(
        HttpMethod.Post,
        $"/entities/{request.EntityId}/futures/sweeps",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Cancel Entity Futures Sweep
    /// Cancel the pending sweep for a given entity. A user will only be able to have one pending sweep at a time. If the sweep is not found, a 404 will be returned.
    /// </summary>
    public CancelEntityFuturesSweepResponse CancelEntityFuturesSweep(
      CancelEntityFuturesSweepRequest request,
      CallOptions? options = null)
    {
      return Request<CancelEntityFuturesSweepResponse>(
        HttpMethod.Delete,
        $"/entities/{request.EntityId}/futures/sweeps",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// Cancel Entity Futures Sweep
    /// Cancel the pending sweep for a given entity. A user will only be able to have one pending sweep at a time. If the sweep is not found, a 404 will be returned.
    /// </summary>
    public Task<CancelEntityFuturesSweepResponse> CancelEntityFuturesSweepAsync(
      CancelEntityFuturesSweepRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CancelEntityFuturesSweepResponse>(
        HttpMethod.Delete,
        $"/entities/{request.EntityId}/futures/sweeps",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get FCM Equity
    /// Retrieve the equity data for a given entity.
    /// </summary>
    public GetFcmEquityResponse GetFcmEquity(
      GetFcmEquityRequest request,
      CallOptions? options = null)
    {
      return Request<GetFcmEquityResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/equity",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// Get FCM Equity
    /// Retrieve the equity data for a given entity.
    /// </summary>
    public Task<GetFcmEquityResponse> GetFcmEquityAsync(
      GetFcmEquityRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetFcmEquityResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/futures/equity",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

  }
}
