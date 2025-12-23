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

using CoinbaseSdk.Prime.Orders;
using CoinbaseSdk.Prime.Client;
using CoinbaseSdk.Prime.Model.Enums;
using CoinbaseSdk.Prime.Common;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var portfolioIdOption = new Option<string?>(
    name: "--portfolioId",
    description: "The Portfolio ID");

var productIdOption = new Option<string?>(
    name: "--productId",
    description: "The product ID (e.g., BTC-USD)");

var quoteIdOption = new Option<string?>(
    name: "--quoteId",
    description: "The Quote ID to accept");

var clientOrderIdOption = new Option<string?>(
    name: "--clientOrderId",
    description: "Client order ID for the accepted quote");

var sideOption = new Option<string?>(
    name: "--side",
    description: "Order side (BUY or SELL)");

var settlCurrencyOption = new Option<string?>(
    name: "--settlCurrency",
    description: "Settlement currency");

var rootCommand = new RootCommand("Accept a quote (RFQ - Request for Quote)")
{
    portfolioIdOption,
    productIdOption,
    quoteIdOption,
    clientOrderIdOption,
    sideOption,
    settlCurrencyOption,
};

rootCommand.SetHandler((context) =>
{
    var portfolioId = context.ParseResult.GetValueForOption(portfolioIdOption);
    var productId = context.ParseResult.GetValueForOption(productIdOption);
    var quoteId = context.ParseResult.GetValueForOption(quoteIdOption);
    var clientOrderId = context.ParseResult.GetValueForOption(clientOrderIdOption);
    var sideStr = context.ParseResult.GetValueForOption(sideOption);
    var settlCurrency = context.ParseResult.GetValueForOption(settlCurrencyOption);

    portfolioId ??= Environment.GetEnvironmentVariable("PRIME_PORTFOLIO_ID");

    if (string.IsNullOrEmpty(portfolioId))
    {
        Console.Error.WriteLine("Error: --portfolioId is required (or set PRIME_PORTFOLIO_ID env var).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(productId))
    {
        Console.Error.WriteLine("Error: --productId is required (e.g., BTC-USD).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(quoteId))
    {
        Console.Error.WriteLine("Error: --quoteId is required.");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(clientOrderId))
    {
        Console.Error.WriteLine("Error: --clientOrderId is required.");
        Environment.ExitCode = 1;
        return;
    }

    try
    {
        Console.WriteLine($"Using Portfolio ID: {portfolioId}");
        Console.WriteLine($"Accepting Quote ID: {quoteId}");

        var client = CoinbasePrimeClient.FromEnv();
        var ordersService = new OrdersService(client);

        var request = new AcceptQuoteRequest(portfolioId, productId, quoteId, clientOrderId);

        if (!string.IsNullOrEmpty(sideStr))
        {
            if (Enum.TryParse<OrderSide>(sideStr, true, out var side))
            {
                request.Side = side;
            }
            else
            {
                Console.Error.WriteLine($"Error: Invalid side '{sideStr}'. Must be BUY or SELL.");
                Environment.ExitCode = 1;
                return;
            }
        }

        if (!string.IsNullOrEmpty(settlCurrency))
        {
            request.SettlCurrency = settlCurrency;
        }

        PrettyPrinter.PrintResponse("AcceptQuoteRequest", request);

        var response = ordersService.AcceptQuote(request);

        PrettyPrinter.PrintResponse("AcceptQuoteResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error accepting quote", ex);
        Environment.ExitCode = 1;
    }
});

return rootCommand.Invoke(args);
