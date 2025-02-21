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

namespace CoinbaseSdk.Prime.Transactions
{
    using System.Text.Json.Serialization;

    public class EvmParams
    {
        [JsonPropertyName("disable_dynamic_gas")]
        public bool? DisableDynamicGas { get; set; }

        [JsonPropertyName("replaced_transaction_string")]
        public string? ReplacedTransactionString { get; set; }

        [JsonPropertyName("chain_id")]
        public string? ChainId { get; set; }

        public EvmParams() { }

        public class EVMParamsBuilder
        {
            private bool? _disableDynamicGas;
            private string? _replacedTransactionString;
            private string? _chainId;

            public EVMParamsBuilder() { }

            public EVMParamsBuilder WithDisableDynamicGas(bool disableDynamicGas)
            {
                this._disableDynamicGas = disableDynamicGas;
                return this;
            }

            public EVMParamsBuilder WithReplacedTransactionString(string replacedTransactionString)
            {
                this._replacedTransactionString = replacedTransactionString;
                return this;
            }

            public EVMParamsBuilder WithChainId(string chainId)
            {
                this._chainId = chainId;
                return this;
            }

            public EvmParams Build()
            {
                return new EvmParams
                {
                    DisableDynamicGas = this._disableDynamicGas,
                    ReplacedTransactionString = this._replacedTransactionString,
                    ChainId = this._chainId,
                };
            }
        }
    }
}
