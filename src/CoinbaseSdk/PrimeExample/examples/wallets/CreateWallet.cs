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

var nameOption = new Option<string?>(
    name: "--name",
    description: "The wallet name");

var symbolOption = new Option<string?>(
    name: "--symbol",
    description: "The asset symbol (e.g., BTC, ETH)");

var typeOption = new Option<string?>(
    name: "--type",
    description: "Wallet type (VAULT, TRADING, QC, ONCHAIN)");

var rootCommand = new RootCommand("Create a new wallet")
{
    portfolioIdOption,
    nameOption,
    symbolOption,
    typeOption,
};

rootCommand.SetHandler((portfolioId, name, symbol, typeStr) =>
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
        Console.Error.WriteLine("Error: --symbol is required (e.g., BTC, ETH).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(typeStr))
    {
        Console.Error.WriteLine("Error: --type is required (VAULT, TRADING, QC, ONCHAIN).");
        Environment.ExitCode = 1;
        return;
    }

    if (!Enum.TryParse<WalletType>(typeStr, true, out var walletType))
    {
        Console.Error.WriteLine($"Error: Invalid type '{typeStr}'. Must be one of: VAULT, TRADING, QC, ONCHAIN.");
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
        var request = new CreateWalletRequest(portfolioId)
        {
            Name = name,
            Symbol = symbol,
            Type = walletType
        };

        PrettyPrinter.PrintResponse("CreateWalletRequest", request);

        // Execute request
        var response = walletsService.CreateWallet(request);

        // Print response
        PrettyPrinter.PrintResponse("CreateWalletResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error creating wallet", ex);
        Environment.ExitCode = 1;
    }
}, portfolioIdOption, nameOption, symbolOption, typeOption);

return rootCommand.Invoke(args);
