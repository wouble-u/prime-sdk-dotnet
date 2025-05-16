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
  public class ShortCollateral
  {
    [JsonPropertyName("old_balance")]
    public string? OldBalance { get; set; }

    [JsonPropertyName("new_balance")]
    public string? NewBalance { get; set; }

    [JsonPropertyName("loan_interest_rate")]
    public string? LoanInterestRate { get; set; }

    [JsonPropertyName("collateral_interest_rate")]
    public string? CollateralInterestRate { get; set; }

    public ShortCollateral() { }

    public class ShortCollateralBuilder
    {
      private string? _oldBalance;
      private string? _newBalance;
      private string? _loanInterestRate;
      private string? _collateralInterestRate;

      public ShortCollateralBuilder WithOldBalance(string oldBalance)
      {
        this._oldBalance = oldBalance;
        return this;
      }

      public ShortCollateralBuilder WithNewBalance(string newBalance)
      {
        this._newBalance = newBalance;
        return this;
      }

      public ShortCollateralBuilder WithLoanInterestRate(string loanInterestRate)
      {
        this._loanInterestRate = loanInterestRate;
        return this;
      }

      public ShortCollateralBuilder WithCollateralInterestRate(string collateralInterestRate)
      {
        this._collateralInterestRate = collateralInterestRate;
        return this;
      }

      public ShortCollateral Build()
      {
        return new ShortCollateral
        {
          OldBalance = this._oldBalance,
          NewBalance = this._newBalance,
          LoanInterestRate = this._loanInterestRate,
          CollateralInterestRate = this._collateralInterestRate
        };
      }
    }
  }
}