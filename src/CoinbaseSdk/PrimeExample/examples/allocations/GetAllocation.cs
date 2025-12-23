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
using CoinbaseSdk.Prime.Common;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var portfolioIdOption = new Option<string?>(
    name: "--portfolioId",
    description: "The Portfolio ID");

var allocationIdOption = new Option<string?>(
    name: "--allocationId",
    description: "The Allocation ID");

var rootCommand = new RootCommand("Get an allocation by ID")
{
    portfolioIdOption,
    allocationIdOption
};

rootCommand.SetHandler((portfolioId, allocationId) =>
{
    portfolioId ??= Environment.GetEnvironmentVariable("PRIME_PORTFOLIO_ID");

    if (string.IsNullOrEmpty(portfolioId))
    {
        Console.Error.WriteLine("Error: --portfolioId is required (or set PRIME_PORTFOLIO_ID env var).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(allocationId))
    {
        Console.Error.WriteLine("Error: --allocationId is required.");
        Environment.ExitCode = 1;
        return;
    }

    try
    {
        Console.WriteLine($"Using Portfolio ID: {portfolioId}");

        var client = CoinbasePrimeClient.FromEnv();
        var allocationsService = new AllocationsService(client);

        var request = new GetAllocationRequest(portfolioId, allocationId);

        PrettyPrinter.PrintResponse("GetAllocationRequest", request);

        var response = allocationsService.GetAllocation(request);

        PrettyPrinter.PrintResponse("GetAllocationResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error getting allocation", ex);
        Environment.ExitCode = 1;
    }
}, portfolioIdOption, allocationIdOption);

return rootCommand.Invoke(args);
