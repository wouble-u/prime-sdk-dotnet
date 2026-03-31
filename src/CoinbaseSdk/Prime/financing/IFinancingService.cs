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

namespace CoinbaseSdk.Prime.Financing
{
  using CoinbaseSdk.Core.Http;

  public interface IFinancingService
  {
    public CreateNewLocatesResponse CreateNewLocates(CreateNewLocatesRequest request, CallOptions? callOptions = null);

    public Task<CreateNewLocatesResponse> CreateNewLocatesAsync(
      CreateNewLocatesRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public GetCrossMarginOverviewResponse GetCrossMarginOverview(GetCrossMarginOverviewRequest request, CallOptions? callOptions = null);

    public Task<GetCrossMarginOverviewResponse> GetCrossMarginOverviewAsync(
      GetCrossMarginOverviewRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public GetEntityLocateAvailabilitiesResponse GetEntityLocateAvailabilities(GetEntityLocateAvailabilitiesRequest request, CallOptions? callOptions = null);

    public Task<GetEntityLocateAvailabilitiesResponse> GetEntityLocateAvailabilitiesAsync(
      GetEntityLocateAvailabilitiesRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public GetMarginInformationResponse GetMarginInformation(GetMarginInformationRequest request, CallOptions? callOptions = null);

    public Task<GetMarginInformationResponse> GetMarginInformationAsync(
      GetMarginInformationRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public GetPortfolioBuyingPowerResponse GetPortfolioBuyingPower(GetPortfolioBuyingPowerRequest request, CallOptions? callOptions = null);

    public Task<GetPortfolioBuyingPowerResponse> GetPortfolioBuyingPowerAsync(
      GetPortfolioBuyingPowerRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public GetPortfolioCreditInformationResponse GetPortfolioCreditInformation(GetPortfolioCreditInformationRequest request, CallOptions? callOptions = null);

    public Task<GetPortfolioCreditInformationResponse> GetPortfolioCreditInformationAsync(
      GetPortfolioCreditInformationRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public GetPortfolioWithdrawalPowerResponse GetPortfolioWithdrawalPower(GetPortfolioWithdrawalPowerRequest request, CallOptions? callOptions = null);

    public Task<GetPortfolioWithdrawalPowerResponse> GetPortfolioWithdrawalPowerAsync(
      GetPortfolioWithdrawalPowerRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public GetTradeFinanceTieredPricingFeesResponse GetTradeFinanceTieredPricingFees(GetTradeFinanceTieredPricingFeesRequest request, CallOptions? callOptions = null);

    public Task<GetTradeFinanceTieredPricingFeesResponse> GetTradeFinanceTieredPricingFeesAsync(
      GetTradeFinanceTieredPricingFeesRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public ListExistingLocatesResponse ListExistingLocates(ListExistingLocatesRequest request, CallOptions? callOptions = null);

    public Task<ListExistingLocatesResponse> ListExistingLocatesAsync(
      ListExistingLocatesRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public ListFinancingEligibleAssetsResponse ListFinancingEligibleAssets(ListFinancingEligibleAssetsRequest request, CallOptions? callOptions = null);

    public Task<ListFinancingEligibleAssetsResponse> ListFinancingEligibleAssetsAsync(
      ListFinancingEligibleAssetsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public ListInterestAccrualsResponse ListInterestAccruals(ListInterestAccrualsRequest request, CallOptions? callOptions = null);

    public Task<ListInterestAccrualsResponse> ListInterestAccrualsAsync(
      ListInterestAccrualsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public ListInterestAccrualsForPortfolioResponse ListInterestAccrualsForPortfolio(ListInterestAccrualsForPortfolioRequest request, CallOptions? callOptions = null);

    public Task<ListInterestAccrualsForPortfolioResponse> ListInterestAccrualsForPortfolioAsync(
      ListInterestAccrualsForPortfolioRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public ListMarginCallSummariesResponse ListMarginCallSummaries(ListMarginCallSummariesRequest request, CallOptions? callOptions = null);

    public Task<ListMarginCallSummariesResponse> ListMarginCallSummariesAsync(
      ListMarginCallSummariesRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public ListMarginConversionsResponse ListMarginConversions(ListMarginConversionsRequest request, CallOptions? callOptions = null);

    public Task<ListMarginConversionsResponse> ListMarginConversionsAsync(
      ListMarginConversionsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public ListTradeFinanceObligationsResponse ListTradeFinanceObligations(ListTradeFinanceObligationsRequest request, CallOptions? callOptions = null);

    public Task<ListTradeFinanceObligationsResponse> ListTradeFinanceObligationsAsync(
      ListTradeFinanceObligationsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

  }
}
