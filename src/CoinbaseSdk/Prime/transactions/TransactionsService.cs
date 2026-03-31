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

namespace CoinbaseSdk.Prime.Transactions
{
  using System.Net;
  using CoinbaseSdk.Core.Client;
  using CoinbaseSdk.Core.Http;
  using CoinbaseSdk.Core.Service;

  public class TransactionsService(ICoinbaseClient client) : CoinbaseService(client), ITransactionsService
  {
    public CancelAdvancedTransferResponse CancelAdvancedTransfer(CancelAdvancedTransferRequest request, CallOptions? callOptions = null)
    {
      return Request<CancelAdvancedTransferResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/advanced_transfers/{request.AdvancedTransferId}/cancel",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<CancelAdvancedTransferResponse> CancelAdvancedTransferAsync(
      CancelAdvancedTransferRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CancelAdvancedTransferResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/advanced_transfers/{request.AdvancedTransferId}/cancel",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public CreateAdvancedTransferResponse CreateAdvancedTransfer(CreateAdvancedTransferRequest request, CallOptions? callOptions = null)
    {
      return Request<CreateAdvancedTransferResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/advanced_transfers",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<CreateAdvancedTransferResponse> CreateAdvancedTransferAsync(
      CreateAdvancedTransferRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateAdvancedTransferResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/advanced_transfers",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public CreateConversionResponse CreateConversion(CreateConversionRequest request, CallOptions? callOptions = null)
    {
      return Request<CreateConversionResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/conversion",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<CreateConversionResponse> CreateConversionAsync(
      CreateConversionRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateConversionResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/conversion",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public CreateOnchainTransactionResponse CreateOnchainTransaction(CreateOnchainTransactionRequest request, CallOptions? callOptions = null)
    {
      return Request<CreateOnchainTransactionResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/onchain_transaction",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<CreateOnchainTransactionResponse> CreateOnchainTransactionAsync(
      CreateOnchainTransactionRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateOnchainTransactionResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/onchain_transaction",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public CreateTransferResponse CreateTransfer(CreateTransferRequest request, CallOptions? callOptions = null)
    {
      return Request<CreateTransferResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/transfers",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<CreateTransferResponse> CreateTransferAsync(
      CreateTransferRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateTransferResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/transfers",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public CreateWithdrawalResponse CreateWithdrawal(CreateWithdrawalRequest request, CallOptions? callOptions = null)
    {
      return Request<CreateWithdrawalResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/withdrawals",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<CreateWithdrawalResponse> CreateWithdrawalAsync(
      CreateWithdrawalRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateWithdrawalResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/withdrawals",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public GetTransactionResponse GetTransaction(GetTransactionRequest request, CallOptions? callOptions = null)
    {
      return Request<GetTransactionResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/transactions/{request.TransactionId}",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<GetTransactionResponse> GetTransactionAsync(
      GetTransactionRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetTransactionResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/transactions/{request.TransactionId}",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public GetTransactionTravelRuleDataResponse GetTransactionTravelRuleData(GetTransactionTravelRuleDataRequest request, CallOptions? callOptions = null)
    {
      return Request<GetTransactionTravelRuleDataResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/transactions/{request.TransactionId}/travel_rule",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<GetTransactionTravelRuleDataResponse> GetTransactionTravelRuleDataAsync(
      GetTransactionTravelRuleDataRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetTransactionTravelRuleDataResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/transactions/{request.TransactionId}/travel_rule",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public ListAdvancedTransferTransactionsResponse ListAdvancedTransferTransactions(ListAdvancedTransferTransactionsRequest request, CallOptions? callOptions = null)
    {
      return Request<ListAdvancedTransferTransactionsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/advanced_transfers/{request.AdvancedTransferId}/transactions",
        [HttpStatusCode.OK],
        null,
        callOptions);
    }

    public Task<ListAdvancedTransferTransactionsResponse> ListAdvancedTransferTransactionsAsync(
      ListAdvancedTransferTransactionsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListAdvancedTransferTransactionsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/advanced_transfers/{request.AdvancedTransferId}/transactions",
        [HttpStatusCode.OK],
        null,
        callOptions,
        cancellationToken);
    }

    public ListAdvancedTransfersResponse ListAdvancedTransfers(ListAdvancedTransfersRequest request, CallOptions? callOptions = null)
    {
      return Request<ListAdvancedTransfersResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/advanced_transfers",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<ListAdvancedTransfersResponse> ListAdvancedTransfersAsync(
      ListAdvancedTransfersRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListAdvancedTransfersResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/advanced_transfers",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public ListPortfolioTransactionsResponse ListPortfolioTransactions(ListPortfolioTransactionsRequest request, CallOptions? callOptions = null)
    {
      return Request<ListPortfolioTransactionsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/transactions",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<ListPortfolioTransactionsResponse> ListPortfolioTransactionsAsync(
      ListPortfolioTransactionsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListPortfolioTransactionsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/transactions",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public ListWalletTransactionsResponse ListWalletTransactions(ListWalletTransactionsRequest request, CallOptions? callOptions = null)
    {
      return Request<ListWalletTransactionsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/transactions",
        [HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<ListWalletTransactionsResponse> ListWalletTransactionsAsync(
      ListWalletTransactionsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListWalletTransactionsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/transactions",
        [HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

    public SubmitDepositTravelRuleDataResponse SubmitDepositTravelRuleData(SubmitDepositTravelRuleDataRequest request, CallOptions? callOptions = null)
    {
      return Request<SubmitDepositTravelRuleDataResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/transactions/{request.TransactionId}/travel_rule/deposit",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions);
    }

    public Task<SubmitDepositTravelRuleDataResponse> SubmitDepositTravelRuleDataAsync(
      SubmitDepositTravelRuleDataRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<SubmitDepositTravelRuleDataResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/transactions/{request.TransactionId}/travel_rule/deposit",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        callOptions,
        cancellationToken);
    }

  }
}
