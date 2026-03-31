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

namespace CoinbaseSdk.Prime.AddressBook
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;

  /// <summary>
  /// Create Address Book Entry
  /// Creates an entry for a portfolio's trusted addresses.
  /// </summary>
  public class CreateAddressBookEntryRequest(string portfolioId)
  {
    /// <summary>
    /// Portfolio ID
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// Crypto address to add
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    /// <summary>
    /// Currency symbol of address to add
    /// </summary>
    [JsonPropertyName("currency_symbol")]
    public string? CurrencySymbol { get; set; }

    /// <summary>
    /// Name of address book entry
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Account Identifier (memo/destination tag)
    /// </summary>
    [JsonPropertyName("account_identifier")]
    public string? AccountIdentifier { get; set; }

    /// <summary>
    /// List of compatible chain IDs for the address, empty for Solana
    /// </summary>
    [JsonPropertyName("chain_ids")]
    public string?[] ChainIds { get; set; } = [];

    public class Builder
    {
      private string? _portfolioId;
      private string? _address;
      private string? _currencySymbol;
      private string? _name;
      private string? _accountIdentifier;
      private string?[] _chainIds;

      /// <summary>
      /// Portfolio ID
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// Crypto address to add
      /// </summary>
      public Builder WithAddress(string? address)
      {
        _address = address;
        return this;
      }

      /// <summary>
      /// Currency symbol of address to add
      /// </summary>
      public Builder WithCurrencySymbol(string? currencySymbol)
      {
        _currencySymbol = currencySymbol;
        return this;
      }

      /// <summary>
      /// Name of address book entry
      /// </summary>
      public Builder WithName(string? name)
      {
        _name = name;
        return this;
      }

      /// <summary>
      /// Account Identifier (memo/destination tag)
      /// </summary>
      public Builder WithAccountIdentifier(string? accountIdentifier)
      {
        _accountIdentifier = accountIdentifier;
        return this;
      }

      /// <summary>
      /// List of compatible chain IDs for the address, empty for Solana
      /// </summary>
      public Builder WithChainIds(string?[] chainIds)
      {
        _chainIds = chainIds;
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
      }

      /// <summary>
      /// Builds a new <see cref="CreateAddressBookEntryRequest"/>.
      /// </summary>
      public CreateAddressBookEntryRequest Build()
      {
        Validate();
        return new CreateAddressBookEntryRequest(_portfolioId!)
        {
          Address = _address,
          CurrencySymbol = _currencySymbol,
          Name = _name,
          AccountIdentifier = _accountIdentifier,
          ChainIds = _chainIds,
        };
      }
    }
  }
}
