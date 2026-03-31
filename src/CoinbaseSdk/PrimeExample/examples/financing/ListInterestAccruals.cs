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

var portfolioIdOption = new Option<string?>(
    name: "--portfolioId",
    description: "Optional Portfolio ID filter");

var startDateOption = new Option<string?>(
    name: "--startDate",
    description: "Start date (RFC3339 format)");

var endDateOption = new Option<string?>(
    name: "--endDate",
    description: "End date (RFC3339 format)");

var rootCommand = new RootCommand("List interest accruals for an entity")
{
    entityIdOption,
    portfolioIdOption,
    startDateOption,
    endDateOption,
};

rootCommand.SetHandler((entityId, portfolioId, startDate, endDate) =>
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

        var builder = new ListInterestAccrualsRequest.ListInterestAccrualsRequestBuilder(entityId);

        if (!string.IsNullOrEmpty(portfolioId))
        {
            builder.WithPortfolioId(portfolioId);
        }

        if (!string.IsNullOrEmpty(startDate))
        {
            builder.WithStartDate(startDate);
        }

        if (!string.IsNullOrEmpty(endDate))
        {
            builder.WithEndDate(endDate);
        }

        var request = builder.Build();

        PrettyPrinter.PrintResponse("ListInterestAccrualsRequest", request);

        var response = financingService.ListInterestAccruals(request);

        PrettyPrinter.PrintResponse("ListInterestAccrualsResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error listing interest accruals", ex);
        Environment.ExitCode = 1;
    }
}, entityIdOption, portfolioIdOption, startDateOption, endDateOption);

return rootCommand.Invoke(args);
