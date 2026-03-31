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

var transactionIdsOption = new Option<string?>(
    name: "--transactionIds",
    description: "Comma-separated list of transaction IDs to query validators for");

var rootCommand = new RootCommand("List ETH 0x02 validators for wallet-level stake transactions")
{
    portfolioIdOption,
    transactionIdsOption
};

rootCommand.SetHandler((portfolioId, transactionIdsStr) =>
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
        var stakingService = new StakingService(client);

        var requestBuilder = new ListTransactionValidatorsRequest.ListTransactionValidatorsRequestBuilder()
            .WithPortfolioId(portfolioId);

        if (!string.IsNullOrEmpty(transactionIdsStr))
        {
            var transactionIds = transactionIdsStr.Split(',').Select(s => s.Trim()).ToArray();
            requestBuilder.WithTransactionIds(transactionIds);
        }

        var request = requestBuilder.Build();

        PrettyPrinter.PrintResponse("ListTransactionValidatorsRequest", request);

        var response = stakingService.ListTransactionValidators(request);

        PrettyPrinter.PrintResponse("ListTransactionValidatorsResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error listing transaction validators", ex);
        Environment.ExitCode = 1;
    }
}, portfolioIdOption, transactionIdsOption);

return rootCommand.Invoke(args);
