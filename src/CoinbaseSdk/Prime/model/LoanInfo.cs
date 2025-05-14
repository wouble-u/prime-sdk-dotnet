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

    public class LoanInfo
    {
        [JsonPropertyName("portfolio_id")]
        public string? PortfolioId { get; set; }

        public string? Symbol { get; set; }

        public string? Amount { get; set; }

        [JsonPropertyName("notional_amount")]
        public string? NotionalAmount { get; set; }

        [JsonPropertyName("due_date")]
        public string? DueDate { get; set; }

        public LoanInfo() { }

        public class LoanInfoBuilder
        {
            private string? _portfolioId;
            private string? _symbol;
            private string? _amount;
            private string? _notionalAmount;
            private string? _dueDate;

            public LoanInfoBuilder WithPortfolioId(string? portfolioId)
            {
                this._portfolioId = portfolioId;
                return this;
            }

            public LoanInfoBuilder WithSymbol(string? symbol)
            {
                this._symbol = symbol;
                return this;
            }

            public LoanInfoBuilder WithAmount(string? amount)
            {
                this._amount = amount;
                return this;
            }

            public LoanInfoBuilder WithNotionalAmount(string? notionalAmount)
            {
                this._notionalAmount = notionalAmount;
                return this;
            }

            public LoanInfoBuilder WithDueDate(string? dueDate)
            {
                this._dueDate = dueDate;
                return this;
            }

            public LoanInfo Build()
            {
                return new LoanInfo
                {
                    PortfolioId = this._portfolioId,
                    Symbol = this._symbol,
                    Amount = this._amount,
                    NotionalAmount = this._notionalAmount,
                    DueDate = this._dueDate
                };
            }
        }
    }
}