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

using CoinbaseSdk.Prime.Orders;
using CoinbaseSdk.Prime.Client;
using CoinbaseSdk.Prime.Model.Enums;
using CoinbaseSdk.Prime.Common;
using System.CommandLine;

// Load environment variables
DotNetEnv.Env.TraversePath().Load();

var portfolioIdOption = new Option<string?>(
    name: "--portfolioId",
    description: "The Portfolio ID");

var productIdsOption = new Option<string?>(
    name: "--productIds",
    description: "Comma-separated list of product IDs to filter by (e.g., BTC-USD,ETH-USD)");

var orderStatusesOption = new Option<string?>(
    name: "--orderStatuses",
    description: "Comma-separated list of order statuses (OPEN, FILLED, CANCELLED, EXPIRED, FAILED, PENDING)");

var orderTypeOption = new Option<string?>(
    name: "--orderType",
    description: "Order type filter (MARKET, LIMIT, TWAP, VWAP, STOP_LIMIT, BLOCK, RFQ, PEG)");

var orderSideOption = new Option<string?>(
    name: "--orderSide",
    description: "Order side filter (BUY or SELL)");

var startDateOption = new Option<string?>(
    name: "--startDate",
    description: "Start date filter (ISO 8601 format)");

var endDateOption = new Option<string?>(
    name: "--endDate",
    description: "End date filter (ISO 8601 format)");

var limitOption = new Option<int?>(
    name: "--limit",
    description: "Maximum number of results to return");

var cursorOption = new Option<string?>(
    name: "--cursor",
    description: "Pagination cursor");

var rootCommand = new RootCommand("List all orders for a portfolio")
{
    portfolioIdOption,
    productIdsOption,
    orderStatusesOption,
    orderTypeOption,
    orderSideOption,
    startDateOption,
    endDateOption,
    limitOption,
    cursorOption,
};

rootCommand.SetHandler((context) =>
{
    var portfolioId = context.ParseResult.GetValueForOption(portfolioIdOption);
    var productIds = context.ParseResult.GetValueForOption(productIdsOption);
    var orderStatusesStr = context.ParseResult.GetValueForOption(orderStatusesOption);
    var orderTypeStr = context.ParseResult.GetValueForOption(orderTypeOption);
    var orderSideStr = context.ParseResult.GetValueForOption(orderSideOption);
    var startDate = context.ParseResult.GetValueForOption(startDateOption);
    var endDate = context.ParseResult.GetValueForOption(endDateOption);
    var limit = context.ParseResult.GetValueForOption(limitOption);
    var cursor = context.ParseResult.GetValueForOption(cursorOption);

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
        var ordersService = new OrdersService(client);

        var requestBuilder = new ListPortfolioOrdersRequest.ListPortfolioOrdersRequestBuilder()
            .WithPortfolioId(portfolioId);

        if (!string.IsNullOrEmpty(productIds))
        {
            requestBuilder.WithProductIds(productIds.Split(','));
        }

        if (!string.IsNullOrEmpty(orderStatusesStr))
        {
            var statuses = new List<OrderStatus>();
            foreach (var status in orderStatusesStr.Split(','))
            {
                if (Enum.TryParse<OrderStatus>(status.Trim(), true, out var orderStatus))
                {
                    statuses.Add(orderStatus);
                }
                else
                {
                    Console.Error.WriteLine($"Error: Invalid orderStatus '{status}'.");
                    Environment.ExitCode = 1;
                    return;
                }
            }
            requestBuilder.WithOrderStatuses(statuses.ToArray());
        }

        if (!string.IsNullOrEmpty(orderTypeStr))
        {
            if (Enum.TryParse<OrderType>(orderTypeStr, true, out var orderType))
            {
                requestBuilder.WithOrderType(orderType);
            }
            else
            {
                Console.Error.WriteLine($"Error: Invalid orderType '{orderTypeStr}'.");
                Environment.ExitCode = 1;
                return;
            }
        }

        if (!string.IsNullOrEmpty(orderSideStr))
        {
            if (Enum.TryParse<OrderSide>(orderSideStr, true, out var orderSide))
            {
                requestBuilder.WithOrderSide(orderSide);
            }
            else
            {
                Console.Error.WriteLine($"Error: Invalid orderSide '{orderSideStr}'.");
                Environment.ExitCode = 1;
                return;
            }
        }

        if (!string.IsNullOrEmpty(startDate))
        {
            requestBuilder.WithStartDate(startDate);
        }

        if (!string.IsNullOrEmpty(endDate))
        {
            requestBuilder.WithEndDate(endDate);
        }

        if (limit.HasValue)
        {
            requestBuilder.WithLimit(limit.Value);
        }

        if (!string.IsNullOrEmpty(cursor))
        {
            requestBuilder.WithCursor(cursor);
        }

        var request = requestBuilder.Build();

        PrettyPrinter.PrintResponse("ListPortfolioOrdersRequest", request);

        var response = ordersService.ListPortfolioOrders(request);

        PrettyPrinter.PrintResponse("ListPortfolioOrdersResponse", response);

        Environment.ExitCode = 0;
    }
    catch (Exception ex)
    {
        PrettyPrinter.PrintError("Error listing portfolio orders", ex);
        Environment.ExitCode = 1;
    }
});

return rootCommand.Invoke(args);
