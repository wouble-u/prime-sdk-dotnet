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

namespace CoinbaseSdk.Prime.Transactions
{
  using System.Net;
  using CoinbaseSdk.Core.Client;
  using CoinbaseSdk.Core.Http;
  using CoinbaseSdk.Core.Service;

  public class TransactionsService(ICoinbaseClient client) : CoinbaseService(client), ITransactionsService
  {
    /// <summary>
    /// List Portfolio Transactions
    /// List transactions for a given portfolio.
    /// </summary>
    public ListPortfolioTransactionsResponse ListPortfolioTransactions(
      ListPortfolioTransactionsRequest request,
      CallOptions? options = null)
    {
      return Request<ListPortfolioTransactionsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/transactions",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// List Portfolio Transactions
    /// List transactions for a given portfolio.
    /// </summary>
    public Task<ListPortfolioTransactionsResponse> ListPortfolioTransactionsAsync(
      ListPortfolioTransactionsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListPortfolioTransactionsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/transactions",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get Transaction by Transaction ID
    /// Retrieve a specific transaction by its transaction ID.
    /// </summary>
    public GetTransactionResponse GetTransaction(
      GetTransactionRequest request,
      CallOptions? options = null)
    {
      return Request<GetTransactionResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/transactions/{request.TransactionId}",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// Get Transaction by Transaction ID
    /// Retrieve a specific transaction by its transaction ID.
    /// </summary>
    public Task<GetTransactionResponse> GetTransactionAsync(
      GetTransactionRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetTransactionResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/transactions/{request.TransactionId}",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Create Conversion
    /// Perform a conversion between 2 assets.
    /// </summary>
    public CreateConversionResponse CreateConversion(
      CreateConversionRequest request,
      CallOptions? options = null)
    {
      return Request<CreateConversionResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/conversion",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Create Conversion
    /// Perform a conversion between 2 assets.
    /// </summary>
    public Task<CreateConversionResponse> CreateConversionAsync(
      CreateConversionRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateConversionResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/conversion",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Create Onchain Transaction
    /// Create an onchain transaction.
    /// </summary>
    public CreateOnchainTransactionResponse CreateOnchainTransaction(
      CreateOnchainTransactionRequest request,
      CallOptions? options = null)
    {
      return Request<CreateOnchainTransactionResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/onchain_transaction",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Create Onchain Transaction
    /// Create an onchain transaction.
    /// </summary>
    public Task<CreateOnchainTransactionResponse> CreateOnchainTransactionAsync(
      CreateOnchainTransactionRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateOnchainTransactionResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/onchain_transaction",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// List Wallet Transactions
    /// Retrieve transactions for a given wallet.
    /// </summary>
    public ListWalletTransactionsResponse ListWalletTransactions(
      ListWalletTransactionsRequest request,
      CallOptions? options = null)
    {
      return Request<ListWalletTransactionsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/transactions",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// List Wallet Transactions
    /// Retrieve transactions for a given wallet.
    /// </summary>
    public Task<ListWalletTransactionsResponse> ListWalletTransactionsAsync(
      ListWalletTransactionsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListWalletTransactionsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/transactions",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Create Transfer
    /// Create a wallet transfer.
    /// </summary>
    public CreateTransferResponse CreateTransfer(
      CreateTransferRequest request,
      CallOptions? options = null)
    {
      return Request<CreateTransferResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/transfers",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Create Transfer
    /// Create a wallet transfer.
    /// </summary>
    public Task<CreateTransferResponse> CreateTransferAsync(
      CreateTransferRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateTransferResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/transfers",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Create Withdrawal
    /// Create a withdrawal.
    /// </summary>
    public CreateWithdrawalResponse CreateWithdrawal(
      CreateWithdrawalRequest request,
      CallOptions? options = null)
    {
      return Request<CreateWithdrawalResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/withdrawals",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Create Withdrawal
    /// Create a withdrawal.
    /// </summary>
    public Task<CreateWithdrawalResponse> CreateWithdrawalAsync(
      CreateWithdrawalRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateWithdrawalResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/wallets/{request.WalletId}/withdrawals",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// List Advanced Transfers
    /// List advanced transfers for a given portfolio. This API is currently not available to all clients. Please reach out to Prime Operations with any questions.
    /// </summary>
    public ListAdvancedTransfersResponse ListAdvancedTransfers(
      ListAdvancedTransfersRequest request,
      CallOptions? options = null)
    {
      return Request<ListAdvancedTransfersResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/advanced_transfers",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// List Advanced Transfers
    /// List advanced transfers for a given portfolio. This API is currently not available to all clients. Please reach out to Prime Operations with any questions.
    /// </summary>
    public Task<ListAdvancedTransfersResponse> ListAdvancedTransfersAsync(
      ListAdvancedTransfersRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListAdvancedTransfersResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/advanced_transfers",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Create Advanced Transfer
    /// Create advanced transfer for a given portfolio. This API is currently not available to all clients. Please reach out to Prime Operations with any questions.
    /// </summary>
    public CreateAdvancedTransferResponse CreateAdvancedTransfer(
      CreateAdvancedTransferRequest request,
      CallOptions? options = null)
    {
      return Request<CreateAdvancedTransferResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/advanced_transfers",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Create Advanced Transfer
    /// Create advanced transfer for a given portfolio. This API is currently not available to all clients. Please reach out to Prime Operations with any questions.
    /// </summary>
    public Task<CreateAdvancedTransferResponse> CreateAdvancedTransferAsync(
      CreateAdvancedTransferRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CreateAdvancedTransferResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/advanced_transfers",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Cancel Advanced Transfer
    /// Cancel advanced transfer for a given portfolio. This API is currently not available to all clients. Please reach out to Prime Operations with any questions.
    /// </summary>
    public CancelAdvancedTransferResponse CancelAdvancedTransfer(
      CancelAdvancedTransferRequest request,
      CallOptions? options = null)
    {
      return Request<CancelAdvancedTransferResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/advanced_transfers/{request.AdvancedTransferId}/cancel",
        [HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Cancel Advanced Transfer
    /// Cancel advanced transfer for a given portfolio. This API is currently not available to all clients. Please reach out to Prime Operations with any questions.
    /// </summary>
    public Task<CancelAdvancedTransferResponse> CancelAdvancedTransferAsync(
      CancelAdvancedTransferRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<CancelAdvancedTransferResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/advanced_transfers/{request.AdvancedTransferId}/cancel",
        [HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

    /// <summary>
    /// List transactions associated with an Advanced Transfer
    /// List transactions associated with an Advanced Transfer. This API is currently not available to all clients. Please reach out to Prime Operations with any questions.
    /// </summary>
    public ListAdvancedTransferTransactionsResponse ListAdvancedTransferTransactions(
      ListAdvancedTransferTransactionsRequest request,
      CallOptions? options = null)
    {
      return Request<ListAdvancedTransferTransactionsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/advanced_transfers/{request.AdvancedTransferId}/transactions",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// List transactions associated with an Advanced Transfer
    /// List transactions associated with an Advanced Transfer. This API is currently not available to all clients. Please reach out to Prime Operations with any questions.
    /// </summary>
    public Task<ListAdvancedTransferTransactionsResponse> ListAdvancedTransferTransactionsAsync(
      ListAdvancedTransferTransactionsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<ListAdvancedTransferTransactionsResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/advanced_transfers/{request.AdvancedTransferId}/transactions",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Get Transaction Travel Rule Data
    /// (Beta) Get fulfilled travel rule data for a transaction.
    /// </summary>
    public GetTransactionTravelRuleDataResponse GetTransactionTravelRuleData(
      GetTransactionTravelRuleDataRequest request,
      CallOptions? options = null)
    {
      return Request<GetTransactionTravelRuleDataResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/transactions/{request.TransactionId}/travel_rule",
        [HttpStatusCode.OK],
        null,
        options);
    }

    /// <summary>
    /// Get Transaction Travel Rule Data
    /// (Beta) Get fulfilled travel rule data for a transaction.
    /// </summary>
    public Task<GetTransactionTravelRuleDataResponse> GetTransactionTravelRuleDataAsync(
      GetTransactionTravelRuleDataRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<GetTransactionTravelRuleDataResponse>(
        HttpMethod.Get,
        $"/portfolios/{request.PortfolioId}/transactions/{request.TransactionId}/travel_rule",
        [HttpStatusCode.OK],
        null,
        options,
        cancellationToken);
    }

    /// <summary>
    /// Submit Deposit Travel Rule Data
    /// Submit travel rule data for an existing deposit transaction.
    /// </summary>
    public SubmitDepositTravelRuleDataResponse SubmitDepositTravelRuleData(
      SubmitDepositTravelRuleDataRequest request,
      CallOptions? options = null)
    {
      return Request<SubmitDepositTravelRuleDataResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/transactions/{request.TransactionId}/travel_rule/deposit",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options);
    }

    /// <summary>
    /// Submit Deposit Travel Rule Data
    /// Submit travel rule data for an existing deposit transaction.
    /// </summary>
    public Task<SubmitDepositTravelRuleDataResponse> SubmitDepositTravelRuleDataAsync(
      SubmitDepositTravelRuleDataRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default)
    {
      return RequestAsync<SubmitDepositTravelRuleDataResponse>(
        HttpMethod.Post,
        $"/portfolios/{request.PortfolioId}/transactions/{request.TransactionId}/travel_rule/deposit",
        [HttpStatusCode.Created, HttpStatusCode.OK],
        request,
        options,
        cancellationToken);
    }

  }
}
