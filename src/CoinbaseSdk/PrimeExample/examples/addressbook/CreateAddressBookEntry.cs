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

var addressOption = new Option<string?>(
    name: "--address",
    description: "The crypto address to add");

var currencySymbolOption = new Option<string?>(
    name: "--currencySymbol",
    description: "Currency symbol (e.g., BTC, ETH)");

var nameOption = new Option<string?>(
    name: "--name",
    description: "Name for the address book entry");

var accountIdentifierOption = new Option<string?>(
    name: "--accountIdentifier",
    description: "Optional account identifier");

var rootCommand = new RootCommand("Create a new address book entry")
{
    portfolioIdOption,
    addressOption,
    currencySymbolOption,
    nameOption,
    accountIdentifierOption
};

rootCommand.SetHandler((portfolioId, address, currencySymbol, name, accountIdentifier) =>
{
    portfolioId ??= Environment.GetEnvironmentVariable("PRIME_PORTFOLIO_ID");

    if (string.IsNullOrEmpty(portfolioId))
    {
        Console.Error.WriteLine("Error: --portfolioId is required (or set PRIME_PORTFOLIO_ID env var).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(address))
    {
        Console.Error.WriteLine("Error: --address is required.");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(currencySymbol))
    {
        Console.Error.WriteLine("Error: --currencySymbol is required.");
        Environment.ExitCode = 1;
        return;
    }

    try
    {
        Console.WriteLine($"Using Portfolio ID: {portfolioId}");

        var client = CoinbasePrimeClient.FromEnv();
        var addressBookService = new AddressBookService(client);

        var requestBuilder = new CreateAddressBookEntryRequest.Builder()
            .WithPortfolioId(portfolioId)
            .WithAddress(address)
            .WithCurrencySymbol(currencySymbol);

        if (!string.IsNullOrEmpty(name))
        {
            requestBuilder.WithName(name);
        }

        if (!string.IsNullOrEmpty(accountIdentifier))
        {
            requestBuilder.WithAccountIdentifier(accountIdentifier);
        }

        var request = requestBuilder.Build();

        PrettyPrinter.PrintResponse("CreateAddressBookEntryRequest", request);

        var response = addressBookService.CreateAddressBookEntry(request);

        PrettyPrinter.PrintResponse("CreateAddressBookEntryResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error creating address book entry", ex);
        Environment.ExitCode = 1;
    }
}, portfolioIdOption, addressOption, currencySymbolOption, nameOption, accountIdentifierOption);

return rootCommand.Invoke(args);
