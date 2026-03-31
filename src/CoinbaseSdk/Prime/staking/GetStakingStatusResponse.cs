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

namespace CoinbaseSdk.Prime.Staking
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Prime.Model;

  /// <summary>
  /// A successful response.
  /// </summary>
  public class GetStakingStatusResponse
  {
    /// <summary>
    /// The portfolio ID
    /// </summary>
    [JsonPropertyName("portfolio_id")]
    public string? PortfolioId { get; set; }

    /// <summary>
    /// The wallet ID
    /// </summary>
    [JsonPropertyName("wallet_id")]
    public string? WalletId { get; set; }

    /// <summary>
    /// The wallet address
    /// </summary>
    [JsonPropertyName("wallet_address")]
    public string? WalletAddress { get; set; }

    /// <summary>
    /// Current timestamp at time of API call
    /// </summary>
    [JsonPropertyName("current_timestamp")]
    public string? CurrentTimestamp { get; set; }

    /// <summary>
    /// List of validators with staking information for this wallet
    /// </summary>
    [JsonPropertyName("validators")]
    public ValidatorStakingInfo[] Validators { get; set; } = [];

    public GetStakingStatusResponse() { }
  }
}
