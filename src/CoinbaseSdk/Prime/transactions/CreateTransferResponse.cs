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
  public class CreateTransferResponse
  {
    /// <summary>
    /// The activity ID for the transfer
    /// </summary>
    [JsonPropertyName("activity_id")]
    public string? ActivityId { get; set; }

    /// <summary>
    /// A URL to the activity associated with this transfer for approval
    /// </summary>
    [JsonPropertyName("approval_url")]
    public string? ApprovalUrl { get; set; }

    /// <summary>
    /// The currency symbol of the transfer
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// The amount of the transfer
    /// </summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>
    /// The network fee associated with the transfer
    /// </summary>
    [JsonPropertyName("fee")]
    public string? Fee { get; set; }

    /// <summary>
    /// The destination address of the transfer
    /// </summary>
    [JsonPropertyName("destination_address")]
    public string? DestinationAddress { get; set; }

    /// <summary>
    /// The destination type of the transfer
    /// </summary>
    [JsonPropertyName("destination_type")]
    public string? DestinationType { get; set; }

    /// <summary>
    /// The source address used for the transfer
    /// </summary>
    [JsonPropertyName("source_address")]
    public string? SourceAddress { get; set; }

    /// <summary>
    /// The source type used for the transfer
    /// </summary>
    [JsonPropertyName("source_type")]
    public string? SourceType { get; set; }

    /// <summary>
    /// The id of the just created transaction
    /// </summary>
    [JsonPropertyName("transaction_id")]
    public string? TransactionId { get; set; }

    public CreateTransferResponse() { }
  }
}
