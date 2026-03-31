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
using CoinbaseSdk.Prime.Model;
using CoinbaseSdk.Prime.Model.Enums;
using CoinbaseSdk.Prime.Common;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var sourcePortfolioIdOption = new Option<string?>(
    name: "--sourcePortfolioId",
    description: "The source Portfolio ID");

var productIdOption = new Option<string?>(
    name: "--productId",
    description: "Product ID (e.g., BTC-USD)");

var orderIdsOption = new Option<string?>(
    name: "--orderIds",
    description: "Comma-separated list of order IDs");

var destinationPortfolioIdOption = new Option<string?>(
    name: "--destinationPortfolioId",
    description: "Destination portfolio ID for allocation leg");

var amountOption = new Option<string?>(
    name: "--amount",
    description: "Amount for allocation leg");

var sizeTypeOption = new Option<string?>(
    name: "--sizeType",
    description: "Size type (PERCENT or ABSOLUTE)");

var nettingIdOption = new Option<string?>(
    name: "--nettingId",
    description: "Client netting ID for grouping allocations");

var rootCommand = new RootCommand("Create a net allocation")
{
    sourcePortfolioIdOption,
    productIdOption,
    orderIdsOption,
    destinationPortfolioIdOption,
    amountOption,
    sizeTypeOption,
    nettingIdOption
};

rootCommand.SetHandler((context) =>
{
    var sourcePortfolioId = context.ParseResult.GetValueForOption(sourcePortfolioIdOption);
    var productId = context.ParseResult.GetValueForOption(productIdOption);
    var orderIdsStr = context.ParseResult.GetValueForOption(orderIdsOption);
    var destinationPortfolioId = context.ParseResult.GetValueForOption(destinationPortfolioIdOption);
    var amount = context.ParseResult.GetValueForOption(amountOption);
    var sizeTypeStr = context.ParseResult.GetValueForOption(sizeTypeOption);
    var nettingId = context.ParseResult.GetValueForOption(nettingIdOption);

    sourcePortfolioId ??= Environment.GetEnvironmentVariable("PRIME_PORTFOLIO_ID");

    if (string.IsNullOrEmpty(sourcePortfolioId))
    {
        Console.Error.WriteLine("Error: --sourcePortfolioId is required (or set PRIME_PORTFOLIO_ID env var).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(productId))
    {
        Console.Error.WriteLine("Error: --productId is required.");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(orderIdsStr))
    {
        Console.Error.WriteLine("Error: --orderIds is required.");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(destinationPortfolioId))
    {
        Console.Error.WriteLine("Error: --destinationPortfolioId is required.");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(amount))
    {
        Console.Error.WriteLine("Error: --amount is required.");
        Environment.ExitCode = 1;
        return;
    }

    AllocationSizeType sizeType = AllocationSizeType.PERCENT;
    if (!string.IsNullOrEmpty(sizeTypeStr))
    {
        if (!Enum.TryParse<AllocationSizeType>(sizeTypeStr, true, out sizeType))
        {
            Console.Error.WriteLine("Error: --sizeType must be PERCENT or ABSOLUTE.");
            Environment.ExitCode = 1;
            return;
        }
    }

    try
    {
        Console.WriteLine($"Using Source Portfolio ID: {sourcePortfolioId}");

        var client = CoinbasePrimeClient.FromEnv();
        var allocationsService = new AllocationsService(client);

        var orderIds = orderIdsStr.Split(',').Select(s => s.Trim()).ToArray();

        var allocationLeg = new AllocationLeg.Builder()
            .WithAllocationLegId(Guid.NewGuid().ToString())
            .WithDestinationPortfolioId(destinationPortfolioId)
            .WithAmount(amount)
            .Build();

        var requestBuilder = new CreateNetAllocationRequest.CreateNetAllocationRequestBuilder()
            .WithAllocationId(Guid.NewGuid().ToString())
            .WithSourcePortfolioId(sourcePortfolioId)
            .WithProductId(productId)
            .WithOrderIds(orderIds)
            .WithAllocationLegs([allocationLeg])
            .WithSizeType(sizeType);

        if (!string.IsNullOrEmpty(nettingId))
        {
            requestBuilder.WithNettingId(nettingId);
        }

        var request = requestBuilder.Build();

        PrettyPrinter.PrintResponse("CreateNetAllocationRequest", request);

        var response = allocationsService.CreateNetAllocation(request);

        PrettyPrinter.PrintResponse("CreateNetAllocationResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error creating net allocation", ex);
        Environment.ExitCode = 1;
    }
});

return rootCommand.Invoke(args);
