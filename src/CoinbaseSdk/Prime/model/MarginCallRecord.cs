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
    public class MarginCallRecord
    {
        [JsonPropertyName("margin_call_id")]
        public string? MarginCallId { get; set; }

        [JsonPropertyName("initial_notional_amount")]
        public string? InitialNotionalAmount { get; set; }

        [JsonPropertyName("outstanding_notional_amount")]
        public string? OutstandingNotionalAmount { get; set; }

        [JsonPropertyName("created_at")]
        public string? CreatedAt { get; set; }

        [JsonPropertyName("due_at")]
        public string? DueAt { get; set; }

        public MarginCallRecord() { }

        public class MarginCallRecordBuilder
        {
            private string? _marginCallId;
            private string? _initialNotionalAmount;
            private string? _outstandingNotionalAmount;
            private string? _createdAt;
            private string? _dueAt;

            public MarginCallRecordBuilder WithMarginCallId(string marginCallId)
            {
                this._marginCallId = marginCallId;
                return this;
            }

            public MarginCallRecordBuilder WithInitialNotionalAmount(string initialNotionalAmount)
            {
                this._initialNotionalAmount = initialNotionalAmount;
                return this;
            }

            public MarginCallRecordBuilder WithOutstandingNotionalAmount(string outstandingNotionalAmount)
            {
                this._outstandingNotionalAmount = outstandingNotionalAmount;
                return this;
            }

            public MarginCallRecordBuilder WithCreatedAt(string createdAt)
            {
                this._createdAt = createdAt;
                return this;
            }

            public MarginCallRecordBuilder WithDueAt(string dueAt)
            {
                this._dueAt = dueAt;
                return this;
            }

            public MarginCallRecord Build()
            {
                return new MarginCallRecord
                {
                    MarginCallId = this._marginCallId,
                    InitialNotionalAmount = this._initialNotionalAmount,
                    OutstandingNotionalAmount = this._outstandingNotionalAmount,
                    CreatedAt = this._createdAt,
                    DueAt = this._dueAt
                };
            }
        }
    }
}