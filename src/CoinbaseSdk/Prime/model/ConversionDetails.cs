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
    using System.Text.Json.Serialization;
    public class ConversionDetails
    {
        public string? Symbol { get; set; }

        [JsonPropertyName("tf_balance")]
        public string? TfBalance { get; set; }

        [JsonPropertyName("notional_tf_balance")]
        public string? NotionalTfBalance { get; set; }

        [JsonPropertyName("converted_balance")]
        public string? ConvertedBalance { get; set; }

        [JsonPropertyName("notional_converted_balance")]
        public string? NotionalConvertedBalance { get; set; }

        [JsonPropertyName("interest_rate")]
        public string? InterestRate { get; set; }

        [JsonPropertyName("conversion_rate")]
        public string? ConversionRate { get; set; }

        public ConversionDetails() { }

        public class ConversionDetailsBuilder
        {
            private string? _symbol;
            private string? _tfBalance;
            private string? _notionalTfBalance;
            private string? _convertedBalance;
            private string? _notionalConvertedBalance;
            private string? _interestRate;
            private string? _conversionRate;

            public ConversionDetailsBuilder WithSymbol(string symbol)
            {
                this._symbol = symbol;
                return this;
            }

            public ConversionDetailsBuilder WithTfBalance(string tfBalance)
            {
                this._tfBalance = tfBalance;
                return this;
            }

            public ConversionDetailsBuilder WithNotionalTfBalance(string notionalTfBalance)
            {
                this._notionalTfBalance = notionalTfBalance;
                return this;
            }

            public ConversionDetailsBuilder WithConvertedBalance(string convertedBalance)
            {
                this._convertedBalance = convertedBalance;
                return this;
            }

            public ConversionDetailsBuilder WithNotionalConvertedBalance(string notionalConvertedBalance)
            {
                this._notionalConvertedBalance = notionalConvertedBalance;
                return this;
            }

            public ConversionDetailsBuilder WithInterestRate(string interestRate)
            {
                this._interestRate = interestRate;
                return this;
            }

            public ConversionDetailsBuilder WithConversionRate(string conversionRate)
            {
                this._conversionRate = conversionRate;
                return this;
            }

            public ConversionDetails Build()
            {
                return new ConversionDetails
                {
                    Symbol = this._symbol,
                    TfBalance = this._tfBalance,
                    NotionalTfBalance = this._notionalTfBalance,
                    ConvertedBalance = this._convertedBalance,
                    NotionalConvertedBalance = this._notionalConvertedBalance,
                    InterestRate = this._interestRate,
                    ConversionRate = this._conversionRate
                };
            }
        }
    }
}