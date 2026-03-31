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
  using CoinbaseSdk.Core.Http;

  public interface IOrdersService
  {
    /// <summary>
    /// Accept Quote
    /// Accepts the quote received by the quote request and creates an order with the provided quote ID.
    /// Always required: portfolio_id, product_id, side, quote_id, client_quote_id.
    /// </summary>
    public AcceptQuoteResponse AcceptQuote(
      AcceptQuoteRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Accept Quote
    /// Accepts the quote received by the quote request and creates an order with the provided quote ID.
    /// Always required: portfolio_id, product_id, side, quote_id, client_quote_id.
    /// </summary>
    public Task<AcceptQuoteResponse> AcceptQuoteAsync(
      AcceptQuoteRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// List Portfolio Fills
    /// Retrieve fills on a given portfolio. This endpoint requires a start_date, and returns a payload with a default limit of 100 if not specified by the user. The maximum allowed limit is 3000.
    /// </summary>
    public ListPortfolioFillsResponse ListPortfolioFills(
      ListPortfolioFillsRequest request,
      CallOptions? options = null);

    /// <summary>
    /// List Portfolio Fills
    /// Retrieve fills on a given portfolio. This endpoint requires a start_date, and returns a payload with a default limit of 100 if not specified by the user. The maximum allowed limit is 3000.
    /// </summary>
    public Task<ListPortfolioFillsResponse> ListPortfolioFillsAsync(
      ListPortfolioFillsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// List Open Orders
    /// List all open orders. &lt;br /&gt;&lt;br /&gt;**Caution:** The maximum number of orders returned is 5000. If a client has more than 5000 open orders, an error is returned prompting the user to use Websocket API, or FIX API to stream open orders.
    /// </summary>
    public ListOpenOrdersResponse ListOpenOrders(
      ListOpenOrdersRequest request,
      CallOptions? options = null);

    /// <summary>
    /// List Open Orders
    /// List all open orders. &lt;br /&gt;&lt;br /&gt;**Caution:** The maximum number of orders returned is 5000. If a client has more than 5000 open orders, an error is returned prompting the user to use Websocket API, or FIX API to stream open orders.
    /// </summary>
    public Task<ListOpenOrdersResponse> ListOpenOrdersAsync(
      ListOpenOrdersRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Create Order
    /// Create an order.
    /// </summary>
    public CreateOrderResponse CreateOrder(
      CreateOrderRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Create Order
    /// Create an order.
    /// </summary>
    public Task<CreateOrderResponse> CreateOrderAsync(
      CreateOrderRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Order Preview
    /// Retrieve an order preview.
    /// </summary>
    public GetOrderPreviewResponse GetOrderPreview(
      GetOrderPreviewRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Get Order Preview
    /// Retrieve an order preview.
    /// </summary>
    public Task<GetOrderPreviewResponse> GetOrderPreviewAsync(
      GetOrderPreviewRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// List Portfolio Orders
    /// List historical orders for a given portfolio. This endpoint returns a payload with a default limit of 100 if not specified by the user. The maximum allowed limit is 3000. &lt;br /&gt;&lt;br /&gt;**Caution:** Currently, you cannot query open orders with this endpoint: use List Open Orders if you have less than 1000 open orders, otherwise use Websocket API, or FIX API to stream open orders.
    /// </summary>
    public ListPortfolioOrdersResponse ListPortfolioOrders(
      ListPortfolioOrdersRequest request,
      CallOptions? options = null);

    /// <summary>
    /// List Portfolio Orders
    /// List historical orders for a given portfolio. This endpoint returns a payload with a default limit of 100 if not specified by the user. The maximum allowed limit is 3000. &lt;br /&gt;&lt;br /&gt;**Caution:** Currently, you cannot query open orders with this endpoint: use List Open Orders if you have less than 1000 open orders, otherwise use Websocket API, or FIX API to stream open orders.
    /// </summary>
    public Task<ListPortfolioOrdersResponse> ListPortfolioOrdersAsync(
      ListPortfolioOrdersRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Order by Order ID
    /// Retrieve an order by order ID.
    /// </summary>
    public GetOrderResponse GetOrder(
      GetOrderRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Get Order by Order ID
    /// Retrieve an order by order ID.
    /// </summary>
    public Task<GetOrderResponse> GetOrderAsync(
      GetOrderRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancel Order
    /// Cancel an order. (Filled orders cannot be canceled.)
    /// </summary>
    public CancelOrderResponse CancelOrder(
      CancelOrderRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Cancel Order
    /// Cancel an order. (Filled orders cannot be canceled.)
    /// </summary>
    public Task<CancelOrderResponse> CancelOrderAsync(
      CancelOrderRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Edit Order (Beta)
    /// Edit an open order. This feature is in beta please reach out to your Coinbase Prime account manager for more information.
    /// </summary>
    public EditOrderResponse EditOrder(
      EditOrderRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Edit Order (Beta)
    /// Edit an open order. This feature is in beta please reach out to your Coinbase Prime account manager for more information.
    /// </summary>
    public Task<EditOrderResponse> EditOrderAsync(
      EditOrderRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// List Order Edit History
    /// List edit history for a specific order
    /// </summary>
    public ListOrderEditHistoryResponse ListOrderEditHistory(
      ListOrderEditHistoryRequest request,
      CallOptions? options = null);

    /// <summary>
    /// List Order Edit History
    /// List edit history for a specific order
    /// </summary>
    public Task<ListOrderEditHistoryResponse> ListOrderEditHistoryAsync(
      ListOrderEditHistoryRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// List Order Fills
    /// Retrieve fills on a given order. This endpoint returns a payload with a default limit of 100 if not specified by the user. The maximum allowed limit is 3000.
    /// </summary>
    public ListOrderFillsResponse ListOrderFills(
      ListOrderFillsRequest request,
      CallOptions? options = null);

    /// <summary>
    /// List Order Fills
    /// Retrieve fills on a given order. This endpoint returns a payload with a default limit of 100 if not specified by the user. The maximum allowed limit is 3000.
    /// </summary>
    public Task<ListOrderFillsResponse> ListOrderFillsAsync(
      ListOrderFillsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Create Quote Request
    /// A Quote Request is the start of the RFQ process. Coinbase Prime sends a Quote Request to Liquidity Providers (LPs) on behalf of a customer looking to participate in an RFQ trade.
    /// Always required: portfolio_id, product_id, side, client_quote_id, and limit_price. One of either base_quantity or quote_value is always required.
    /// </summary>
    public CreateQuoteResponse CreateQuote(
      CreateQuoteRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Create Quote Request
    /// A Quote Request is the start of the RFQ process. Coinbase Prime sends a Quote Request to Liquidity Providers (LPs) on behalf of a customer looking to participate in an RFQ trade.
    /// Always required: portfolio_id, product_id, side, client_quote_id, and limit_price. One of either base_quantity or quote_value is always required.
    /// </summary>
    public Task<CreateQuoteResponse> CreateQuoteAsync(
      CreateQuoteRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

  }
}
