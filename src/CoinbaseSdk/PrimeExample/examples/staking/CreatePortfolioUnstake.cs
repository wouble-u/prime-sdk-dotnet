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

using CoinbaseSdk.Prime.Staking;
using CoinbaseSdk.Prime.Client;
using CoinbaseSdk.Prime.Common;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var portfolioIdOption = new Option<string?>(
    name: "--portfolioId",
    description: "The Portfolio ID");

var currencySymbolOption = new Option<string?>(
    name: "--currencySymbol",
    description: "Currency symbol (e.g., ETH)");

var amountOption = new Option<string?>(
    name: "--amount",
    description: "Amount to unstake");

var rootCommand = new RootCommand("Create a portfolio-level unstake")
{
    portfolioIdOption,
    currencySymbolOption,
    amountOption
};

rootCommand.SetHandler((portfolioId, currencySymbol, amount) =>
{
    portfolioId ??= Environment.GetEnvironmentVariable("PRIME_PORTFOLIO_ID");

    if (string.IsNullOrEmpty(portfolioId))
    {
        Console.Error.WriteLine("Error: --portfolioId is required (or set PRIME_PORTFOLIO_ID env var).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(currencySymbol))
    {
        Console.Error.WriteLine("Error: --currencySymbol is required.");
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
        var stakingService = new StakingService(client);

        var request = new CreatePortfolioUnstakeRequest(portfolioId)
        {
            IdempotencyKey = Guid.NewGuid().ToString(),
            CurrencySymbol = currencySymbol,
            Amount = amount
        };

        PrettyPrinter.PrintResponse("CreatePortfolioUnstakeRequest", request);

        var response = stakingService.CreatePortfolioUnstake(request);

        PrettyPrinter.PrintResponse("CreatePortfolioUnstakeResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error creating portfolio unstake", ex);
        Environment.ExitCode = 1;
    }
}, portfolioIdOption, currencySymbolOption, amountOption);

return rootCommand.Invoke(args);
