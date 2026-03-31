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
using CoinbaseSdk.Prime.Common;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var portfolioIdOption = new Option<string?>(
    name: "--portfolioId",
    description: "The Portfolio ID");

var walletIdOption = new Option<string?>(
    name: "--walletId",
    description: "The source Wallet ID");

var destinationOption = new Option<string?>(
    name: "--destination",
    description: "The destination wallet ID");

var currencySymbolOption = new Option<string?>(
    name: "--currencySymbol",
    description: "The currency symbol (e.g., BTC, ETH)");

var amountOption = new Option<string?>(
    name: "--amount",
    description: "The amount to transfer");

var idempotencyKeyOption = new Option<string?>(
    name: "--idempotencyKey",
    description: "Idempotency key (auto-generated if not provided)");

var rootCommand = new RootCommand("Create a transfer between wallets")
{
    portfolioIdOption,
    walletIdOption,
    destinationOption,
    currencySymbolOption,
    amountOption,
    idempotencyKeyOption,
};

rootCommand.SetHandler((context) =>
{
    var portfolioId = context.ParseResult.GetValueForOption(portfolioIdOption);
    var walletId = context.ParseResult.GetValueForOption(walletIdOption);
    var destination = context.ParseResult.GetValueForOption(destinationOption);
    var currencySymbol = context.ParseResult.GetValueForOption(currencySymbolOption);
    var amount = context.ParseResult.GetValueForOption(amountOption);
    var idempotencyKey = context.ParseResult.GetValueForOption(idempotencyKeyOption);

    // Fallback to environment variable for portfolioId
    portfolioId ??= Environment.GetEnvironmentVariable("PRIME_PORTFOLIO_ID");

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

    if (string.IsNullOrEmpty(destination))
    {
        Console.Error.WriteLine("Error: --destination is required.");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(currencySymbol))
    {
        Console.Error.WriteLine("Error: --currencySymbol is required.");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(amount))
    {
        Console.Error.WriteLine("Error: --amount is required.");
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

        // Generate idempotency key if not provided
        idempotencyKey ??= Guid.NewGuid().ToString();

        // Build request
        var request = new CreateTransferRequest.CreateTransferRequestBuilder()
            .WithPortfolioId(portfolioId)
            .WithWalletId(walletId)
            .WithDestination(destination)
            .WithCurrencySymbol(currencySymbol)
            .WithAmount(amount)
            .WithIdempotencyKey(idempotencyKey)
            .Build();

        PrettyPrinter.PrintResponse("CreateTransferRequest", request);

        // Execute request
        var response = transactionsService.CreateTransfer(request);

        // Print response
        PrettyPrinter.PrintResponse("CreateTransferResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error creating transfer", ex);
        Environment.ExitCode = 1;
    }
});

return rootCommand.Invoke(args);
