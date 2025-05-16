/*
 * Copyright 2025-present Coinbase Global, Inc.
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

namespace CoinbaseSdk.Prime.Model
{
  using System.Text.Json.Serialization;
  public class EntityBalance
  {
    public string? Symbol { get; set; }

    [JsonPropertyName("long_amount")]
    public string? LongAmount { get; set; }

    [JsonPropertyName("long_notional")]
    public string? LongNotional { get; set; }

    [JsonPropertyName("short_amount")]
    public string? ShortAmount { get; set; }

    [JsonPropertyName("short_notional")]
    public string? ShortNotional { get; set; }

    public EntityBalance() { }

    public class EntityBalanceBuilder
    {
      private string? _symbol;
      private string? _longAmount;
      private string? _longNotional;
      private string? _shortAmount;
      private string? _shortNotional;

      public EntityBalanceBuilder WithSymbol(string symbol)
      {
        this._symbol = symbol;
        return this;
      }

      public EntityBalanceBuilder WithLongAmount(string longAmount)
      {
        this._longAmount = longAmount;
        return this;
      }

      public EntityBalanceBuilder WithLongNotional(string longNotional)
      {
        this._longNotional = longNotional;
        return this;
      }

      public EntityBalanceBuilder WithShortAmount(string shortAmount)
      {
        this._shortAmount = shortAmount;
        return this;
      }

      public EntityBalanceBuilder WithShortNotional(string shortNotional)
      {
        this._shortNotional = shortNotional;
        return this;
      }

      public EntityBalance Build()
      {
        return new EntityBalance
        {
          Symbol = this._symbol,
          LongAmount = this._longAmount,
          LongNotional = this._longNotional,
          ShortAmount = this._shortAmount,
          ShortNotional = this._shortNotional
        };
      }
    }
  }
}