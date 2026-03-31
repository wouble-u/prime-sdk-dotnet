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

using CoinbaseSdk.Prime.Balances;
using CoinbaseSdk.Prime.Client;
using CoinbaseSdk.Prime.Model.Enums;
using CoinbaseSdk.Prime.Common;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var portfolioIdOption = new Option<string?>(
    name: "--portfolioId",
    description: "The Portfolio ID");

var symbolsOption = new Option<string?>(
    name: "--symbols",
    description: "Comma-separated list of symbols (e.g., BTC,ETH)");

var balanceTypeOption = new Option<string?>(
    name: "--balanceType",
    description: "Balance type (TRADING_BALANCES, VAULT_BALANCES, TOTAL_BALANCES)");

var rootCommand = new RootCommand("List balances for a portfolio")
{
    portfolioIdOption,
    symbolsOption,
    balanceTypeOption
};

rootCommand.SetHandler((portfolioId, symbolsStr, balanceTypeStr) =>
{
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
        var balancesService = new BalancesService(client);

        var requestBuilder = new ListPortfolioBalancesRequest.ListPortfolioBalancesRequestBuilder()
            .WithPortfolioId(portfolioId);

        if (!string.IsNullOrEmpty(symbolsStr))
        {
            var symbols = symbolsStr.Split(',').Select(s => s.Trim()).ToArray();
            requestBuilder.WithSymbols(symbols);
        }

        if (!string.IsNullOrEmpty(balanceTypeStr))
        {
            if (Enum.TryParse<PortfolioBalanceType>(balanceTypeStr, true, out var balanceType))
            {
                requestBuilder.WithBalanceType(balanceType);
            }
            else
            {
                Console.Error.WriteLine($"Invalid balance type: {balanceTypeStr}");
                Environment.ExitCode = 1;
                return;
            }
        }

        var request = requestBuilder.Build();

        PrettyPrinter.PrintResponse("ListPortfolioBalancesRequest", request);

        var response = balancesService.ListPortfolioBalances(request);

        PrettyPrinter.PrintResponse("ListPortfolioBalancesResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error listing portfolio balances", ex);
        Environment.ExitCode = 1;
    }
}, portfolioIdOption, symbolsOption, balanceTypeOption);

return rootCommand.Invoke(args);
