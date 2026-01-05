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

using CoinbaseSdk.Prime.Wallets;
using CoinbaseSdk.Prime.Client;
using CoinbaseSdk.Prime.Model.Enums;
using CoinbaseSdk.Prime.Common;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var portfolioIdOption = new Option<string?>(
    name: "--portfolioId",
    description: "The Portfolio ID");

var typeOption = new Option<string?>(
    name: "--type",
    description: "Wallet type filter (VAULT, TRADING, QC, ONCHAIN)");

var symbolsOption = new Option<string?>(
    name: "--symbols",
    description: "Comma-separated list of symbols to filter");

var rootCommand = new RootCommand("List wallets for a portfolio")
{
    portfolioIdOption,
    typeOption,
    symbolsOption,
};

rootCommand.SetHandler((portfolioId, typeStr, symbolsStr) =>
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

        // Create client and service
        var client = CoinbasePrimeClient.FromEnv();
        var walletsService = new WalletsService(client);

        // Build request
        var request = new ListWalletsRequest(portfolioId);

        if (!string.IsNullOrEmpty(typeStr))
        {
            if (!Enum.TryParse<WalletType>(typeStr, true, out var walletType))
            {
                Console.Error.WriteLine($"Error: Invalid type '{typeStr}'. Must be one of: VAULT, TRADING, QC, ONCHAIN.");
                Environment.ExitCode = 1;
                return;
            }
            request.Type = walletType;
        }

        if (!string.IsNullOrEmpty(symbolsStr))
        {
            var symbols = symbolsStr.Split(',').Select(s => s.Trim()).ToArray();
            request.Symbols = symbols;
        }

        PrettyPrinter.PrintResponse("ListWalletsRequest", request);

        // Execute request
        var response = walletsService.ListWallets(request);

        // Print response
        PrettyPrinter.PrintResponse("ListWalletsResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error listing wallets", ex);
        Environment.ExitCode = 1;
    }
}, portfolioIdOption, typeOption, symbolsOption);

return rootCommand.Invoke(args);
