#!/usr/bin/env -S dotnet run --file
/*
 * Copyright 2026-present Coinbase Global, Inc.
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

using CoinbaseSdk.Prime.Transactions;
using CoinbaseSdk.Prime.Model;
using CoinbaseSdk.Prime.Model.Enums;
using CoinbaseSdk.Prime.Client;
using CoinbaseSdk.Prime.Common;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var portfolioIdOption = new Option<string?>(
    name: "--portfolioId",
    description: "The Portfolio ID");

var transferTypeOption = new Option<string?>(
    name: "--transferType",
    description: "Advanced transfer type (e.g., BLIND_MATCH)");

var rootCommand = new RootCommand("Create an advanced transfer for a portfolio")
{
    portfolioIdOption,
    transferTypeOption,
};

rootCommand.SetHandler((context) =>
{
    var portfolioId = context.ParseResult.GetValueForOption(portfolioIdOption);
    var transferTypeStr = context.ParseResult.GetValueForOption(transferTypeOption);

    portfolioId ??= Environment.GetEnvironmentVariable("PRIME_PORTFOLIO_ID");

    if (string.IsNullOrEmpty(portfolioId))
    {
        Console.Error.WriteLine("Error: --portfolioId is required (or set PRIME_PORTFOLIO_ID env var).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(transferTypeStr))
    {
        Console.Error.WriteLine("Error: --transferType is required.");
        Environment.ExitCode = 1;
        return;
    }

    if (!Enum.TryParse<AdvancedTransferType>(transferTypeStr, true, out var transferType))
    {
        Console.Error.WriteLine($"Error: Invalid transferType '{transferTypeStr}'.");
        Environment.ExitCode = 1;
        return;
    }

    try
    {
        Console.WriteLine($"Using Portfolio ID: {portfolioId}");

        var client = CoinbasePrimeClient.FromEnv();
        var transactionsService = new TransactionsService(client);

        var advancedTransfer = new AdvancedTransfer.Builder()
            .WithType(transferType)
            .Build();

        var request = new CreateAdvancedTransferRequest.CreateAdvancedTransferRequestBuilder()
            .WithPortfolioId(portfolioId)
            .WithAdvancedTransfer(advancedTransfer)
            .Build();

        PrettyPrinter.PrintResponse("CreateAdvancedTransferRequest", request);

        var response = transactionsService.CreateAdvancedTransfer(request);

        PrettyPrinter.PrintResponse("CreateAdvancedTransferResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error creating advanced transfer", ex);
        Environment.ExitCode = 1;
    }
});

return rootCommand.Invoke(args);
