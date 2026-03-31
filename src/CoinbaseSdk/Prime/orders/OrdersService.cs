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

namespace CoinbaseSdk.Prime.Orders
{
  using System.Net;
  using CoinbaseSdk.Core.Client;
  using CoinbaseSdk.Core.Http;
  using CoinbaseSdk.Core.Service;

  public class OrdersService(ICoinbaseClient client) : CoinbaseService(client), IOrdersService
  {
    /// <summary>
    /// Accept Quote
    /// Accepts the quote received by the quote request and creates an order with the provided quote ID.
    /// Always required: portfolio_id, product_id, side, quote_id, client_quote_id.
    /// </summary>
    public AcceptQuoteResponse AcceptQuote(
      AcceptQuoteRequest request,
      CallOptions? options = null)
    {
      return Request<AcceptQuoteResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/accept_quote",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Accept Quote
    /// Accepts the quote received by the quote request and creates an order with the provided quote ID.
    /// Always required: portfolio_id, product_id, side, quote_id, client_quote_id.
    /// </summary>
    public Task<AcceptQuoteResponse> AcceptQuoteAsync(
      AcceptQuoteRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<AcceptQuoteResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/accept_quote",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// List Portfolio Fills
    /// Retrieve fills on a given portfolio. This endpoint requires a start_date, and returns a payload with a default limit of 100 if not specified by the user. The maximum allowed limit is 3000.
    /// </summary>
    public ListPortfolioFillsResponse ListPortfolioFills(
      ListPortfolioFillsRequest request,
      CallOptions? options = null)
    {
      return Request<ListPortfolioFillsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/fills",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// List Portfolio Fills
    /// Retrieve fills on a given portfolio. This endpoint requires a start_date, and returns a payload with a default limit of 100 if not specified by the user. The maximum allowed limit is 3000.
    /// </summary>
    public Task<ListPortfolioFillsResponse> ListPortfolioFillsAsync(
      ListPortfolioFillsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListPortfolioFillsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/fills",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// List Open Orders
    /// List all open orders. &lt;br /&gt;&lt;br /&gt;**Caution:** The maximum number of orders returned is 5000. If a client has more than 5000 open orders, an error is returned prompting the user to use Websocket API, or FIX API to stream open orders.
    /// </summary>
    public ListOpenOrdersResponse ListOpenOrders(
      ListOpenOrdersRequest request,
      CallOptions? options = null)
    {
      return Request<ListOpenOrdersResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/open_orders",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// List Open Orders
    /// List all open orders. &lt;br /&gt;&lt;br /&gt;**Caution:** The maximum number of orders returned is 5000. If a client has more than 5000 open orders, an error is returned prompting the user to use Websocket API, or FIX API to stream open orders.
    /// </summary>
    public Task<ListOpenOrdersResponse> ListOpenOrdersAsync(
      ListOpenOrdersRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListOpenOrdersResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/open_orders",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Create Order
    /// Create an order.
    /// </summary>
    public CreateOrderResponse CreateOrder(
      CreateOrderRequest request,
      CallOptions? options = null)
    {
      return Request<CreateOrderResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/order",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Create Order
    /// Create an order.
    /// </summary>
    public Task<CreateOrderResponse> CreateOrderAsync(
      CreateOrderRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateOrderResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/order",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get Order Preview
    /// Retrieve an order preview.
    /// </summary>
    public GetOrderPreviewResponse GetOrderPreview(
      GetOrderPreviewRequest request,
      CallOptions? options = null)
    {
      return Request<GetOrderPreviewResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/order_preview",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Get Order Preview
    /// Retrieve an order preview.
    /// </summary>
    public Task<GetOrderPreviewResponse> GetOrderPreviewAsync(
      GetOrderPreviewRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetOrderPreviewResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/order_preview",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// List Portfolio Orders
    /// List historical orders for a given portfolio. This endpoint returns a payload with a default limit of 100 if not specified by the user. The maximum allowed limit is 3000. &lt;br /&gt;&lt;br /&gt;**Caution:** Currently, you cannot query open orders with this endpoint: use List Open Orders if you have less than 1000 open orders, otherwise use Websocket API, or FIX API to stream open orders.
    /// </summary>
    public ListPortfolioOrdersResponse ListPortfolioOrders(
      ListPortfolioOrdersRequest request,
      CallOptions? options = null)
    {
      return Request<ListPortfolioOrdersResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/orders",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// List Portfolio Orders
    /// List historical orders for a given portfolio. This endpoint returns a payload with a default limit of 100 if not specified by the user. The maximum allowed limit is 3000. &lt;br /&gt;&lt;br /&gt;**Caution:** Currently, you cannot query open orders with this endpoint: use List Open Orders if you have less than 1000 open orders, otherwise use Websocket API, or FIX API to stream open orders.
    /// </summary>
    public Task<ListPortfolioOrdersResponse> ListPortfolioOrdersAsync(
      ListPortfolioOrdersRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListPortfolioOrdersResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/orders",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get Order by Order ID
    /// Retrieve an order by order ID.
    /// </summary>
    public GetOrderResponse GetOrder(
      GetOrderRequest request,
      CallOptions? options = null)
    {
      return Request<GetOrderResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// Get Order by Order ID
    /// Retrieve an order by order ID.
    /// </summary>
    public Task<GetOrderResponse> GetOrderAsync(
      GetOrderRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetOrderResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Cancel Order
    /// Cancel an order. (Filled orders cannot be canceled.)
    /// </summary>
    public CancelOrderResponse CancelOrder(
      CancelOrderRequest request,
      CallOptions? options = null)
    {
      return Request<CancelOrderResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}/cancel",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// Cancel Order
    /// Cancel an order. (Filled orders cannot be canceled.)
    /// </summary>
    public Task<CancelOrderResponse> CancelOrderAsync(
      CancelOrderRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CancelOrderResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}/cancel",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Edit Order (Beta)
    /// Edit an open order. This feature is in beta please reach out to your Coinbase Prime account manager for more information.
    /// </summary>
    public EditOrderResponse EditOrder(
      EditOrderRequest request,
      CallOptions? options = null)
    {
      return Request<EditOrderResponse>(
        HttpMethod.Put,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}/edit",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Edit Order (Beta)
    /// Edit an open order. This feature is in beta please reach out to your Coinbase Prime account manager for more information.
    /// </summary>
    public Task<EditOrderResponse> EditOrderAsync(
      EditOrderRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<EditOrderResponse>(
        HttpMethod.Put,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}/edit",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// List Order Edit History
    /// List edit history for a specific order
    /// </summary>
    public ListOrderEditHistoryResponse ListOrderEditHistory(
      ListOrderEditHistoryRequest request,
      CallOptions? options = null)
    {
      return Request<ListOrderEditHistoryResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}/edit_history",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// List Order Edit History
    /// List edit history for a specific order
    /// </summary>
    public Task<ListOrderEditHistoryResponse> ListOrderEditHistoryAsync(
      ListOrderEditHistoryRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListOrderEditHistoryResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}/edit_history",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// List Order Fills
    /// Retrieve fills on a given order. This endpoint returns a payload with a default limit of 100 if not specified by the user. The maximum allowed limit is 3000.
    /// </summary>
    public ListOrderFillsResponse ListOrderFills(
      ListOrderFillsRequest request,
      CallOptions? options = null)
    {
      return Request<ListOrderFillsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}/fills",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// List Order Fills
    /// Retrieve fills on a given order. This endpoint returns a payload with a default limit of 100 if not specified by the user. The maximum allowed limit is 3000.
    /// </summary>
    public Task<ListOrderFillsResponse> ListOrderFillsAsync(
      ListOrderFillsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListOrderFillsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/orders/{request.OrderId}/fills",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Create Quote Request
    /// A Quote Request is the start of the RFQ process. Coinbase Prime sends a Quote Request to Liquidity Providers (LPs) on behalf of a customer looking to participate in an RFQ trade.
    /// Always required: portfolio_id, product_id, side, client_quote_id, and limit_price. One of either base_quantity or quote_value is always required.
    /// </summary>
    public CreateQuoteResponse CreateQuote(
      CreateQuoteRequest request,
      CallOptions? options = null)
    {
      return Request<CreateQuoteResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/rfq",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Create Quote Request
    /// A Quote Request is the start of the RFQ process. Coinbase Prime sends a Quote Request to Liquidity Providers (LPs) on behalf of a customer looking to participate in an RFQ trade.
    /// Always required: portfolio_id, product_id, side, client_quote_id, and limit_price. One of either base_quantity or quote_value is always required.
    /// </summary>
    public Task<CreateQuoteResponse> CreateQuoteAsync(
      CreateQuoteRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateQuoteResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/rfq",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

  }
}
