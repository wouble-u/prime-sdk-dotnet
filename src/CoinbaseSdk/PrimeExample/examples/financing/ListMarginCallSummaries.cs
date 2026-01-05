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

using CoinbaseSdk.Prime.Financing;
using CoinbaseSdk.Prime.Client;
using CoinbaseSdk.Prime.Common;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var entityIdOption = new Option<string?>(
    name: "--entityId",
    description: "The Entity ID");

var startDateOption = new Option<string?>(
    name: "--startDate",
    description: "Start date (RFC3339 format, within 3 months)");

var endDateOption = new Option<string?>(
    name: "--endDate",
    description: "End date (RFC3339 format)");

var rootCommand = new RootCommand("List margin call summaries for an entity")
{
    entityIdOption,
    startDateOption,
    endDateOption,
};

rootCommand.SetHandler((entityId, startDate, endDate) =>
{
    entityId ??= Environment.GetEnvironmentVariable("PRIME_ENTITY_ID");

    if (string.IsNullOrEmpty(entityId))
    {
        Console.Error.WriteLine("Error: --entityId is required (or set PRIME_ENTITY_ID env var).");
        Environment.ExitCode = 1;
        return;
    }

    try
    {
        Console.WriteLine($"Using Entity ID: {entityId}");

        var client = CoinbasePrimeClient.FromEnv();
        var financingService = new FinancingService(client);

        var request = new ListMarginCallSummariesRequest(entityId);

        if (!string.IsNullOrEmpty(startDate))
        {
            request.StartDate = startDate;
        }

        if (!string.IsNullOrEmpty(endDate))
        {
            request.EndDate = endDate;
        }

        PrettyPrinter.PrintResponse("ListMarginCallSummariesRequest", request);

        var response = financingService.ListMarginCallSummaries(request);

        PrettyPrinter.PrintResponse("ListMarginCallSummariesResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error listing margin call summaries", ex);
        Environment.ExitCode = 1;
    }
}, entityIdOption, startDateOption, endDateOption);

return rootCommand.Invoke(args);
