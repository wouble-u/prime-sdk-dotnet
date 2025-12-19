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

var sideOption = new Option<string?>(
    name: "--side",
    description: "Order side (BUY or SELL)");

var clientQuoteIdOption = new Option<string?>(
    name: "--clientQuoteId",
    description: "Client-generated quote ID (auto-generated if not provided)");

var baseQuantityOption = new Option<string?>(
    name: "--baseQuantity",
    description: "Quote size in base asset units (e.g., 0.001 for BTC)");

var quoteValueOption = new Option<string?>(
    name: "--quoteValue",
    description: "Quote size in quote asset units (e.g., 100 for USD)");

var limitPriceOption = new Option<string?>(
    name: "--limitPrice",
    description: "Limit price for the quote");

var settlCurrencyOption = new Option<string?>(
    name: "--settlCurrency",
    description: "Settlement currency");

var rootCommand = new RootCommand("Create a quote (RFQ - Request for Quote)")
{
    portfolioIdOption,
    productIdOption,
    sideOption,
    clientQuoteIdOption,
    baseQuantityOption,
    quoteValueOption,
    limitPriceOption,
    settlCurrencyOption,
};

rootCommand.SetHandler((context) =>
{
    var portfolioId = context.ParseResult.GetValueForOption(portfolioIdOption);
    var productId = context.ParseResult.GetValueForOption(productIdOption);
    var sideStr = context.ParseResult.GetValueForOption(sideOption);
    var clientQuoteId = context.ParseResult.GetValueForOption(clientQuoteIdOption);
    var baseQuantity = context.ParseResult.GetValueForOption(baseQuantityOption);
    var quoteValue = context.ParseResult.GetValueForOption(quoteValueOption);
    var limitPrice = context.ParseResult.GetValueForOption(limitPriceOption);
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

    if (string.IsNullOrEmpty(sideStr))
    {
        Console.Error.WriteLine("Error: --side is required (BUY or SELL).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(baseQuantity) && string.IsNullOrEmpty(quoteValue))
    {
        Console.Error.WriteLine("Error: Either --baseQuantity or --quoteValue is required.");
        Environment.ExitCode = 1;
        return;
    }

    if (!Enum.TryParse<OrderSide>(sideStr, true, out var side))
    {
        Console.Error.WriteLine($"Error: Invalid side '{sideStr}'. Must be BUY or SELL.");
        Environment.ExitCode = 1;
        return;
    }

    try
    {
        Console.WriteLine($"Using Portfolio ID: {portfolioId}");

        var client = CoinbasePrimeClient.FromEnv();
        var ordersService = new OrdersService(client);

        clientQuoteId ??= Guid.NewGuid().ToString();

        var requestBuilder = new CreateQuoteRequest.CreateQuoteRequestBuilder(portfolioId)
            .WithProductId(productId)
            .WithSide(side)
            .WithClientQuoteId(clientQuoteId);

        if (!string.IsNullOrEmpty(baseQuantity))
        {
            requestBuilder.WithBaseQuantity(baseQuantity);
        }

        if (!string.IsNullOrEmpty(quoteValue))
        {
            requestBuilder.WithQuoteValue(quoteValue);
        }

        if (!string.IsNullOrEmpty(limitPrice))
        {
            requestBuilder.WithLimitPrice(limitPrice);
        }

        if (!string.IsNullOrEmpty(settlCurrency))
        {
            requestBuilder.WithSettlCurrency(settlCurrency);
        }

        var request = requestBuilder.Build();

        PrettyPrinter.PrintResponse("CreateQuoteRequest", request);

        var response = ordersService.CreateQuote(request);

        PrettyPrinter.PrintResponse("CreateQuoteResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error creating quote", ex);
        Environment.ExitCode = 1;
    }
});

return rootCommand.Invoke(args);
