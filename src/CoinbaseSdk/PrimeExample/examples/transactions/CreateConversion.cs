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
    description: "The Wallet ID");

var sourceSymbolOption = new Option<string?>(
    name: "--sourceSymbol",
    description: "The source currency symbol (e.g., USD)");

var destinationSymbolOption = new Option<string?>(
    name: "--destinationSymbol",
    description: "The destination currency symbol (e.g., USDC)");

var amountOption = new Option<string?>(
    name: "--amount",
    description: "The amount to convert");

var destinationOption = new Option<string?>(
    name: "--destination",
    description: "The destination wallet ID (optional)");

var idempotencyKeyOption = new Option<string?>(
    name: "--idempotencyKey",
    description: "Idempotency key (auto-generated if not provided)");

var rootCommand = new RootCommand("Create a currency conversion")
{
    portfolioIdOption,
    walletIdOption,
    sourceSymbolOption,
    destinationSymbolOption,
    amountOption,
    destinationOption,
    idempotencyKeyOption,
};

rootCommand.SetHandler((context) =>
{
    var portfolioId = context.ParseResult.GetValueForOption(portfolioIdOption);
    var walletId = context.ParseResult.GetValueForOption(walletIdOption);
    var sourceSymbol = context.ParseResult.GetValueForOption(sourceSymbolOption);
    var destinationSymbol = context.ParseResult.GetValueForOption(destinationSymbolOption);
    var amount = context.ParseResult.GetValueForOption(amountOption);
    var destination = context.ParseResult.GetValueForOption(destinationOption);
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

    if (string.IsNullOrEmpty(sourceSymbol))
    {
        Console.Error.WriteLine("Error: --sourceSymbol is required.");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(destinationSymbol))
    {
        Console.Error.WriteLine("Error: --destinationSymbol is required.");
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
        var requestBuilder = new CreateConversionRequest.CreateConversionRequestBuilder()
            .WithPortfolioId(portfolioId)
            .WithWalletId(walletId)
            .WithSourceSymbol(sourceSymbol)
            .WithDestinationSymbol(destinationSymbol)
            .WithAmount(amount)
            .WithIdempotencyKey(idempotencyKey);

        if (!string.IsNullOrEmpty(destination))
        {
            requestBuilder.WithDestination(destination);
        }

        var request = requestBuilder.Build();

        PrettyPrinter.PrintResponse("CreateConversionRequest", request);

        // Execute request
        var response = transactionsService.CreateConversion(request);

        // Print response
        PrettyPrinter.PrintResponse("CreateConversionResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error creating conversion", ex);
        Environment.ExitCode = 1;
    }
});

return rootCommand.Invoke(args);
