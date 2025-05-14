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
    public class MarginInformation
    {
        [JsonPropertyName("margin_call_records")]
        public MarginCallRecord[] MarginCallRecords { get; set; } = [];

        [JsonPropertyName("margin_summary")]
        public MarginSummary? MarginSummary { get; set; }

        public MarginInformation() { }

        public class MarginInformationBuilder
        {
            private MarginCallRecord[] _marginCallRecords = [];
            private MarginSummary? _marginSummary;

            public MarginInformationBuilder WithMarginCallRecords(MarginCallRecord[] marginCallRecords)
            {
                this._marginCallRecords = marginCallRecords;
                return this;
            }

            public MarginInformationBuilder WithMarginSummary(MarginSummary marginSummary)
            {
                this._marginSummary = marginSummary;
                return this;
            }

            public MarginInformation Build()
            {
                return new MarginInformation
                {
                    MarginCallRecords = this._marginCallRecords,
                    MarginSummary = this._marginSummary
                };
            }
        }
    }
}