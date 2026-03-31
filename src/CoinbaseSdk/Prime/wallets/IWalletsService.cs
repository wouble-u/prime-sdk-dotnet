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

namespace CoinbaseSdk.Prime.Wallets
{
  using CoinbaseSdk.Core.Http;

  public interface IWalletsService
  {
    /// <summary>
    /// List Portfolio Wallets
    /// List all wallets associated with a given portfolio.
    /// </summary>
    public ListWalletsResponse ListWallets(
      ListWalletsRequest request,
      CallOptions? options = null);

    /// <summary>
    /// List Portfolio Wallets
    /// List all wallets associated with a given portfolio.
    /// </summary>
    public Task<ListWalletsResponse> ListWalletsAsync(
      ListWalletsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Create Wallet
    /// Create a wallet. Note: The first ONCHAIN wallet for each network family must be created through the Prime UI.
    /// </summary>
    public CreateWalletResponse CreateWallet(
      CreateWalletRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Create Wallet
    /// Create a wallet. Note: The first ONCHAIN wallet for each network family must be created through the Prime UI.
    /// </summary>
    public Task<CreateWalletResponse> CreateWalletAsync(
      CreateWalletRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Wallet by Wallet ID
    /// Retrieve a specific wallet by Wallet ID.
    /// </summary>
    public GetWalletResponse GetWallet(
      GetWalletRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Get Wallet by Wallet ID
    /// Retrieve a specific wallet by Wallet ID.
    /// </summary>
    public Task<GetWalletResponse> GetWalletAsync(
      GetWalletRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// List Wallet Addresses
    /// Returns all deposit addresses associated with a wallet
    /// </summary>
    public ListWalletAddressesResponse ListWalletAddresses(
      ListWalletAddressesRequest request,
      CallOptions? options = null);

    /// <summary>
    /// List Wallet Addresses
    /// Returns all deposit addresses associated with a wallet
    /// </summary>
    public Task<ListWalletAddressesResponse> ListWalletAddressesAsync(
      ListWalletAddressesRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Create Wallet Deposit Address
    /// Creates a new deposit address for a wallet. Only applicable to wallets that support multiple deposit addresses on a given network
    /// </summary>
    public CreateWalletDepositAddressResponse CreateWalletDepositAddress(
      CreateWalletDepositAddressRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Create Wallet Deposit Address
    /// Creates a new deposit address for a wallet. Only applicable to wallets that support multiple deposit addresses on a given network
    /// </summary>
    public Task<CreateWalletDepositAddressResponse> CreateWalletDepositAddressAsync(
      CreateWalletDepositAddressRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Wallet Deposit Instructions
    /// Retrieve a specific wallet's deposit instructions.
    /// </summary>
    public GetWalletDepositInstructionsResponse GetWalletDepositInstructions(
      GetWalletDepositInstructionsRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Get Wallet Deposit Instructions
    /// Retrieve a specific wallet's deposit instructions.
    /// </summary>
    public Task<GetWalletDepositInstructionsResponse> GetWalletDepositInstructionsAsync(
      GetWalletDepositInstructionsRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

  }
}
