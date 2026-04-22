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

var portfolioIdOption = new Option<string?>(
    name: "--portfolioId",
    description: "The Portfolio ID");

var symbolOption = new Option<string?>(
    name: "--symbol",
    description: "The currency symbol (e.g., BTC)");

var amountOption = new Option<string?>(
    name: "--amount",
    description: "The locate amount");

var locateDateOption = new Option<string?>(
    name: "--locateDate",
    description: "The locate date (YYYY-MM-DD format, optional)");

var rootCommand = new RootCommand("Create new locates for a portfolio")
{
    portfolioIdOption,
    symbolOption,
    amountOption,
    locateDateOption,
};

rootCommand.SetHandler((portfolioId, symbol, amount, locateDate) =>
{
    portfolioId ??= Environment.GetEnvironmentVariable("PRIME_PORTFOLIO_ID");

    if (string.IsNullOrEmpty(portfolioId))
    {
        Console.Error.WriteLine("Error: --portfolioId is required (or set PRIME_PORTFOLIO_ID env var).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(symbol))
    {
        Console.Error.WriteLine("Error: --symbol is required (e.g., BTC).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(amount))
    {
        Console.Error.WriteLine("Error: --amount is required.");
        Environment.ExitCode = 1;
        return;
    }

    try
    {
        Console.WriteLine($"Using Portfolio ID: {portfolioId}");

        var client = CoinbasePrimeClient.FromEnv();
        var financingService = new FinancingService(client);

        var builder = new CreateNewLocatesRequest.CreateNewLocatesRequestBuilder()
            .WithSymbol(symbol)
            .WithAmount(amount);

        if (!string.IsNullOrEmpty(locateDate))
        {
            builder.WithLocateDate(locateDate);
        }

        var request = builder.Build(portfolioId);

        PrettyPrinter.PrintResponse("CreateNewLocatesRequest", request);

        var response = financingService.CreateNewLocates(request);

        PrettyPrinter.PrintResponse("CreateNewLocatesResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error creating new locates", ex);
        Environment.ExitCode = 1;
    }
}, portfolioIdOption, symbolOption, amountOption, locateDateOption);

return rootCommand.Invoke(args);
