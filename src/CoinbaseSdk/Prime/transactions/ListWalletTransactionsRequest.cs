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
  using CoinbaseSdk.Prime.Common;
  using CoinbaseSdk.Prime.Model.Enums;

  /// <summary>
  /// List Wallet Transactions
  /// Retrieve transactions for a given wallet.
  /// </summary>
  public class ListWalletTransactionsRequest(string portfolioId, string walletId) : PaginatedRequest
  {
    /// <summary>
    /// The portfolio ID
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// The wallet ID
    /// </summary>
    [JsonIgnore]
    public string WalletId { get; set; } = walletId;

    /// <summary>
    /// The transaction types by which to filter the response
    /// - TRANSACTION_TYPE_UNKNOWN: An unknown transaction type
    /// - DEPOSIT: A fiat or crypto deposit
    /// - WITHDRAWAL: A fiat or crypto withdrawal
    /// - INTERNAL_DEPOSIT: An internal fiat or crypto deposit
    /// - INTERNAL_WITHDRAWAL: An internal fiat or crypto withdrawal
    /// - SWEEP_DEPOSIT: Internal automated deposit to a cold address from a restored address
    /// - SWEEP_WITHDRAWAL: Internal automated withdrawal from a restored address to a cold address
    /// - PROXY_DEPOSIT: On-chain deposit of funds into proxy contract from cold address
    /// - PROXY_WITHDRAWAL: On-chain withdrawal of funds from proxy contract to cold address
    /// - BILLING_WITHDRAWAL: Coinbase Prime automated invoice settlement payment
    /// - REWARD: Reward payment to an associated address for a staked asset
    /// - COINBASE_REFUND: Coinbase Prime refund for the leftover amount for a CPFP (child pays for parent) transaction
    /// - TRANSACTION_TYPE_OTHER: An OTHER type of transaction
    /// - WITHDRAWAL_ADJUSTMENT: A manual adjustment withdrawal transaction
    /// - DEPOSIT_ADJUSTMENT: A manual adjustment deposit transaction
    /// - KEY_REGISTRATION: An on-chain registration for an address
    /// - DELEGATION: An on-chain delegation transaction
    /// - UNDELEGATION: An on-chain undelegation transaction
    /// - RESTAKE: On-chain restaking transaction
    /// - COMPLETE_UNBONDING: On-chain unbonding event transaction
    /// - WITHDRAW_UNBONDED: On-chain event indicating unbonding period is over
    /// - STAKE_ACCOUNT_CREATE: On-chain transaction to begin staking from an address
    /// - CHANGE_VALIDATOR: On-chain transaction alter validator
    /// - STAKE: On-chain transaction to begin staking in Cryptocurrency network
    /// - UNSTAKE: On-chain transaction to stop staking in Cryptocurrency network
    /// - REMOVE_AUTHORIZED_PARTY: On-chain transaction to remove a party from a multi-signature wallet
    /// - STAKE_AUTHORIZE_WITH_SEED: On-chain transaction to begin staking from a seed account
    /// - SLASH: On-chain transaction indicating a slash event has occurred
    /// - COINBASE_DEPOSIT: On-chain transaction deposit for the purpose of transaction operations
    /// - CONVERSION: Internal conversion between two assets
    /// - CLAIM_REWARDS: On-chain transaction to claim rewards from Vote Account
    /// - VOTE_AUTHORIZE: On-chain transaction to transfer the reward claiming permission to other pubkey
    /// - WEB3_TRANSACTION: On-chain transaction initiated with Prime Onchain Wallet
    /// Deprecated: Use ONCHAIN_TRANSACTION instead
    /// - ONCHAIN_TRANSACTION: On-chain transaction initiated with Prime Onchain Wallet
    /// - PORTFOLIO_STAKE: Portfolio-level staking operation
    /// - PORTFOLIO_UNSTAKE: Portfolio-level unstaking operation
    /// </summary>
    [JsonPropertyName("types")]
    public string?[] Types { get; set; } = [];

    /// <summary>
    /// UTC timestamp from which to filter the response (inclusive, ISO-8601 format)
    /// </summary>
    [JsonPropertyName("start_time")]
    public string? StartTime { get; set; }

    /// <summary>
    /// UTC timestamp until which to filter the response (exclusive, ISO-8601 format)
    /// </summary>
    [JsonPropertyName("end_time")]
    public string? EndTime { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _walletId;
      private string?[]? _types;
      private string? _startTime;
      private string? _endTime;
      private string? _cursor;
      private SortDirection? _sortDirection;
      private int? _limit;

      /// <summary>
      /// The portfolio ID
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// The wallet ID
      /// </summary>
      public Builder WithWalletId(string walletId)
      {
        _walletId = walletId;
        return this;
      }

      /// <summary>
      /// The transaction types by which to filter the response
      /// - TRANSACTION_TYPE_UNKNOWN: An unknown transaction type
      /// - DEPOSIT: A fiat or crypto deposit
      /// - WITHDRAWAL: A fiat or crypto withdrawal
      /// - INTERNAL_DEPOSIT: An internal fiat or crypto deposit
      /// - INTERNAL_WITHDRAWAL: An internal fiat or crypto withdrawal
      /// - SWEEP_DEPOSIT: Internal automated deposit to a cold address from a restored address
      /// - SWEEP_WITHDRAWAL: Internal automated withdrawal from a restored address to a cold address
      /// - PROXY_DEPOSIT: On-chain deposit of funds into proxy contract from cold address
      /// - PROXY_WITHDRAWAL: On-chain withdrawal of funds from proxy contract to cold address
      /// - BILLING_WITHDRAWAL: Coinbase Prime automated invoice settlement payment
      /// - REWARD: Reward payment to an associated address for a staked asset
      /// - COINBASE_REFUND: Coinbase Prime refund for the leftover amount for a CPFP (child pays for parent) transaction
      /// - TRANSACTION_TYPE_OTHER: An OTHER type of transaction
      /// - WITHDRAWAL_ADJUSTMENT: A manual adjustment withdrawal transaction
      /// - DEPOSIT_ADJUSTMENT: A manual adjustment deposit transaction
      /// - KEY_REGISTRATION: An on-chain registration for an address
      /// - DELEGATION: An on-chain delegation transaction
      /// - UNDELEGATION: An on-chain undelegation transaction
      /// - RESTAKE: On-chain restaking transaction
      /// - COMPLETE_UNBONDING: On-chain unbonding event transaction
      /// - WITHDRAW_UNBONDED: On-chain event indicating unbonding period is over
      /// - STAKE_ACCOUNT_CREATE: On-chain transaction to begin staking from an address
      /// - CHANGE_VALIDATOR: On-chain transaction alter validator
      /// - STAKE: On-chain transaction to begin staking in Cryptocurrency network
      /// - UNSTAKE: On-chain transaction to stop staking in Cryptocurrency network
      /// - REMOVE_AUTHORIZED_PARTY: On-chain transaction to remove a party from a multi-signature wallet
      /// - STAKE_AUTHORIZE_WITH_SEED: On-chain transaction to begin staking from a seed account
      /// - SLASH: On-chain transaction indicating a slash event has occurred
      /// - COINBASE_DEPOSIT: On-chain transaction deposit for the purpose of transaction operations
      /// - CONVERSION: Internal conversion between two assets
      /// - CLAIM_REWARDS: On-chain transaction to claim rewards from Vote Account
      /// - VOTE_AUTHORIZE: On-chain transaction to transfer the reward claiming permission to other pubkey
      /// - WEB3_TRANSACTION: On-chain transaction initiated with Prime Onchain Wallet
      /// Deprecated: Use ONCHAIN_TRANSACTION instead
      /// - ONCHAIN_TRANSACTION: On-chain transaction initiated with Prime Onchain Wallet
      /// - PORTFOLIO_STAKE: Portfolio-level staking operation
      /// - PORTFOLIO_UNSTAKE: Portfolio-level unstaking operation
      /// </summary>
      public Builder WithTypes(string?[] types)
      {
        _types = types;
        return this;
      }

      /// <summary>
      /// UTC timestamp from which to filter the response (inclusive, ISO-8601 format)
      /// </summary>
      public Builder WithStartTime(string? startTime)
      {
        _startTime = startTime;
        return this;
      }

      /// <summary>
      /// UTC timestamp until which to filter the response (exclusive, ISO-8601 format)
      /// </summary>
      public Builder WithEndTime(string? endTime)
      {
        _endTime = endTime;
        return this;
      }

      public Builder WithCursor(string cursor)
      {
        _cursor = cursor;
        return this;
      }

      public Builder WithSortDirection(SortDirection sortDirection)
      {
        _sortDirection = sortDirection;
        return this;
      }

      public Builder WithLimit(int limit)
      {
        _limit = limit;
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
      /// Builds a new <see cref="ListWalletTransactionsRequest"/>.
      /// </summary>
      public ListWalletTransactionsRequest Build()
      {
        Validate();
        return new ListWalletTransactionsRequest(_portfolioId!, _walletId!)
        {
          Types = _types,
          StartTime = _startTime,
          EndTime = _endTime,
          Cursor = _cursor,
          SortDirection = _sortDirection,
          Limit = _limit,
        };
      }
    }
  }
}
