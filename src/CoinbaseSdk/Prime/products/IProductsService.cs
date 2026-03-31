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

namespace CoinbaseSdk.Prime.Products
{
  using CoinbaseSdk.Core.Http;

  public interface IProductsService
  {
    /// <summary>
    /// List Portfolio Products
    /// List tradable products for a given portfolio.
    /// </summary>
    public ListPortfolioProductsResponse ListPortfolioProducts(
      ListPortfolioProductsRequest request,
      CallOptions? options = null);

    /// <summary>
    /// List Portfolio Products
    /// List tradable products for a given portfolio.
    /// </summary>
    public Task<ListPortfolioProductsResponse> ListPortfolioProductsAsync(
      ListPortfolioProductsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Public Product Candles (Beta)
    /// Get rates for a single product by product ID, grouped in buckets. This feature is in beta please reach out to your Coinbase Prime account manager for more information.
    /// </summary>
    public GetCandlesResponse GetCandles(
      GetCandlesRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Get Public Product Candles (Beta)
    /// Get rates for a single product by product ID, grouped in buckets. This feature is in beta please reach out to your Coinbase Prime account manager for more information.
    /// </summary>
    public Task<GetCandlesResponse> GetCandlesAsync(
      GetCandlesRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

  }
}
