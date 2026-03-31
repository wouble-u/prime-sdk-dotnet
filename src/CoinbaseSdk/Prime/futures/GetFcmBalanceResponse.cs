/*
 * Copyright 2025-present Coinbase Global, Inc.
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

namespace CoinbaseSdk.Prime.Futures
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// A successful response.
  /// </summary>
  public class GetFcmBalanceResponse
  {
    /// <summary>
    /// Portfolio ID
    /// </summary>
    [JsonPropertyName("portfolio_id")]
    public string? PortfolioId { get; set; }

    /// <summary>
    /// CFM USD balance
    /// </summary>
    [JsonPropertyName("cfm_usd_balance")]
    public string? CfmUsdBalance { get; set; }

    /// <summary>
    /// Unrealized PNL
    /// </summary>
    [JsonPropertyName("unrealized_pnl")]
    public string? UnrealizedPnl { get; set; }

    /// <summary>
    /// Daily realized PNL
    /// </summary>
    [JsonPropertyName("daily_realized_pnl")]
    public string? DailyRealizedPnl { get; set; }

    /// <summary>
    /// Excess liquidity
    /// </summary>
    [JsonPropertyName("excess_liquidity")]
    public string? ExcessLiquidity { get; set; }

    /// <summary>
    /// Futures buying power
    /// </summary>
    [JsonPropertyName("futures_buying_power")]
    public string? FuturesBuyingPower { get; set; }

    /// <summary>
    /// Initial margin
    /// </summary>
    [JsonPropertyName("initial_margin")]
    public string? InitialMargin { get; set; }

    /// <summary>
    /// Maintenance margin
    /// </summary>
    [JsonPropertyName("maintenance_margin")]
    public string? MaintenanceMargin { get; set; }

    /// <summary>
    /// Clearing account ID
    /// </summary>
    [JsonPropertyName("clearing_account_id")]
    public string? ClearingAccountId { get; set; }

    /// <summary>
    /// Unsettled accrued funding PNL from the last settlement
    /// </summary>
    [JsonPropertyName("cfm_unsettled_accrued_funding_pnl")]
    public string? CfmUnsettledAccruedFundingPnl { get; set; }

    public GetFcmBalanceResponse() { }
  }
}
