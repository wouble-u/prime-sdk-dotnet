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
  using CoinbaseSdk.Prime.Model.Enums;

  /// <summary>
  /// A successful response.
  /// </summary>
  public class GetFcmRiskLimitsResponse
  {
    /// <summary>
    /// Risk Limit set for a client
    /// </summary>
    [JsonPropertyName("cfm_risk_limit")]
    public string? CfmRiskLimit { get; set; }

    /// <summary>
    /// Limit utilization calculated based on total margin and PnLs
    /// </summary>
    [JsonPropertyName("cfm_risk_limit_utilization")]
    public string? CfmRiskLimitUtilization { get; set; }

    /// <summary>
    /// The total margin required for both positions and open orders
    /// </summary>
    [JsonPropertyName("cfm_total_margin")]
    public string? CfmTotalMargin { get; set; }

    /// <summary>
    /// Open Trade Equity accrued during the current trading session
    /// </summary>
    [JsonPropertyName("cfm_delta_ote")]
    public string? CfmDeltaOte { get; set; }

    /// <summary>
    /// Unsettled realized PNL for positions closed intraday
    /// </summary>
    [JsonPropertyName("cfm_unsettled_realized_pnl")]
    public string? CfmUnsettledRealizedPnl { get; set; }

    /// <summary>
    /// Unsettled accrued funding PNL from the last settlement
    /// </summary>
    [JsonPropertyName("cfm_unsettled_accrued_funding_pnl")]
    public string? CfmUnsettledAccruedFundingPnl { get; set; }

    /// <summary>
    /// Margin utilization as a decimal percentage between 0 and 1 (e.g. 0.5 means 50%)
    /// </summary>
    [JsonPropertyName("margin_utilization_percent")]
    public string? MarginUtilizationPercent { get; set; }

    [JsonPropertyName("margin_health_state")]
    public FcmMarginHealthState MarginHealthState { get; set; }

    public GetFcmRiskLimitsResponse() { }
  }
}
