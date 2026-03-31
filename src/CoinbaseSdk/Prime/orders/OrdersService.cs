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
  using System.Net;
  using CoinbaseSdk.Core.Client;
  using CoinbaseSdk.Core.Http;
  using CoinbaseSdk.Core.Service;

  public class OrdersService(ICoinbaseClient client) : CoinbaseService(client), IOrdersService
  {
    public AcceptQuoteResponse AcceptQuote(AcceptQuoteRequest request, CallOptions? callOptions = null)
    {
      return Request<AcceptQuoteResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/accept_quote",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<AcceptQuoteResponse> AcceptQuoteAsync(
      AcceptQuoteRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<AcceptQuoteResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/accept_quote",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public CancelOrderResponse CancelOrder(CancelOrderRequest request, CallOptions? callOptions = null)
    {
      return Request<CancelOrderResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}/cancel",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<CancelOrderResponse> CancelOrderAsync(
      CancelOrderRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CancelOrderResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}/cancel",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public CreateOrderResponse CreateOrder(CreateOrderRequest request, CallOptions? callOptions = null)
    {
      return Request<CreateOrderResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/order",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<CreateOrderResponse> CreateOrderAsync(
      CreateOrderRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateOrderResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/order",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public CreateQuoteResponse CreateQuote(CreateQuoteRequest request, CallOptions? callOptions = null)
    {
      return Request<CreateQuoteResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/rfq",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<CreateQuoteResponse> CreateQuoteAsync(
      CreateQuoteRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateQuoteResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/rfq",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public EditOrderResponse EditOrder(EditOrderRequest request, CallOptions? callOptions = null)
    {
      return Request<EditOrderResponse>(
        HttpMethod.Put,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}/edit",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<EditOrderResponse> EditOrderAsync(
      EditOrderRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<EditOrderResponse>(
        HttpMethod.Put,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}/edit",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public GetOrderResponse GetOrder(GetOrderRequest request, CallOptions? callOptions = null)
    {
      return Request<GetOrderResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<GetOrderResponse> GetOrderAsync(
      GetOrderRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetOrderResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public GetOrderPreviewResponse GetOrderPreview(GetOrderPreviewRequest request, CallOptions? callOptions = null)
    {
      return Request<GetOrderPreviewResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/order_preview",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<GetOrderPreviewResponse> GetOrderPreviewAsync(
      GetOrderPreviewRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetOrderPreviewResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/order_preview",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public ListOpenOrdersResponse ListOpenOrders(ListOpenOrdersRequest request, CallOptions? callOptions = null)
    {
      return Request<ListOpenOrdersResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/open_orders",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<ListOpenOrdersResponse> ListOpenOrdersAsync(
      ListOpenOrdersRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListOpenOrdersResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/open_orders",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public ListOrderEditHistoryResponse ListOrderEditHistory(ListOrderEditHistoryRequest request, CallOptions? callOptions = null)
    {
      return Request<ListOrderEditHistoryResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}/edit_history",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<ListOrderEditHistoryResponse> ListOrderEditHistoryAsync(
      ListOrderEditHistoryRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListOrderEditHistoryResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}/edit_history",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public ListOrderFillsResponse ListOrderFills(ListOrderFillsRequest request, CallOptions? callOptions = null)
    {
      return Request<ListOrderFillsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}/fills",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<ListOrderFillsResponse> ListOrderFillsAsync(
      ListOrderFillsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListOrderFillsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}/fills",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public ListPortfolioFillsResponse ListPortfolioFills(ListPortfolioFillsRequest request, CallOptions? callOptions = null)
    {
      return Request<ListPortfolioFillsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/fills",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<ListPortfolioFillsResponse> ListPortfolioFillsAsync(
      ListPortfolioFillsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListPortfolioFillsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/fills",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public ListPortfolioOrdersResponse ListPortfolioOrders(ListPortfolioOrdersRequest request, CallOptions? callOptions = null)
    {
      return Request<ListPortfolioOrdersResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/orders",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<ListPortfolioOrdersResponse> ListPortfolioOrdersAsync(
      ListPortfolioOrdersRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListPortfolioOrdersResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/orders",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

  }
}
