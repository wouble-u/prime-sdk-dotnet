/*
 * Copyright 2025-present Coinbase Global, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace CoinbaseSdk.Prime.Staking
{
    using System.Text.Json.Serialization;

    public class CreateUnstakeResponse
    {
        [JsonPropertyName("wallet_id")]
        public string? WalletId { get; set; }

        [JsonPropertyName("transaction_id")]
        public string? TransactionId { get; set; }

        [JsonPropertyName("activity_id")]
        public string? ActivityId { get; set; }

        public CreateUnstakeResponse() { }

        public class CreateUnstakeResponseBuilder
        {
            private string? _walletId;
            private string? _transactionId;
            private string? _activityId;

            public CreateUnstakeResponseBuilder WithWalletId(string? walletId)
            {
                this._walletId = walletId;
                return this;
            }

            public CreateUnstakeResponseBuilder WithTransactionId(string? transactionId)
            {
                this._transactionId = transactionId;
                return this;
            }

            public CreateUnstakeResponseBuilder WithActivityId(string? activityId)
            {
                this._activityId = activityId;
                return this;
            }

            public CreateUnstakeResponse Build()
            {
                return new CreateUnstakeResponse
                {
                    WalletId = this._walletId,
                    TransactionId = this._transactionId,
                    ActivityId = this._activityId
                };
            }
        }
    }
}