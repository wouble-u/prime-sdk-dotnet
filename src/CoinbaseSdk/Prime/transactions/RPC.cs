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

    public class RPC
    {
        [JsonPropertyName("skip_broadcast")]
        public bool? SkipBroadcast { get; set; }

        public string? Url { get; set; }

        public RPC() { }

        public class RPCBuilder
        {
            private bool? _skipBroadcast;
            private string? _url;

            public RPCBuilder() { }

            public RPCBuilder WithSkipBroadcast(bool skipBroadcast)
            {
                this._skipBroadcast = skipBroadcast;
                return this;
            }

            public RPCBuilder WithUrl(string url)
            {
                this._url = url;
                return this;
            }

            public RPC Build()
            {
                return new RPC { SkipBroadcast = this._skipBroadcast, Url = this._url };
            }
        }
    }
}
