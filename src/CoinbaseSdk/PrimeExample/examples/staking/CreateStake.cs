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
using CoinbaseSdk.Prime.Model;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var portfolioIdOption = new Option<string?>(
    name: "--portfolioId",
    description: "The Portfolio ID");

var walletIdOption = new Option<string?>(
    name: "--walletId",
    description: "The Wallet ID");

var amountOption = new Option<string?>(
    name: "--amount",
    description: "Amount to stake (optional, defaults to max available)");

var validatorAddressOption = new Option<string?>(
    name: "--validatorAddress",
    description: "Validator address (optional, defaults to Coinbase validator)");

var rootCommand = new RootCommand("Create a wallet-level stake")
{
    portfolioIdOption,
    walletIdOption,
    amountOption,
    validatorAddressOption
};

rootCommand.SetHandler((portfolioId, walletId, amount, validatorAddress) =>
{
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

    try
    {
        Console.WriteLine($"Using Portfolio ID: {portfolioId}");
        Console.WriteLine($"Using Wallet ID: {walletId}");

        var client = CoinbasePrimeClient.FromEnv();
        var stakingService = new StakingService(client);

        var inputsBuilder = new WalletStakeInputs.Builder();
        if (!string.IsNullOrEmpty(amount))
        {
            inputsBuilder.WithAmount(amount);
        }
        if (!string.IsNullOrEmpty(validatorAddress))
        {
            inputsBuilder.WithValidatorAddress(validatorAddress);
        }

        var request = new CreateStakeRequest(portfolioId, walletId)
        {
            IdempotencyKey = Guid.NewGuid().ToString(),
            Inputs = inputsBuilder.Build()
        };

        PrettyPrinter.PrintResponse("CreateStakeRequest", request);

        var response = stakingService.CreateStake(request);

        PrettyPrinter.PrintResponse("CreateStakeResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error creating stake", ex);
        Environment.ExitCode = 1;
    }
}, portfolioIdOption, walletIdOption, amountOption, validatorAddressOption);

return rootCommand.Invoke(args);
