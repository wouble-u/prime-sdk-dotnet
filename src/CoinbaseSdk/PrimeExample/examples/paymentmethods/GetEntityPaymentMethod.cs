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

using CoinbaseSdk.Prime.PaymentMethods;
using CoinbaseSdk.Prime.Client;
using CoinbaseSdk.Prime.Common;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var entityIdOption = new Option<string?>(
    name: "--entityId",
    description: "The Entity ID");

var paymentMethodIdOption = new Option<string?>(
    name: "--paymentMethodId",
    description: "The Payment Method ID");

var rootCommand = new RootCommand("Get payment method details by ID")
{
    entityIdOption,
    paymentMethodIdOption
};

rootCommand.SetHandler((entityId, paymentMethodId) =>
{
    entityId ??= Environment.GetEnvironmentVariable("PRIME_ENTITY_ID");

    if (string.IsNullOrEmpty(entityId))
    {
        Console.Error.WriteLine("Error: --entityId is required (or set PRIME_ENTITY_ID env var).");
        Environment.ExitCode = 1;
        return;
    }

    if (string.IsNullOrEmpty(paymentMethodId))
    {
        Console.Error.WriteLine("Error: --paymentMethodId is required.");
        Environment.ExitCode = 1;
        return;
    }

    try
    {
        Console.WriteLine($"Using Entity ID: {entityId}");
        Console.WriteLine($"Using Payment Method ID: {paymentMethodId}");

        // Create client and service
        var client = CoinbasePrimeClient.FromEnv();
        var paymentMethodsService = new PaymentMethodsService(client);

        // Build request
        var request = new GetEntityPaymentMethodRequest(entityId, paymentMethodId);

        PrettyPrinter.PrintResponse("GetEntityPaymentMethodRequest", request);

        // Execute request
        var response = paymentMethodsService.GetEntityPaymentMethod(request);

        // Print response
        PrettyPrinter.PrintResponse("GetEntityPaymentMethodResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error getting payment method", ex);
        Environment.ExitCode = 1;
    }
}, entityIdOption, paymentMethodIdOption);

return rootCommand.Invoke(args);
