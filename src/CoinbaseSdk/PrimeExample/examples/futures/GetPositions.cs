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

using CoinbaseSdk.Prime.Futures;
using CoinbaseSdk.Prime.Client;
using CoinbaseSdk.Prime.Common;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var entityIdOption = new Option<string?>(
    name: "--entityId",
    description: "The Entity ID");

var productIdOption = new Option<string?>(
    name: "--productId",
    description: "Optional product ID filter");

var rootCommand = new RootCommand("Get futures positions for an entity")
{
    entityIdOption,
    productIdOption,
};

rootCommand.SetHandler((entityId, productId) =>
{
    entityId ??= Environment.GetEnvironmentVariable("PRIME_ENTITY_ID");

    if (string.IsNullOrEmpty(entityId))
    {
        Console.Error.WriteLine("Error: --entityId is required (or set PRIME_ENTITY_ID env var).");
        Environment.ExitCode = 1;
        return;
    }

    try
    {
        Console.WriteLine($"Using Entity ID: {entityId}");

        var client = CoinbasePrimeClient.FromEnv();
        var futuresService = new FuturesService(client);

        var request = new GetPositionsRequest(entityId);

        if (!string.IsNullOrEmpty(productId))
        {
            request.ProductId = productId;
        }

        PrettyPrinter.PrintResponse("GetPositionsRequest", request);

        var response = futuresService.GetPositions(request);

        PrettyPrinter.PrintResponse("GetPositionsResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error getting positions", ex);
        Environment.ExitCode = 1;
    }
}, entityIdOption, productIdOption);

return rootCommand.Invoke(args);
