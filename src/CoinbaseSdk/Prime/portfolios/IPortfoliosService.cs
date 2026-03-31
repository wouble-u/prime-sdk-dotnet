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

namespace CoinbaseSdk.Prime.Portfolios
{
  using CoinbaseSdk.Core.Http;

  public interface IPortfoliosService
  {
    /// <summary>
    /// List Portfolios
    /// List all portfolios for which the current API key has read access.
    /// </summary>
    public ListPortfoliosResponse ListPortfolios(
      CallOptions? options = null);

    /// <summary>
    /// List Portfolios
    /// List all portfolios for which the current API key has read access.
    /// </summary>
    public Task<ListPortfoliosResponse> ListPortfoliosAsync(
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Portfolio by Portfolio ID
    /// Retrieve a given portfolio by its portfolio ID.
    /// </summary>
    public GetPortfolioResponse GetPortfolio(
      GetPortfolioRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Get Portfolio by Portfolio ID
    /// Retrieve a given portfolio by its portfolio ID.
    /// </summary>
    public Task<GetPortfolioResponse> GetPortfolioAsync(
      GetPortfolioRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Portfolio Counterparty ID
    /// Retrieve the counterparty ID for a given portfolio.
    /// </summary>
    public GetPortfolioCounterpartyResponse GetPortfolioCounterparty(
      GetPortfolioCounterpartyRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Get Portfolio Counterparty ID
    /// Retrieve the counterparty ID for a given portfolio.
    /// </summary>
    public Task<GetPortfolioCounterpartyResponse> GetPortfolioCounterpartyAsync(
      GetPortfolioCounterpartyRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

  }
}
