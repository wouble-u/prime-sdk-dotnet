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

namespace CoinbaseSdk.Prime.Financing
{
    using CoinbaseSdk.Prime.Common;
    public class GetPortfolioWithdrawalPowerRequest(string portfolioId) : BasePrimeRequest(portfolioId, null)
    {
        public string? Symbol { get; set; }

        public class GetPortfolioWithdrawalPowerRequestBuilder
        {
            private string? _symbol;

            public GetPortfolioWithdrawalPowerRequestBuilder WithSymbol(string symbol)
            {
                _symbol = symbol;
                return this;
            }

            public GetPortfolioWithdrawalPowerRequest Build(string portfolioId)
            {
                return new GetPortfolioWithdrawalPowerRequest(portfolioId)
                {
                    Symbol = _symbol
                };
            }
        }
    }
}