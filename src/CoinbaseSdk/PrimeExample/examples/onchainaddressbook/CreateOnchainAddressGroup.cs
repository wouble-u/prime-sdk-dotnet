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

using CoinbaseSdk.Prime.OnchainAddressBook;
using CoinbaseSdk.Prime.Client;
using CoinbaseSdk.Prime.Model;
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
    description: "Name for the address group");

var networkTypeOption = new Option<string?>(
    name: "--networkType",
    description: "Network type (e.g., ETHEREUM, SOLANA)");

var addressOption = new Option<string?>(
    name: "--address",
    description: "The crypto address");

var addressNameOption = new Option<string?>(
    name: "--addressName",
    description: "Name for the address entry");

var chainIdsOption = new Option<string?>(
    name: "--chainIds",
    description: "Comma-separated list of chain IDs");

var rootCommand = new RootCommand("Create an onchain address group")
{
    portfolioIdOption,
    nameOption,
    networkTypeOption,
    addressOption,
    addressNameOption,
    chainIdsOption
};

rootCommand.SetHandler((context) =>
{
    var portfolioId = context.ParseResult.GetValueForOption(portfolioIdOption);
    var name = context.ParseResult.GetValueForOption(nameOption);
    var networkTypeStr = context.ParseResult.GetValueForOption(networkTypeOption);
    var address = context.ParseResult.GetValueForOption(addressOption);
    var addressName = context.ParseResult.GetValueForOption(addressNameOption);
    var chainIdsStr = context.ParseResult.GetValueForOption(chainIdsOption);

    portfolioId ??= Environment.GetEnvironmentVariable("PRIME_PORTFOLIO_ID");

    if (string.IsNullOrEmpty(portfolioId))
    {
        Console.Error.WriteLine("Error: --portfolioId is required (or set PRIME_PORTFOLIO_ID env var).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(name))
    {
        Console.Error.WriteLine("Error: --name is required.");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(address))
    {
        Console.Error.WriteLine("Error: --address is required.");
        Environment.ExitCode = 1;
        return;
    }

    NetworkType? networkType = null;
    if (!string.IsNullOrEmpty(networkTypeStr))
    {
        if (!Enum.TryParse<NetworkType>(networkTypeStr, true, out var parsedNetworkType))
        {
            Console.Error.WriteLine($"Invalid network type: {networkTypeStr}");
            Environment.ExitCode = 1;
            return;
        }
        networkType = parsedNetworkType;
    }

    try
    {
        Console.WriteLine($"Using Portfolio ID: {portfolioId}");

        var client = CoinbasePrimeClient.FromEnv();
        var onchainAddressBookService = new OnchainAddressBookService(client);

        var addressEntryBuilder = new AddressEntry.Builder()
            .WithAddress(address);

        if (!string.IsNullOrEmpty(addressName))
        {
            addressEntryBuilder.WithName(addressName);
        }

        if (!string.IsNullOrEmpty(chainIdsStr))
        {
            var chainIds = chainIdsStr.Split(',').Select(s => s.Trim()).ToList();
            addressEntryBuilder.WithChainIds(chainIds);
        }

        var addressEntry = addressEntryBuilder.Build();

        var addressGroup = new AddressGroup.Builder()
            .WithName(name)
            .WithNetworkType(networkType)
            .WithAddresses([addressEntry])
            .Build();

        var request = new CreateOnchainAddressBookEntryRequest(portfolioId, addressGroup);

        PrettyPrinter.PrintResponse("CreateOnchainAddressBookEntryRequest", request);

        var response = onchainAddressBookService.CreateOnchainAddressBookEntry(request);

        PrettyPrinter.PrintResponse("ActivityCreationResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error creating onchain address group", ex);
        Environment.ExitCode = 1;
    }
});

return rootCommand.Invoke(args);
