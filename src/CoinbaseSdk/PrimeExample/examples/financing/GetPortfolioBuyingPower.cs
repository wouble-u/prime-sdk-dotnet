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

var baseCurrencyOption = new Option<string?>(
    name: "--baseCurrency",
    description: "The base currency symbol (e.g., BTC)");

var quoteCurrencyOption = new Option<string?>(
    name: "--quoteCurrency",
    description: "The quote currency symbol (e.g., USD)");

var rootCommand = new RootCommand("Get buying power for a portfolio")
{
    portfolioIdOption,
    baseCurrencyOption,
    quoteCurrencyOption,
};

rootCommand.SetHandler((portfolioId, baseCurrency, quoteCurrency) =>
{
    portfolioId ??= Environment.GetEnvironmentVariable("PRIME_PORTFOLIO_ID");

    if (string.IsNullOrEmpty(portfolioId))
    {
        Console.Error.WriteLine("Error: --portfolioId is required (or set PRIME_PORTFOLIO_ID env var).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(baseCurrency))
    {
        Console.Error.WriteLine("Error: --baseCurrency is required (e.g., BTC).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(quoteCurrency))
    {
        Console.Error.WriteLine("Error: --quoteCurrency is required (e.g., USD).");
        Environment.ExitCode = 1;
        return;
    }

    try
    {
        Console.WriteLine($"Using Portfolio ID: {portfolioId}");

        var client = CoinbasePrimeClient.FromEnv();
        var financingService = new FinancingService(client);

        var request = new GetPortfolioBuyingPowerRequest(portfolioId)
        {
            BaseCurrency = baseCurrency,
            QuoteCurrency = quoteCurrency
        };

        PrettyPrinter.PrintResponse("GetPortfolioBuyingPowerRequest", request);

        var response = financingService.GetPortfolioBuyingPower(request);

        PrettyPrinter.PrintResponse("GetPortfolioBuyingPowerResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error getting portfolio buying power", ex);
        Environment.ExitCode = 1;
    }
}, portfolioIdOption, baseCurrencyOption, quoteCurrencyOption);

return rootCommand.Invoke(args);
