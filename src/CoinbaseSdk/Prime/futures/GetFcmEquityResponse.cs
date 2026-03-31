/*
 * Copyright 2026-present Coinbase Global, Inc.
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
  public class GetFcmEquityResponse
  {
    /// <summary>
    /// Prior EOD account equity (ending balance + realized P&amp;L + commissions/fees)
    /// </summary>
    [JsonPropertyName("eod_account_equity")]
    public string? EodAccountEquity { get; set; }

    /// <summary>
    /// Prior EOD unrealized P&amp;L on open futures positions
    /// </summary>
    [JsonPropertyName("eod_unrealized_pnl")]
    public string? EodUnrealizedPnl { get; set; }

    /// <summary>
    /// Current Derivatives Account Balance minus prior EOD margin requirement. (Positive = excess; negative = deficit)
    /// </summary>
    [JsonPropertyName("current_excess_deficit")]
    public string? CurrentExcessDeficit { get; set; }

    /// <summary>
    /// Excess funds in the Derivatives account available to transfer ("sweep") to the designated funding portfolio
    /// </summary>
    [JsonPropertyName("available_to_sweep")]
    public string? AvailableToSweep { get; set; }

    public GetFcmEquityResponse() { }
  }
}
