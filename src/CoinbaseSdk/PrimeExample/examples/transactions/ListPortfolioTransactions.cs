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

using CoinbaseSdk.Prime.Transactions;
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
    description: "Comma-separated list of symbols");

var typesOption = new Option<string?>(
    name: "--types",
    description: "Comma-separated list of transaction types (DEPOSIT, WITHDRAWAL, etc.)");

var startTimeOption = new Option<string?>(
    name: "--startTime",
    description: "Start time (UTC)");

var endTimeOption = new Option<string?>(
    name: "--endTime",
    description: "End time (UTC)");

var rootCommand = new RootCommand("List transactions for a portfolio")
{
    portfolioIdOption,
    symbolsOption,
    typesOption,
    startTimeOption,
    endTimeOption,
};

rootCommand.SetHandler((portfolioId, symbolsStr, typesStr, startTime, endTime) =>
{
    // Fallback to environment variable for portfolioId
    if (string.IsNullOrEmpty(portfolioId))
    {
        portfolioId = Environment.GetEnvironmentVariable("PRIME_PORTFOLIO_ID");
    }

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
        var transactionsService = new TransactionsService(client);

        // Build request
        var requestBuilder = new ListPortfolioTransactionsRequest.ListPortfolioTransactionsRequestBuilder()
            .WithPortfolioId(portfolioId);

        if (!string.IsNullOrEmpty(symbolsStr))
        {
            var symbols = symbolsStr.Split(',').Select(s => s.Trim()).ToArray();
            requestBuilder.WithSymbols(symbols);
        }

        if (!string.IsNullOrEmpty(typesStr))
        {
            var typeStrings = typesStr.Split(',').Select(s => s.Trim()).ToArray();
            var types = new List<TransactionType>();
            foreach (var typeStr in typeStrings)
            {
                if (Enum.TryParse<TransactionType>(typeStr, true, out var transactionType))
                {
                    types.Add(transactionType);
                }
                else
                {
                    Console.Error.WriteLine($"Invalid transaction type: {typeStr}");
                    Environment.ExitCode = 1;
                    return;
                }
            }
            requestBuilder.WithTypes([.. types]);
        }

        if (!string.IsNullOrEmpty(startTime))
        {
            requestBuilder.WithStartTime(startTime);
        }

        if (!string.IsNullOrEmpty(endTime))
        {
            requestBuilder.WithEndTime(endTime);
        }

        var request = requestBuilder.Build();

        PrettyPrinter.PrintResponse("ListPortfolioTransactionsRequest", request);

        // Execute request
        var response = transactionsService.ListPortfolioTransactions(request);

        // Print response
        PrettyPrinter.PrintResponse("ListPortfolioTransactionsResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error listing portfolio transactions", ex);
        Environment.ExitCode = 1;
    }
}, portfolioIdOption, symbolsOption, typesOption, startTimeOption, endTimeOption);

return rootCommand.Invoke(args);
