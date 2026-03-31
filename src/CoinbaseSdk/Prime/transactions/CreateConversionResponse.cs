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

namespace CoinbaseSdk.Prime.Transactions
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// A successful response.
  /// </summary>
  public class CreateConversionResponse
  {
    /// <summary>
    /// The activity ID for the conversion
    /// </summary>
    [JsonPropertyName("activity_id")]
    public string? ActivityId { get; set; }

    /// <summary>
    /// The currency symbol to convert from
    /// </summary>
    [JsonPropertyName("source_symbol")]
    public string? SourceSymbol { get; set; }

    /// <summary>
    /// The currency symbol to convert to
    /// </summary>
    [JsonPropertyName("destination_symbol")]
    public string? DestinationSymbol { get; set; }

    /// <summary>
    /// The amount in whole units to convert
    /// </summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>
    /// The UUID of the destination wallet
    /// </summary>
    [JsonPropertyName("destination")]
    public string? Destination { get; set; }

    /// <summary>
    /// The UUID of the source wallet
    /// </summary>
    [JsonPropertyName("source")]
    public string? Source { get; set; }

    /// <summary>
    /// The UUID of the conversion transaction
    /// </summary>
    [JsonPropertyName("transaction_id")]
    public string? TransactionId { get; set; }

    public CreateConversionResponse() { }
  }
}
