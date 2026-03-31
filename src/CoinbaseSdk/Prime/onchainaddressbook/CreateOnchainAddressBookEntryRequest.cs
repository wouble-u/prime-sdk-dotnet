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

namespace CoinbaseSdk.Prime.OnchainAddressBook
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Model;

  /// <summary>
  /// Create Onchain Address Book Entry
  /// Creates an entry to the portfolio's onchain address groups.
  /// </summary>
  public class CreateOnchainAddressBookEntryRequest(string portfolioId)
  {
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    [JsonPropertyName("address_group")]
    public AddressGroup AddressGroup { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private AddressGroup _addressGroup;

      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      public Builder WithAddressGroup(AddressGroup addressGroup)
      {
        _addressGroup = addressGroup;
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
      /// Builds a new <see cref="CreateOnchainAddressBookEntryRequest"/>.
      /// </summary>
      public CreateOnchainAddressBookEntryRequest Build()
      {
        Validate();
        return new CreateOnchainAddressBookEntryRequest(_portfolioId!)
        {
          AddressGroup = _addressGroup,
        };
      }
    }
  }
}
