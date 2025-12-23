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

using CoinbaseSdk.Prime.Allocations;
using CoinbaseSdk.Prime.Client;
using CoinbaseSdk.Prime.Model.Enums;
using CoinbaseSdk.Prime.Common;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var portfolioIdOption = new Option<string?>(
    name: "--portfolioId",
    description: "The Portfolio ID");

var productIdsOption = new Option<string?>(
    name: "--productIds",
    description: "Comma-separated list of product IDs (e.g., BTC-USD,ETH-USD)");

var startDateOption = new Option<string?>(
    name: "--startDate",
    description: "Start date (required, RFC3339 format)");

var endDateOption = new Option<string?>(
    name: "--endDate",
    description: "End date (RFC3339 format)");

var orderSideOption = new Option<string?>(
    name: "--orderSide",
    description: "Order side (BUY or SELL)");

var rootCommand = new RootCommand("List allocations for a portfolio")
{
    portfolioIdOption,
    productIdsOption,
    startDateOption,
    endDateOption,
    orderSideOption
};

rootCommand.SetHandler((portfolioId, productIdsStr, startDate, endDate, orderSideStr) =>
{
    portfolioId ??= Environment.GetEnvironmentVariable("PRIME_PORTFOLIO_ID");

    if (string.IsNullOrEmpty(portfolioId))
    {
        Console.Error.WriteLine("Error: --portfolioId is required (or set PRIME_PORTFOLIO_ID env var).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(startDate))
    {
        Console.Error.WriteLine("Error: --startDate is required.");
        Environment.ExitCode = 1;
        return;
    }

    try
    {
        Console.WriteLine($"Using Portfolio ID: {portfolioId}");

        var client = CoinbasePrimeClient.FromEnv();
        var allocationsService = new AllocationsService(client);

        var requestBuilder = new GetPortfolioAllocationsRequest.Builder()
            .WithPortfolioId(portfolioId)
            .WithStartDate(startDate);

        if (!string.IsNullOrEmpty(productIdsStr))
        {
            var productIds = productIdsStr.Split(',').Select(s => s.Trim()).ToArray();
            requestBuilder.WithProductIds(productIds);
        }

        if (!string.IsNullOrEmpty(endDate))
        {
            requestBuilder.WithEndDate(endDate);
        }

        if (!string.IsNullOrEmpty(orderSideStr))
        {
            if (Enum.TryParse<OrderSide>(orderSideStr, true, out var orderSide))
            {
                requestBuilder.WithOrderSide(orderSide);
            }
            else
            {
                Console.Error.WriteLine($"Invalid order side: {orderSideStr}. Must be BUY or SELL.");
                Environment.ExitCode = 1;
                return;
            }
        }

        var request = requestBuilder.Build();

        PrettyPrinter.PrintResponse("GetPortfolioAllocationsRequest", request);

        var response = allocationsService.GetPortfolioAllocations(request);

        PrettyPrinter.PrintResponse("GetPortfolioAllocationsResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error listing portfolio allocations", ex);
        Environment.ExitCode = 1;
    }
}, portfolioIdOption, productIdsOption, startDateOption, endDateOption, orderSideOption);

return rootCommand.Invoke(args);
