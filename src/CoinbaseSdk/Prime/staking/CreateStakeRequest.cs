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
    using CoinbaseSdk.Prime.Common;
    using CoinbaseSdk.Prime.Model;

    public class CreateStakeRequest(string portfolioId, string walletId) : BasePrimeRequest(portfolioId, null)
    {
        [JsonIgnore, JsonPropertyName("wallet_id")]
        public string WalletId { get; set; } = walletId;

        [JsonPropertyName("idempotency_key")]
        public string? IdempotencyKey { get; set; }

        public StakingInputs? Inputs { get; set; }

        public class CreateStakeRequestBuilder
        {
            private string? _idempotencyKey;
            private StakingInputs? _inputs;

            public CreateStakeRequestBuilder WithIdempotencyKey(string? idempotencyKey)
            {
                this._idempotencyKey = idempotencyKey;
                return this;
            }

            public CreateStakeRequestBuilder WithInputs(StakingInputs? inputs)
            {
                this._inputs = inputs;
                return this;
            }

            public CreateStakeRequest Build(string portfolioId, string walletId)
            {
                return new CreateStakeRequest(portfolioId, walletId)
                {
                    IdempotencyKey = this._idempotencyKey,
                    Inputs = this._inputs
                };
            }
        }
    }
}