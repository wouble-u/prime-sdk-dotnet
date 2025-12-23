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

var targetDerivativesExcessOption = new Option<string?>(
    name: "--targetDerivativesExcess",
    description: "Target derivatives excess (non-negative number)");

var rootCommand = new RootCommand("Set FCM settings for an entity")
{
    entityIdOption,
    targetDerivativesExcessOption,
};

rootCommand.SetHandler((entityId, targetDerivativesExcess) =>
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

        var request = new SetFcmSettingsRequest(entityId);

        if (!string.IsNullOrEmpty(targetDerivativesExcess))
        {
            request.TargetDerivativesExcess = targetDerivativesExcess;
        }

        PrettyPrinter.PrintResponse("SetFcmSettingsRequest", request);

        var response = futuresService.SetFcmSettings(request);

        PrettyPrinter.PrintResponse("SetFcmSettingsResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error setting FCM settings", ex);
        Environment.ExitCode = 1;
    }
}, entityIdOption, targetDerivativesExcessOption);

return rootCommand.Invoke(args);
