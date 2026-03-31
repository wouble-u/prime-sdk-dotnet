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

namespace CoinbaseSdk.Prime.Financing
{
  using System.Net;
  using CoinbaseSdk.Core.Client;
  using CoinbaseSdk.Core.Http;
  using CoinbaseSdk.Core.Service;

  public class FinancingService(ICoinbaseClient client) : CoinbaseService(client), IFinancingService
  {
    /// <summary>
    /// List Interest Accruals
    /// Lists interest accruals for an entity between the specified date range given
    /// </summary>
    public ListInterestAccrualsResponse ListInterestAccruals(
      ListInterestAccrualsRequest request,
      CallOptions? options = null)
    {
      return Request<ListInterestAccrualsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/accruals",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// List Interest Accruals
    /// Lists interest accruals for an entity between the specified date range given
    /// </summary>
    public Task<ListInterestAccrualsResponse> ListInterestAccrualsAsync(
      ListInterestAccrualsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListInterestAccrualsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/accruals",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get Cross Margin Overview
    /// Gets live data for Cross Margin (XM) for a specific XM customer
    /// </summary>
    public GetCrossMarginOverviewResponse GetCrossMarginOverview(
      GetCrossMarginOverviewRequest request,
      CallOptions? options = null)
    {
      return Request<GetCrossMarginOverviewResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/cross_margin",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// Get Cross Margin Overview
    /// Gets live data for Cross Margin (XM) for a specific XM customer
    /// </summary>
    public Task<GetCrossMarginOverviewResponse> GetCrossMarginOverviewAsync(
      GetCrossMarginOverviewRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetCrossMarginOverviewResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/cross_margin",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get Entity Locate Availabilities
    /// Get currencies available to be located with their corresponding amount and rate.
    /// </summary>
    public GetEntityLocateAvailabilitiesResponse GetEntityLocateAvailabilities(
      GetEntityLocateAvailabilitiesRequest request,
      CallOptions? options = null)
    {
      return Request<GetEntityLocateAvailabilitiesResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/locates_availability",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Get Entity Locate Availabilities
    /// Get currencies available to be located with their corresponding amount and rate.
    /// </summary>
    public Task<GetEntityLocateAvailabilitiesResponse> GetEntityLocateAvailabilitiesAsync(
      GetEntityLocateAvailabilitiesRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetEntityLocateAvailabilitiesResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/locates_availability",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get Margin Information
    /// Gets real-time evaluation of the margin model based on current positions and spot rates.
    /// </summary>
    public GetMarginInformationResponse GetMarginInformation(
      GetMarginInformationRequest request,
      CallOptions? options = null)
    {
      return Request<GetMarginInformationResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/margin",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// Get Margin Information
    /// Gets real-time evaluation of the margin model based on current positions and spot rates.
    /// </summary>
    public Task<GetMarginInformationResponse> GetMarginInformationAsync(
      GetMarginInformationRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetMarginInformationResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/margin",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// List Margin Call Summaries
    /// Lists the margin call history for a given entity ID.
    /// </summary>
    public ListMarginCallSummariesResponse ListMarginCallSummaries(
      ListMarginCallSummariesRequest request,
      CallOptions? options = null)
    {
      return Request<ListMarginCallSummariesResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/margin_summaries",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// List Margin Call Summaries
    /// Lists the margin call history for a given entity ID.
    /// </summary>
    public Task<ListMarginCallSummariesResponse> ListMarginCallSummariesAsync(
      ListMarginCallSummariesRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListMarginCallSummariesResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/margin_summaries",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// List Trade Finance Obligations
    /// List trade finance obligations for a given entity.
    /// </summary>
    public ListTradeFinanceObligationsResponse ListTradeFinanceObligations(
      ListTradeFinanceObligationsRequest request,
      CallOptions? options = null)
    {
      return Request<ListTradeFinanceObligationsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/tf_obligations",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// List Trade Finance Obligations
    /// List trade finance obligations for a given entity.
    /// </summary>
    public Task<ListTradeFinanceObligationsResponse> ListTradeFinanceObligationsAsync(
      ListTradeFinanceObligationsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListTradeFinanceObligationsResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/tf_obligations",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get Trade Finance Tiered Pricing Fees
    /// Get trade finance tiered pricing fees for a given entity at a specific time, default to current time.
    /// </summary>
    public GetTradeFinanceTieredPricingFeesResponse GetTradeFinanceTieredPricingFees(
      GetTradeFinanceTieredPricingFeesRequest request,
      CallOptions? options = null)
    {
      return Request<GetTradeFinanceTieredPricingFeesResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/tf_tiered_fees",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Get Trade Finance Tiered Pricing Fees
    /// Get trade finance tiered pricing fees for a given entity at a specific time, default to current time.
    /// </summary>
    public Task<GetTradeFinanceTieredPricingFeesResponse> GetTradeFinanceTieredPricingFeesAsync(
      GetTradeFinanceTieredPricingFeesRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetTradeFinanceTieredPricingFeesResponse>(
        HttpMethod.Get,
        $"/entities/{request.EntityId}/tf_tiered_fees",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// List Financing Eligible Assets
    /// Get all assets eligible for Trade Finance with their adjustment factors.
    /// </summary>
    public ListFinancingEligibleAssetsResponse ListFinancingEligibleAssets(
      ListFinancingEligibleAssetsRequest request,
      CallOptions? options = null)
    {
      return Request<ListFinancingEligibleAssetsResponse>(
        HttpMethod.Get,
        $"/financing/eligible-assets",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// List Financing Eligible Assets
    /// Get all assets eligible for Trade Finance with their adjustment factors.
    /// </summary>
    public Task<ListFinancingEligibleAssetsResponse> ListFinancingEligibleAssetsAsync(
      ListFinancingEligibleAssetsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListFinancingEligibleAssetsResponse>(
        HttpMethod.Get,
        $"/financing/eligible-assets",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// List Interest Accruals For Portfolio
    /// Lists interest accruals between the specified date range for a specific portfolio ID
    /// </summary>
    public ListInterestAccrualsForPortfolioResponse ListInterestAccrualsForPortfolio(
      ListInterestAccrualsForPortfolioRequest request,
      CallOptions? options = null)
    {
      return Request<ListInterestAccrualsForPortfolioResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/accruals",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// List Interest Accruals For Portfolio
    /// Lists interest accruals between the specified date range for a specific portfolio ID
    /// </summary>
    public Task<ListInterestAccrualsForPortfolioResponse> ListInterestAccrualsForPortfolioAsync(
      ListInterestAccrualsForPortfolioRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListInterestAccrualsForPortfolioResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/accruals",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get Portfolio Buying Power
    /// Returns the size of a buy trade that can be performed based on existing holdings and available credit. The result will differ for different assets due to asset specific credit configurations and caps. Note that this result is changing based on asset price fluctuations, so may be rejected when submitted.
    /// </summary>
    public GetPortfolioBuyingPowerResponse GetPortfolioBuyingPower(
      GetPortfolioBuyingPowerRequest request,
      CallOptions? options = null)
    {
      return Request<GetPortfolioBuyingPowerResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/buying_power",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Get Portfolio Buying Power
    /// Returns the size of a buy trade that can be performed based on existing holdings and available credit. The result will differ for different assets due to asset specific credit configurations and caps. Note that this result is changing based on asset price fluctuations, so may be rejected when submitted.
    /// </summary>
    public Task<GetPortfolioBuyingPowerResponse> GetPortfolioBuyingPowerAsync(
      GetPortfolioBuyingPowerRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetPortfolioBuyingPowerResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/buying_power",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get Portfolio Credit Information
    /// Retrieve a portfolio's post-trade credit information.
    /// </summary>
    public GetPortfolioCreditInformationResponse GetPortfolioCreditInformation(
      GetPortfolioCreditInformationRequest request,
      CallOptions? options = null)
    {
      return Request<GetPortfolioCreditInformationResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/credit",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// Get Portfolio Credit Information
    /// Retrieve a portfolio's post-trade credit information.
    /// </summary>
    public Task<GetPortfolioCreditInformationResponse> GetPortfolioCreditInformationAsync(
      GetPortfolioCreditInformationRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetPortfolioCreditInformationResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/credit",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// List Existing Locates
    /// List locates for the portfolio
    /// </summary>
    public ListExistingLocatesResponse ListExistingLocates(
      ListExistingLocatesRequest request,
      CallOptions? options = null)
    {
      return Request<ListExistingLocatesResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/locates",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// List Existing Locates
    /// List locates for the portfolio
    /// </summary>
    public Task<ListExistingLocatesResponse> ListExistingLocatesAsync(
      ListExistingLocatesRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListExistingLocatesResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/locates",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Create New Locates
    /// Create a new locate
    /// </summary>
    public CreateNewLocatesResponse CreateNewLocates(
      CreateNewLocatesRequest request,
      CallOptions? options = null)
    {
      return Request<CreateNewLocatesResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/locates",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Create New Locates
    /// Create a new locate
    /// </summary>
    public Task<CreateNewLocatesResponse> CreateNewLocatesAsync(
      CreateNewLocatesRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateNewLocatesResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/locates",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// List Margin Conversions
    /// Lists conversions and short collateral requirement between specified date range. This endpoint is deprecated and will be removed in the future. Use /v1/entities/{entity_id}/margin_summaries instead.
    /// </summary>
    public ListMarginConversionsResponse ListMarginConversions(
      ListMarginConversionsRequest request,
      CallOptions? options = null)
    {
      return Request<ListMarginConversionsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/margin_conversions",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// List Margin Conversions
    /// Lists conversions and short collateral requirement between specified date range. This endpoint is deprecated and will be removed in the future. Use /v1/entities/{entity_id}/margin_summaries instead.
    /// </summary>
    public Task<ListMarginConversionsResponse> ListMarginConversionsAsync(
      ListMarginConversionsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListMarginConversionsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/margin_conversions",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get Portfolio Withdrawal Power
    /// Returns the nominal quantity of a given asset that can be withdrawn based on holdings and current portfolio equity.
    /// </summary>
    public GetPortfolioWithdrawalPowerResponse GetPortfolioWithdrawalPower(
      GetPortfolioWithdrawalPowerRequest request,
      CallOptions? options = null)
    {
      return Request<GetPortfolioWithdrawalPowerResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/withdrawal_power",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Get Portfolio Withdrawal Power
    /// Returns the nominal quantity of a given asset that can be withdrawn based on holdings and current portfolio equity.
    /// </summary>
    public Task<GetPortfolioWithdrawalPowerResponse> GetPortfolioWithdrawalPowerAsync(
      GetPortfolioWithdrawalPowerRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetPortfolioWithdrawalPowerResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/withdrawal_power",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

  }
}
