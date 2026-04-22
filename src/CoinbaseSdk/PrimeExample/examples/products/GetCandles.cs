#!/usr/bin/env -S dotnet run --file
/*
 * Copyright 2026-present Coinbase Global, Inc.
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

using CoinbaseSdk.Prime.Products;
using CoinbaseSdk.Prime.Client;
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

var startTimeOption = new Option<string?>(
    name: "--startTime",
    description: "Start time in ISO 8601 format (e.g., 2026-01-01T00:00:00Z)");

var endTimeOption = new Option<string?>(
    name: "--endTime",
    description: "End time in ISO 8601 format (e.g., 2026-01-02T00:00:00Z)");

var granularityOption = new Option<string?>(
    name: "--granularity",
    description: "Candle granularity (e.g., ONE_MINUTE, FIVE_MINUTE, ONE_HOUR, ONE_DAY)");

var rootCommand = new RootCommand("Get OHLCV candles for a portfolio product")
{
    portfolioIdOption,
    productIdOption,
    startTimeOption,
    endTimeOption,
    granularityOption,
};

rootCommand.SetHandler((context) =>
{
    var portfolioId = context.ParseResult.GetValueForOption(portfolioIdOption);
    var productId = context.ParseResult.GetValueForOption(productIdOption);
    var startTime = context.ParseResult.GetValueForOption(startTimeOption);
    var endTime = context.ParseResult.GetValueForOption(endTimeOption);
    var granularity = context.ParseResult.GetValueForOption(granularityOption);

    portfolioId ??= Environment.GetEnvironmentVariable("PRIME_PORTFOLIO_ID");

    if (string.IsNullOrEmpty(portfolioId))
    {
        Console.Error.WriteLine("Error: --portfolioId is required (or set PRIME_PORTFOLIO_ID env var).");
        Environment.ExitCode = 1;
        return;
    }

    try
    {
        Console.WriteLine($"Using Portfolio ID: {portfolioId}");

        var client = CoinbasePrimeClient.FromEnv();
        var productsService = new ProductsService(client);

        var requestBuilder = new GetCandlesRequest.GetCandlesRequestBuilder()
            .WithPortfolioId(portfolioId);

        if (!string.IsNullOrEmpty(productId))
        {
            requestBuilder.WithProductId(productId);
        }

        if (!string.IsNullOrEmpty(startTime))
        {
            requestBuilder.WithStartTime(startTime);
        }

        if (!string.IsNullOrEmpty(endTime))
        {
            requestBuilder.WithEndTime(endTime);
        }

        if (!string.IsNullOrEmpty(granularity))
        {
            requestBuilder.WithGranularity(granularity);
        }

        var request = requestBuilder.Build();

        PrettyPrinter.PrintResponse("GetCandlesRequest", request);

        var response = productsService.GetCandles(request);

        PrettyPrinter.PrintResponse("GetCandlesResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error getting candles", ex);
        Environment.ExitCode = 1;
    }
});

return rootCommand.Invoke(args);
