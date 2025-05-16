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
  public class WithdrawalPower
  {
    public string? Symbol { get; set; }

    public string? Amount { get; set; }

    public WithdrawalPower() { }

    public WithdrawalPower(string? symbol, string? amount)
    {
      Symbol = symbol;
      Amount = amount;
    }

    public class WithdrawalPowerBuilder
    {
      private string? _symbol;
      private string? _amount;

      public WithdrawalPowerBuilder WithSymbol(string? symbol)
      {
        _symbol = symbol;
        return this;
      }

      public WithdrawalPowerBuilder WithAmount(string? amount)
      {
        _amount = amount;
        return this;
      }

      public WithdrawalPower Build()
      {
        return new WithdrawalPower(_symbol, _amount);
      }
    }
  }
}