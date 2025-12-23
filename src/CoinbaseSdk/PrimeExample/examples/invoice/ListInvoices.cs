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

using CoinbaseSdk.Prime.Invoice;
using CoinbaseSdk.Prime.Client;
using CoinbaseSdk.Prime.Model.Enums;
using CoinbaseSdk.Prime.Common;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var entityIdOption = new Option<string?>(
    name: "--entityId",
    description: "The Entity ID");

var statesOption = new Option<string?>(
    name: "--states",
    description: "Comma-separated list of invoice states (UNSPECIFIED, IMPORTED, BILLED, PARTIALLY_PAID, PAID)");

var billingYearOption = new Option<int?>(
    name: "--billingYear",
    description: "Billing year filter");

var billingMonthOption = new Option<int?>(
    name: "--billingMonth",
    description: "Billing month filter (1-12)");

var rootCommand = new RootCommand("List invoices for an entity")
{
    entityIdOption,
    statesOption,
    billingYearOption,
    billingMonthOption
};

rootCommand.SetHandler((entityId, statesStr, billingYear, billingMonth) =>
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

        // Create client and service
        var client = CoinbasePrimeClient.FromEnv();
        var invoiceService = new InvoiceService(client);

        // Build request
        var request = new ListInvoicesRequest(entityId);

        if (!string.IsNullOrEmpty(statesStr))
        {
            var stateStrings = statesStr.Split(',').Select(s => s.Trim()).ToArray();
            var states = new List<InvoiceState>();
            foreach (var stateStr in stateStrings)
            {
                if (Enum.TryParse<InvoiceState>(stateStr, true, out var state))
                {
                    states.Add(state);
                }
                else
                {
                    Console.Error.WriteLine($"Invalid state: {stateStr}");
                    Environment.ExitCode = 1;
                    return;
                }
            }
            request.States = [.. states];
        }

        if (billingYear.HasValue)
        {
            request.BillingYear = billingYear.Value;
        }

        if (billingMonth.HasValue)
        {
            request.BillingMonth = billingMonth.Value;
        }

        PrettyPrinter.PrintResponse("ListInvoicesRequest", request);

        // Execute request
        var response = invoiceService.ListInvoices(request);

        // Print response
        PrettyPrinter.PrintResponse("ListInvoicesResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error listing invoices", ex);
        Environment.ExitCode = 1;
    }
}, entityIdOption, statesOption, billingYearOption, billingMonthOption);

return rootCommand.Invoke(args);
