#!/usr/bin/env -S dotnet run --file
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

#:project ../../../Prime
#:project ../../
#:package Newtonsoft.Json@13.0.3

using CoinbaseSdk.Prime.Transactions;
using CoinbaseSdk.Prime.Client;
using CoinbaseSdk.Prime.Model.Enums;
using CoinbaseSdk.Prime.Common;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var portfolioIdOption = new Option<string?>(
    name: "--portfolioId",
    description: "The Portfolio ID");

var walletIdOption = new Option<string?>(
    name: "--walletId",
    description: "The Wallet ID");

var typeOption = new Option<string?>(
    name: "--type",
    description: "Transaction type (DEPOSIT, WITHDRAWAL, etc.)");

var startTimeOption = new Option<string?>(
    name: "--startTime",
    description: "Start time (UTC)");

var endTimeOption = new Option<string?>(
    name: "--endTime",
    description: "End time (UTC)");

var rootCommand = new RootCommand("List transactions for a wallet")
{
    portfolioIdOption,
    walletIdOption,
    typeOption,
    startTimeOption,
    endTimeOption,
};

rootCommand.SetHandler((portfolioId, walletId, typeStr, startTime, endTime) =>
{
    // Fallback to environment variable for portfolioId
    if (string.IsNullOrEmpty(portfolioId))
    {
        portfolioId = Environment.GetEnvironmentVariable("PRIME_PORTFOLIO_ID");
    }

    if (string.IsNullOrEmpty(portfolioId))
    {
        Console.Error.WriteLine("Error: --portfolioId is required (or set PRIME_PORTFOLIO_ID env var).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(walletId))
    {
        Console.Error.WriteLine("Error: --walletId is required.");
        Environment.ExitCode = 1;
        return;
    }

    try
    {
        Console.WriteLine($"Using Portfolio ID: {portfolioId}");
        Console.WriteLine($"Using Wallet ID: {walletId}");

        // Create client and service
        var client = CoinbasePrimeClient.FromEnv();
        var transactionsService = new TransactionsService(client);

        // Build request
        var requestBuilder = new ListWalletTransactionsRequest.Builder()
            .WithPortfolioId(portfolioId)
            .WithWalletId(walletId);

        if (!string.IsNullOrEmpty(typeStr))
        {
            if (Enum.TryParse<TransactionType>(typeStr, true, out var transactionType))
            {
                requestBuilder.WithType(transactionType);
            }
            else
            {
                Console.Error.WriteLine($"Invalid transaction type: {typeStr}");
                Environment.ExitCode = 1;
                return;
            }
        }

        if (!string.IsNullOrEmpty(startTime))
        {
            requestBuilder.WithStartTime(startTime);
        }

        if (!string.IsNullOrEmpty(endTime))
        {
            requestBuilder.WithEndTime(endTime);
        }

        var request = requestBuilder.Build();

        PrettyPrinter.PrintResponse("ListWalletTransactionsRequest", request);

        // Execute request
        var response = transactionsService.ListWalletTransactions(request);

        // Print response
        PrettyPrinter.PrintResponse("ListWalletTransactionsResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error listing wallet transactions", ex);
        Environment.ExitCode = 1;
    }
}, portfolioIdOption, walletIdOption, typeOption, startTimeOption, endTimeOption);

return rootCommand.Invoke(args);
