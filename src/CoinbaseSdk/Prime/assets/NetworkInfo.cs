/*
 * Copyright 2024-present Coinbase Global, Inc.
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

namespace CoinbaseSdk.Prime.Assets
{
  using System.Text.Json.Serialization;

  public class NetworkInfo
  {
    public NetworkDetails? Network { get; set; }
    public string? Name { get; set; }
    [JsonPropertyName("max_decimals")]
    public string? MaxDecimals { get; set; }
    public bool? Default { get; set; }
    [JsonPropertyName("trading_supported")]
    public bool? TradingSupported { get; set; }
    [JsonPropertyName("vault_supported")]
    public bool? VaultSupported { get; set; }
    [JsonPropertyName("prime_custody_supported")]
    public bool? PrimeCustodySupported { get; set; }
    [JsonPropertyName("destination_tag_required")]
    public bool? DestinationTagRequired { get; set; }
    [JsonPropertyName("network_link")]
    public string? NetworkLink { get; set; }
  }
}