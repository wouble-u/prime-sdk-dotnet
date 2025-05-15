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

namespace CoinbaseSdk.Prime.Model
{
    public class FcmFuturesSweepRequestAmount
    {
        public string? Currency { get; set; }
        public string? Amount { get; set; }

        public FcmFuturesSweepRequestAmount() { }

        public class FcmFuturesSweepRequestAmountBuilder
        {
            private string? _currency;
            private string? _amount;

            public FcmFuturesSweepRequestAmountBuilder WithCurrency(string currency)
            {
                this._currency = currency;
                return this;
            }

            public FcmFuturesSweepRequestAmountBuilder WithAmount(string amount)
            {
                this._amount = amount;
                return this;
            }

            public FcmFuturesSweepRequestAmount Build()
            {
                return new FcmFuturesSweepRequestAmount()
                {
                    Currency = this._currency,
                    Amount = this._amount
                };
            }
        }
    }
}