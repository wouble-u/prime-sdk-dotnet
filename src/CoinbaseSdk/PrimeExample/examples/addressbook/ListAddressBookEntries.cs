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

using CoinbaseSdk.Prime.AddressBook;
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
    description: "Filter by currency symbol (e.g., BTC, ETH)");

var searchOption = new Option<string?>(
    name: "--search",
    description: "Search term for filtering entries");

var rootCommand = new RootCommand("List address book entries for a portfolio")
{
    portfolioIdOption,
    currencySymbolOption,
    searchOption
};

rootCommand.SetHandler((portfolioId, currencySymbol, search) =>
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
        var addressBookService = new AddressBookService(client);

        var requestBuilder = new ListAddressBookEntriesRequest.ListAddressBookEntriesRequestBuilder()
            .WithPortfolioId(portfolioId);

        if (!string.IsNullOrEmpty(currencySymbol))
        {
            requestBuilder.WithCurrencySymbol(currencySymbol);
        }

        if (!string.IsNullOrEmpty(search))
        {
            requestBuilder.WithSearch(search);
        }

        var request = requestBuilder.Build();

        PrettyPrinter.PrintResponse("ListAddressBookEntriesRequest", request);

        var response = addressBookService.ListAddressBookEntries(request);

        PrettyPrinter.PrintResponse("ListAddressBookEntriesResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error listing address book entries", ex);
        Environment.ExitCode = 1;
    }
}, portfolioIdOption, currencySymbolOption, searchOption);

return rootCommand.Invoke(args);
