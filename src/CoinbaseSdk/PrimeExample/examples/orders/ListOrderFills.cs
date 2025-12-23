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
using CoinbaseSdk.Prime.Common;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var portfolioIdOption = new Option<string?>(
    name: "--portfolioId",
    description: "The Portfolio ID");

var orderIdOption = new Option<string?>(
    name: "--orderId",
    description: "The Order ID to get fills for");

var rootCommand = new RootCommand("List fills for a specific order")
{
    portfolioIdOption,
    orderIdOption,
};

rootCommand.SetHandler((context) =>
{
    var portfolioId = context.ParseResult.GetValueForOption(portfolioIdOption);
    var orderId = context.ParseResult.GetValueForOption(orderIdOption);

    portfolioId ??= Environment.GetEnvironmentVariable("PRIME_PORTFOLIO_ID");

    if (string.IsNullOrEmpty(portfolioId))
    {
        Console.Error.WriteLine("Error: --portfolioId is required (or set PRIME_PORTFOLIO_ID env var).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(orderId))
    {
        Console.Error.WriteLine("Error: --orderId is required.");
        Environment.ExitCode = 1;
        return;
    }

    try
    {
        Console.WriteLine($"Using Portfolio ID: {portfolioId}");
        Console.WriteLine($"Getting fills for Order ID: {orderId}");

        var client = CoinbasePrimeClient.FromEnv();
        var ordersService = new OrdersService(client);

        var request = new ListOrderFillsRequest(portfolioId, orderId);

        PrettyPrinter.PrintResponse("ListOrderFillsRequest", request);

        var response = ordersService.ListOrderFills(request);

        PrettyPrinter.PrintResponse("ListOrderFillsResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error listing order fills", ex);
        Environment.ExitCode = 1;
    }
});

return rootCommand.Invoke(args);
