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
    using CoinbaseSdk.Prime.Model.Enum;

    public class Accrual
    {
        [JsonPropertyName("accrual_id")]
        private string? AccrualId { get; set; }

        private string? Date { get; set; }

        [JsonPropertyName("portfolio_id")]
        private string? PortfolioId { get; set; }

        private string? Symbol { get; set; }

        [JsonPropertyName("loan_type")]
        private LoanType? LoanType { get; set; }

        [JsonPropertyName("interest_rate")]
        private string? InterestRate { get; set; }

        [JsonPropertyName("nominal_accrual")]
        private string? NominalAccrual { get; set; }

        [JsonPropertyName("notional_accrual")]
        private string? NotionalAccrual { get; set; }

        [JsonPropertyName("conversion_rate")]
        private string? ConversionRate { get; set; }

        [JsonPropertyName("loan_amount")]
        private string? LoanAmount { get; set; }

        private Benchmark? Benchmark { get; set; }

        [JsonPropertyName("benchmark_rate")]
        private string? BenchmarkRate { get; set; }

        private string? Spread { get; set; }

        [JsonPropertyName("rate_type")]
        private RateType? RateType { get; set; }

        [JsonPropertyName("loan_amount_notional")]
        private string? LoanAmountNotional { get; set; }

        [JsonPropertyName("nominal_open_borrow_sod")]
        private string? NominalOpenBorrowSod { get; set; }

        [JsonPropertyName("notional_open_borrow_sod")]
        private string? NotionalOpenBorrowSod { get; set; }

        public Accrual() { }

        public class AccrualBuilder
        {
            private string? _accrualId;
            private string? _date;
            private string? _portfolioId;
            private string? _symbol;
            private LoanType? _loanType;
            private string? _interestRate;
            private string? _nominalAccrual;
            private string? _notionalAccrual;
            private string? _conversionRate;
            private string? _loanAmount;
            private Benchmark? _benchmark;
            private string? _benchmarkRate;
            private string? _spread;
            private RateType? _rateType;
            private string? _loanAmountNotional;
            private string? _nominalOpenBorrowSod;
            private string? _notionalOpenBorrowSod;

            public AccrualBuilder WithAccrualId(string? accrualId)
            {
                this._accrualId = accrualId;
                return this;
            }

            public AccrualBuilder WithDate(string? date)
            {
                this._date = date;
                return this;
            }

            public AccrualBuilder WithPortfolioId(string? portfolioId)
            {
                this._portfolioId = portfolioId;
                return this;
            }

            public AccrualBuilder WithSymbol(string? symbol)
            {
                this._symbol = symbol;
                return this;
            }

            public AccrualBuilder WithLoanType(LoanType? loanType)
            {
                this._loanType = loanType;
                return this;
            }

            public AccrualBuilder WithInterestRate(string? interestRate)
            {
                this._interestRate = interestRate;
                return this;
            }

            public AccrualBuilder WithNominalAccrual(string? nominalAccrual)
            {
                this._nominalAccrual = nominalAccrual;
                return this;
            }

            public AccrualBuilder WithNotionalAccrual(string? notionalAccrual)
            {
                this._notionalAccrual = notionalAccrual;
                return this;
            }

            public AccrualBuilder WithConversionRate(string? conversionRate)
            {
                this._conversionRate = conversionRate;
                return this;
            }

            public AccrualBuilder WithLoanAmount(string? loanAmount)
            {
                this._loanAmount = loanAmount;
                return this;
            }

            public AccrualBuilder WithBenchmark(Benchmark? benchmark)
            {
                this._benchmark = benchmark;
                return this;
            }

            public AccrualBuilder WithBenchmarkRate(string? benchmarkRate)
            {
                this._benchmarkRate = benchmarkRate;
                return this;
            }

            public AccrualBuilder WithSpread(string? spread)
            {
                this._spread = spread;
                return this;
            }

            public AccrualBuilder WithRateType(RateType? rateType)
            {
                this._rateType = rateType;
                return this;
            }

            public AccrualBuilder WithLoanAmountNotional(string? loanAmountNotional)
            {
                this._loanAmountNotional = loanAmountNotional;
                return this;
            }

            public AccrualBuilder WithNominalOpenBorrowSod(string? nominalOpenBorrowSod)
            {
                this._nominalOpenBorrowSod = nominalOpenBorrowSod;
                return this;
            }

            public AccrualBuilder WithNotionalOpenBorrowSod(string? notionalOpenBorrowSod)
            {
                this._notionalOpenBorrowSod = notionalOpenBorrowSod;
                return this;
            }

            public Accrual Build()
            {
                return new Accrual
                {
                    AccrualId = this._accrualId,
                    Date = this._date,
                    PortfolioId = this._portfolioId,
                    Symbol = this._symbol,
                    LoanType = this._loanType,
                    InterestRate = this._interestRate,
                    NominalAccrual = this._nominalAccrual,
                    NotionalAccrual = this._notionalAccrual,
                    ConversionRate = this._conversionRate,
                    LoanAmount = this._loanAmount,
                    Benchmark = this._benchmark,
                    BenchmarkRate = this._benchmarkRate,
                    Spread = this._spread,
                    RateType = this._rateType,
                    LoanAmountNotional = this._loanAmountNotional,
                    NominalOpenBorrowSod = this._nominalOpenBorrowSod,
                    NotionalOpenBorrowSod = this._notionalOpenBorrowSod
                };
            }
        }
    }
}