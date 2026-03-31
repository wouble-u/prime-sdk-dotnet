/*
 * Copyright 2024-present Coinbase Global, Inc.
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

namespace CoinbaseSdk.Prime.Orders
{
  using CoinbaseSdk.Core.Http;

  public interface IOrdersService
  {
    public AcceptQuoteResponse AcceptQuote(AcceptQuoteRequest request, CallOptions? callOptions = null);

    public Task<AcceptQuoteResponse> AcceptQuoteAsync(
      AcceptQuoteRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public CancelOrderResponse CancelOrder(CancelOrderRequest request, CallOptions? callOptions = null);

    public Task<CancelOrderResponse> CancelOrderAsync(
      CancelOrderRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public CreateOrderResponse CreateOrder(CreateOrderRequest request, CallOptions? callOptions = null);

    public Task<CreateOrderResponse> CreateOrderAsync(
      CreateOrderRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public CreateQuoteResponse CreateQuote(CreateQuoteRequest request, CallOptions? callOptions = null);

    public Task<CreateQuoteResponse> CreateQuoteAsync(
      CreateQuoteRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public EditOrderResponse EditOrder(EditOrderRequest request, CallOptions? callOptions = null);

    public Task<EditOrderResponse> EditOrderAsync(
      EditOrderRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public GetOrderResponse GetOrder(GetOrderRequest request, CallOptions? callOptions = null);

    public Task<GetOrderResponse> GetOrderAsync(
      GetOrderRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public GetOrderPreviewResponse GetOrderPreview(GetOrderPreviewRequest request, CallOptions? callOptions = null);

    public Task<GetOrderPreviewResponse> GetOrderPreviewAsync(
      GetOrderPreviewRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public ListOpenOrdersResponse ListOpenOrders(ListOpenOrdersRequest request, CallOptions? callOptions = null);

    public Task<ListOpenOrdersResponse> ListOpenOrdersAsync(
      ListOpenOrdersRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public ListOrderEditHistoryResponse ListOrderEditHistory(ListOrderEditHistoryRequest request, CallOptions? callOptions = null);

    public Task<ListOrderEditHistoryResponse> ListOrderEditHistoryAsync(
      ListOrderEditHistoryRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public ListOrderFillsResponse ListOrderFills(ListOrderFillsRequest request, CallOptions? callOptions = null);

    public Task<ListOrderFillsResponse> ListOrderFillsAsync(
      ListOrderFillsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public ListPortfolioFillsResponse ListPortfolioFills(ListPortfolioFillsRequest request, CallOptions? callOptions = null);

    public Task<ListPortfolioFillsResponse> ListPortfolioFillsAsync(
      ListPortfolioFillsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public ListPortfolioOrdersResponse ListPortfolioOrders(ListPortfolioOrdersRequest request, CallOptions? callOptions = null);

    public Task<ListPortfolioOrdersResponse> ListPortfolioOrdersAsync(
      ListPortfolioOrdersRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

  }
}
