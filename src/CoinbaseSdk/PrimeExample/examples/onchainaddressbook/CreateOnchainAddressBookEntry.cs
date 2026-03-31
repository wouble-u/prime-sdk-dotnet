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

using CoinbaseSdk.Prime.OnchainAddressBook;
using CoinbaseSdk.Prime.Client;
using CoinbaseSdk.Prime.Common;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var portfolioIdOption = new Option<string?>(
    name: "--portfolioId",
    description: "The Portfolio ID");

var addressGroupOption = new Option<string?>(
    name: "--addressGroup",
    description: "Address Group");

var rootCommand = new RootCommand("Create Onchain Address Book Entry")
{
    portfolioIdOption,
    addressGroupOption,
};

rootCommand.SetHandler((context) =>
{
    var portfolioId = context.ParseResult.GetValueForOption(portfolioIdOption);
    var addressGroup = context.ParseResult.GetValueForOption(addressGroupOption);

    portfolioId ??= Environment.GetEnvironmentVariable("PRIME_PORTFOLIO_ID");

    if (string.IsNullOrEmpty(portfolioId))
    {
        Console.Error.WriteLine("Error: --portfolioId is required (or set PRIME_PORTFOLIO_ID env var).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(addressGroup))
    {
        Console.Error.WriteLine("Error: --addressGroup is required.");
        Environment.ExitCode = 1;
        return;
    }

    try
    {
        Console.WriteLine($"Using PortfolioId: {portfolioId}");

        var client = CoinbasePrimeClient.FromEnv();
        var onchainAddressBookService = new OnchainAddressBookService(client);

        var request = new CreateOnchainAddressBookEntryRequest.CreateOnchainAddressBookEntryRequestBuilder()
            .WithPortfolioId(portfolioId)
            .WithAddressGroup(addressGroup)
            .Build();

        PrettyPrinter.PrintResponse("CreateOnchainAddressBookEntryRequest", request);

        var response = onchainAddressBookService.CreateOnchainAddressBookEntry(request);

        PrettyPrinter.PrintResponse("CreateOnchainAddressBookEntryResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error calling CreateOnchainAddressBookEntry", ex);
        Environment.ExitCode = 1;
    }
});

return rootCommand.Invoke(args);
