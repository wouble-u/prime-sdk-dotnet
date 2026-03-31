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
  using CoinbaseSdk.Core.Http;

  public interface IFinancingService
  {
    /// <summary>
    /// List Interest Accruals
    /// Lists interest accruals for an entity between the specified date range given
    /// </summary>
    public ListInterestAccrualsResponse ListInterestAccruals(
      ListInterestAccrualsRequest request,
      CallOptions? options = null);

    /// <summary>
    /// List Interest Accruals
    /// Lists interest accruals for an entity between the specified date range given
    /// </summary>
    public Task<ListInterestAccrualsResponse> ListInterestAccrualsAsync(
      ListInterestAccrualsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Cross Margin Overview
    /// Gets live data for Cross Margin (XM) for a specific XM customer
    /// </summary>
    public GetCrossMarginOverviewResponse GetCrossMarginOverview(
      GetCrossMarginOverviewRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Get Cross Margin Overview
    /// Gets live data for Cross Margin (XM) for a specific XM customer
    /// </summary>
    public Task<GetCrossMarginOverviewResponse> GetCrossMarginOverviewAsync(
      GetCrossMarginOverviewRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Entity Locate Availabilities
    /// Get currencies available to be located with their corresponding amount and rate.
    /// </summary>
    public GetEntityLocateAvailabilitiesResponse GetEntityLocateAvailabilities(
      GetEntityLocateAvailabilitiesRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Get Entity Locate Availabilities
    /// Get currencies available to be located with their corresponding amount and rate.
    /// </summary>
    public Task<GetEntityLocateAvailabilitiesResponse> GetEntityLocateAvailabilitiesAsync(
      GetEntityLocateAvailabilitiesRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Margin Information
    /// Gets real-time evaluation of the margin model based on current positions and spot rates.
    /// </summary>
    public GetMarginInformationResponse GetMarginInformation(
      GetMarginInformationRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Get Margin Information
    /// Gets real-time evaluation of the margin model based on current positions and spot rates.
    /// </summary>
    public Task<GetMarginInformationResponse> GetMarginInformationAsync(
      GetMarginInformationRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// List Margin Call Summaries
    /// Lists the margin call history for a given entity ID.
    /// </summary>
    public ListMarginCallSummariesResponse ListMarginCallSummaries(
      ListMarginCallSummariesRequest request,
      CallOptions? options = null);

    /// <summary>
    /// List Margin Call Summaries
    /// Lists the margin call history for a given entity ID.
    /// </summary>
    public Task<ListMarginCallSummariesResponse> ListMarginCallSummariesAsync(
      ListMarginCallSummariesRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// List Trade Finance Obligations
    /// List trade finance obligations for a given entity.
    /// </summary>
    public ListTradeFinanceObligationsResponse ListTradeFinanceObligations(
      ListTradeFinanceObligationsRequest request,
      CallOptions? options = null);

    /// <summary>
    /// List Trade Finance Obligations
    /// List trade finance obligations for a given entity.
    /// </summary>
    public Task<ListTradeFinanceObligationsResponse> ListTradeFinanceObligationsAsync(
      ListTradeFinanceObligationsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Trade Finance Tiered Pricing Fees
    /// Get trade finance tiered pricing fees for a given entity at a specific time, default to current time.
    /// </summary>
    public GetTradeFinanceTieredPricingFeesResponse GetTradeFinanceTieredPricingFees(
      GetTradeFinanceTieredPricingFeesRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Get Trade Finance Tiered Pricing Fees
    /// Get trade finance tiered pricing fees for a given entity at a specific time, default to current time.
    /// </summary>
    public Task<GetTradeFinanceTieredPricingFeesResponse> GetTradeFinanceTieredPricingFeesAsync(
      GetTradeFinanceTieredPricingFeesRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// List Financing Eligible Assets
    /// Get all assets eligible for Trade Finance with their adjustment factors.
    /// </summary>
    public ListFinancingEligibleAssetsResponse ListFinancingEligibleAssets(
      ListFinancingEligibleAssetsRequest request,
      CallOptions? options = null);

    /// <summary>
    /// List Financing Eligible Assets
    /// Get all assets eligible for Trade Finance with their adjustment factors.
    /// </summary>
    public Task<ListFinancingEligibleAssetsResponse> ListFinancingEligibleAssetsAsync(
      ListFinancingEligibleAssetsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// List Interest Accruals For Portfolio
    /// Lists interest accruals between the specified date range for a specific portfolio ID
    /// </summary>
    public ListInterestAccrualsForPortfolioResponse ListInterestAccrualsForPortfolio(
      ListInterestAccrualsForPortfolioRequest request,
      CallOptions? options = null);

    /// <summary>
    /// List Interest Accruals For Portfolio
    /// Lists interest accruals between the specified date range for a specific portfolio ID
    /// </summary>
    public Task<ListInterestAccrualsForPortfolioResponse> ListInterestAccrualsForPortfolioAsync(
      ListInterestAccrualsForPortfolioRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Portfolio Buying Power
    /// Returns the size of a buy trade that can be performed based on existing holdings and available credit. The result will differ for different assets due to asset specific credit configurations and caps. Note that this result is changing based on asset price fluctuations, so may be rejected when submitted.
    /// </summary>
    public GetPortfolioBuyingPowerResponse GetPortfolioBuyingPower(
      GetPortfolioBuyingPowerRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Get Portfolio Buying Power
    /// Returns the size of a buy trade that can be performed based on existing holdings and available credit. The result will differ for different assets due to asset specific credit configurations and caps. Note that this result is changing based on asset price fluctuations, so may be rejected when submitted.
    /// </summary>
    public Task<GetPortfolioBuyingPowerResponse> GetPortfolioBuyingPowerAsync(
      GetPortfolioBuyingPowerRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Portfolio Credit Information
    /// Retrieve a portfolio's post-trade credit information.
    /// </summary>
    public GetPortfolioCreditInformationResponse GetPortfolioCreditInformation(
      GetPortfolioCreditInformationRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Get Portfolio Credit Information
    /// Retrieve a portfolio's post-trade credit information.
    /// </summary>
    public Task<GetPortfolioCreditInformationResponse> GetPortfolioCreditInformationAsync(
      GetPortfolioCreditInformationRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// List Existing Locates
    /// List locates for the portfolio
    /// </summary>
    public ListExistingLocatesResponse ListExistingLocates(
      ListExistingLocatesRequest request,
      CallOptions? options = null);

    /// <summary>
    /// List Existing Locates
    /// List locates for the portfolio
    /// </summary>
    public Task<ListExistingLocatesResponse> ListExistingLocatesAsync(
      ListExistingLocatesRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Create New Locates
    /// Create a new locate
    /// </summary>
    public CreateNewLocatesResponse CreateNewLocates(
      CreateNewLocatesRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Create New Locates
    /// Create a new locate
    /// </summary>
    public Task<CreateNewLocatesResponse> CreateNewLocatesAsync(
      CreateNewLocatesRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// List Margin Conversions
    /// Lists conversions and short collateral requirement between specified date range. This endpoint is deprecated and will be removed in the future. Use /v1/entities/{entity_id}/margin_summaries instead.
    /// </summary>
    public ListMarginConversionsResponse ListMarginConversions(
      ListMarginConversionsRequest request,
      CallOptions? options = null);

    /// <summary>
    /// List Margin Conversions
    /// Lists conversions and short collateral requirement between specified date range. This endpoint is deprecated and will be removed in the future. Use /v1/entities/{entity_id}/margin_summaries instead.
    /// </summary>
    public Task<ListMarginConversionsResponse> ListMarginConversionsAsync(
      ListMarginConversionsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Portfolio Withdrawal Power
    /// Returns the nominal quantity of a given asset that can be withdrawn based on holdings and current portfolio equity.
    /// </summary>
    public GetPortfolioWithdrawalPowerResponse GetPortfolioWithdrawalPower(
      GetPortfolioWithdrawalPowerRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Get Portfolio Withdrawal Power
    /// Returns the nominal quantity of a given asset that can be withdrawn based on holdings and current portfolio equity.
    /// </summary>
    public Task<GetPortfolioWithdrawalPowerResponse> GetPortfolioWithdrawalPowerAsync(
      GetPortfolioWithdrawalPowerRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

  }
}
