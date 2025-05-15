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
    public class Position
    {
        public string? Symbol { get; set; }

        public string? Long { get; set; }

        public string? Short { get; set; }

        [JsonPropertyName("position_reference")]
        public PositionReference? PositionReference { get; set; }

        public Position() { }

        public class PositionBuilder
        {
            private string? _symbol;
            private string? _long;
            private string? _short;
            private PositionReference? _positionReference;

            public PositionBuilder WithSymbol(string symbol)
            {
                this._symbol = symbol;
                return this;
            }

            public PositionBuilder WithLong(string longPosition)
            {
                this._long = longPosition;
                return this;
            }

            public PositionBuilder WithShort(string shortPosition)
            {
                this._short = shortPosition;
                return this;
            }

            public PositionBuilder WithPositionReference(PositionReference positionReference)
            {
                this._positionReference = positionReference;
                return this;
            }

            public Position Build()
            {
                return new Position
                {
                    Symbol = this._symbol,
                    Long = this._long,
                    Short = this._short,
                    PositionReference = this._positionReference
                };
            }
        }
    }
}