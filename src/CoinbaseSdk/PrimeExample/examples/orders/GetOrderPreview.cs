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

var typeOption = new Option<string?>(
    name: "--type",
    description: "Order type (MARKET, LIMIT, TWAP, VWAP, STOP_LIMIT, BLOCK, RFQ, PEG)");

var baseQuantityOption = new Option<string?>(
    name: "--baseQuantity",
    description: "Order size in base asset units (e.g., 0.001 for BTC)");

var quoteValueOption = new Option<string?>(
    name: "--quoteValue",
    description: "Order size in quote asset units (e.g., 100 for USD)");

var limitPriceOption = new Option<string?>(
    name: "--limitPrice",
    description: "Limit price (required for LIMIT, TWAP, VWAP, STOP_LIMIT orders)");

var stopPriceOption = new Option<string?>(
    name: "--stopPrice",
    description: "Stop price (for STOP_LIMIT orders)");

var timeInForceOption = new Option<string?>(
    name: "--timeInForce",
    description: "Time in force (GOOD_UNTIL_DATE_TIME, GOOD_UNTIL_CANCELLED, IMMEDIATE_OR_CANCEL, FILL_OR_KILL)");

var startTimeOption = new Option<string?>(
    name: "--startTime",
    description: "Start time for TWAP/VWAP orders (UTC)");

var expiryTimeOption = new Option<string?>(
    name: "--expiryTime",
    description: "Expiry time for orders (UTC)");

var rootCommand = new RootCommand("Preview an order before creating it")
{
    portfolioIdOption,
    productIdOption,
    sideOption,
    typeOption,
    baseQuantityOption,
    quoteValueOption,
    limitPriceOption,
    stopPriceOption,
    timeInForceOption,
    startTimeOption,
    expiryTimeOption,
};

rootCommand.SetHandler((context) =>
{
    var portfolioId = context.ParseResult.GetValueForOption(portfolioIdOption);
    var productId = context.ParseResult.GetValueForOption(productIdOption);
    var sideStr = context.ParseResult.GetValueForOption(sideOption);
    var typeStr = context.ParseResult.GetValueForOption(typeOption);
    var baseQuantity = context.ParseResult.GetValueForOption(baseQuantityOption);
    var quoteValue = context.ParseResult.GetValueForOption(quoteValueOption);
    var limitPrice = context.ParseResult.GetValueForOption(limitPriceOption);
    var stopPrice = context.ParseResult.GetValueForOption(stopPriceOption);
    var timeInForceStr = context.ParseResult.GetValueForOption(timeInForceOption);
    var startTime = context.ParseResult.GetValueForOption(startTimeOption);
    var expiryTime = context.ParseResult.GetValueForOption(expiryTimeOption);

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

    if (string.IsNullOrEmpty(typeStr))
    {
        Console.Error.WriteLine("Error: --type is required (MARKET, LIMIT, TWAP, VWAP, STOP_LIMIT, BLOCK, RFQ, PEG).");
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

    if (!Enum.TryParse<OrderType>(typeStr, true, out var orderType))
    {
        Console.Error.WriteLine($"Error: Invalid type '{typeStr}'. Must be one of: MARKET, LIMIT, TWAP, VWAP, STOP_LIMIT, BLOCK, RFQ, PEG.");
        Environment.ExitCode = 1;
        return;
    }

    TimeInForceType? timeInForce = null;
    if (!string.IsNullOrEmpty(timeInForceStr))
    {
        if (!Enum.TryParse<TimeInForceType>(timeInForceStr, true, out var parsedTimeInForce))
        {
            Console.Error.WriteLine($"Error: Invalid timeInForce '{timeInForceStr}'.");
            Environment.ExitCode = 1;
            return;
        }
        timeInForce = parsedTimeInForce;
    }

    try
    {
        Console.WriteLine($"Using Portfolio ID: {portfolioId}");

        var client = CoinbasePrimeClient.FromEnv();
        var ordersService = new OrdersService(client);

        var requestBuilder = new GetOrderPreviewRequest.GetOrderPreviewRequestBuilder()
            .WithPortfolioId(portfolioId)
            .WithProductId(productId)
            .WithSide(side)
            .WithType(orderType);

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

        if (!string.IsNullOrEmpty(stopPrice))
        {
            requestBuilder.WithStopPrice(stopPrice);
        }

        if (timeInForce.HasValue)
        {
            requestBuilder.WithTimeInForce(timeInForce.Value);
        }

        if (!string.IsNullOrEmpty(startTime))
        {
            requestBuilder.WithStartTime(startTime);
        }

        if (!string.IsNullOrEmpty(expiryTime))
        {
            requestBuilder.WithExpiryTime(expiryTime);
        }

        var request = requestBuilder.Build();

        PrettyPrinter.PrintResponse("GetOrderPreviewRequest", request);

        var response = ordersService.GetOrderPreview(request);

        PrettyPrinter.PrintResponse("GetOrderPreviewResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error getting order preview", ex);
        Environment.ExitCode = 1;
    }
});

return rootCommand.Invoke(args);
