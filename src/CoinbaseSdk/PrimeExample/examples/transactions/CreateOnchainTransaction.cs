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
using CoinbaseSdk.Prime.Client;
using CoinbaseSdk.Prime.Common;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var portfolioIdOption = new Option<string?>(
    name: "--portfolioId",
    description: "The Portfolio ID");

var walletIdOption = new Option<string?>(
    name: "--walletId",
    description: "The Wallet ID");

var rawUnsignedTxnOption = new Option<string?>(
    name: "--rawUnsignedTxn",
    description: "Raw Unsigned Txn");

var rootCommand = new RootCommand("Create Onchain Transaction")
{
    portfolioIdOption,
    walletIdOption,
    rawUnsignedTxnOption,
};

rootCommand.SetHandler((context) =>
{
    var portfolioId = context.ParseResult.GetValueForOption(portfolioIdOption);
    var walletId = context.ParseResult.GetValueForOption(walletIdOption);
    var rawUnsignedTxn = context.ParseResult.GetValueForOption(rawUnsignedTxnOption);

    portfolioId ??= Environment.GetEnvironmentVariable("PRIME_PORTFOLIO_ID");

    if (string.IsNullOrEmpty(portfolioId))
    {
        Console.Error.WriteLine("Error: --portfolioId is required (or set PRIME_PORTFOLIO_ID env var).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(walletId))
    {
        Console.Error.WriteLine("Error: --walletId is required.");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(rawUnsignedTxn))
    {
        Console.Error.WriteLine("Error: --rawUnsignedTxn is required.");
        Environment.ExitCode = 1;
        return;
    }

    try
    {
        Console.WriteLine($"Using PortfolioId: {portfolioId}");
        Console.WriteLine($"Using WalletId: {walletId}");

        var client = CoinbasePrimeClient.FromEnv();
        var transactionsService = new TransactionsService(client);

        var request = new CreateOnchainTransactionRequest.CreateOnchainTransactionRequestBuilder()
            .WithPortfolioId(portfolioId)
            .WithWalletId(walletId)
            .WithRawUnsignedTxn(rawUnsignedTxn)
            .Build();

        PrettyPrinter.PrintResponse("CreateOnchainTransactionRequest", request);

        var response = transactionsService.CreateOnchainTransaction(request);

        PrettyPrinter.PrintResponse("CreateOnchainTransactionResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error calling CreateOnchainTransaction", ex);
        Environment.ExitCode = 1;
    }
});

return rootCommand.Invoke(args);
