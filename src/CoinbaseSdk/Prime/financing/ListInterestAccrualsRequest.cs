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
    using System.Text.Json.Serialization;
    using CoinbaseSdk.Prime.Common;
    public class ListInterestAccrualsRequest(string entityId, string? portfolioId) : BasePrimeRequest(portfolioId, entityId)
    {
        [JsonPropertyName("start_date")]
        public string? StartDate { get; set; }

        [JsonPropertyName("end_date")]
        public string? EndDate { get; set; }

        public class ListInterestAccrualsRequestBuilder
        {
            private string? _startDate;
            private string? _endDate;

            public ListInterestAccrualsRequestBuilder WithStartDate(string startDate)
            {
                _startDate = startDate;
                return this;
            }

            public ListInterestAccrualsRequestBuilder WithEndDate(string endDate)
            {
                _endDate = endDate;
                return this;
            }

            public ListInterestAccrualsRequest Build(string entityId, string? portfolioId)
            {
                return new ListInterestAccrualsRequest(entityId, portfolioId)
                {
                    StartDate = _startDate,
                    EndDate = _endDate
                };
            }
        }
    }
}