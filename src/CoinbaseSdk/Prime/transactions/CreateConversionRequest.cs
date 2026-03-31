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
  using CoinbaseSdk.Core.Error;

  /// <summary>
  /// Create Conversion
  /// Perform a conversion between 2 assets.
  /// </summary>
  public class CreateConversionRequest(string portfolioId, string walletId)
  {
    /// <summary>
    /// The ID of the portfolio
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// The wallet ID that the conversion will originate from
    /// </summary>
    [JsonIgnore]
    public string WalletId { get; set; } = walletId;

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
    /// The idempotency key associated with this conversion
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

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

    public class Builder
    {
      private string? _portfolioId;
      private string? _walletId;
      private string? _amount;
      private string? _destination;
      private string? _idempotencyKey;
      private string? _sourceSymbol;
      private string? _destinationSymbol;

      /// <summary>
      /// The ID of the portfolio
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// The wallet ID that the conversion will originate from
      /// </summary>
      public Builder WithWalletId(string walletId)
      {
        _walletId = walletId;
        return this;
      }

      /// <summary>
      /// The amount in whole units to convert
      /// </summary>
      public Builder WithAmount(string? amount)
      {
        _amount = amount;
        return this;
      }

      /// <summary>
      /// The UUID of the destination wallet
      /// </summary>
      public Builder WithDestination(string? destination)
      {
        _destination = destination;
        return this;
      }

      /// <summary>
      /// The idempotency key associated with this conversion
      /// </summary>
      public Builder WithIdempotencyKey(string? idempotencyKey)
      {
        _idempotencyKey = idempotencyKey;
        return this;
      }

      /// <summary>
      /// The currency symbol to convert from
      /// </summary>
      public Builder WithSourceSymbol(string? sourceSymbol)
      {
        _sourceSymbol = sourceSymbol;
        return this;
      }

      /// <summary>
      /// The currency symbol to convert to
      /// </summary>
      public Builder WithDestinationSymbol(string? destinationSymbol)
      {
        _destinationSymbol = destinationSymbol;
        return this;
      }

      /// <summary>
      /// Validates required path parameters before building the request.
      /// </summary>
      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
        if (string.IsNullOrWhiteSpace(_walletId))
        {
          throw new CoinbaseClientException("WalletId is required");
        }
      }

      /// <summary>
      /// Builds a new <see cref="CreateConversionRequest"/>.
      /// </summary>
      public CreateConversionRequest Build()
      {
        Validate();
        return new CreateConversionRequest(_portfolioId!, _walletId!)
        {
          Amount = _amount,
          Destination = _destination,
          IdempotencyKey = _idempotencyKey,
          SourceSymbol = _sourceSymbol,
          DestinationSymbol = _destinationSymbol,
        };
      }
    }
  }
}
