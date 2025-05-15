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

namespace CoinbaseSdk.Prime.Activities
{
    using System.Text.Json.Serialization;
    using CoinbaseSdk.Core.Error;
    using CoinbaseSdk.Prime.Common;

    public class ListEntityActivitiesRequest(string entityId)
    {
        [JsonIgnore, JsonPropertyName("entity_id")]
        public string EntityId { get; set; } = entityId;

        [JsonPropertyName("activity_level")]
        public string? ActivityLevel { get; set; }
        public string[] Symbols { get; set; } = [];
        public string[] Categories { get; set; } = [];
        public string[] Statuses { get; set; } = [];
        [JsonPropertyName("start_time")]
        public string? StartTime { get; set; }
        [JsonPropertyName("end_time")]
        public string? EndTime { get; set; }
        public string? Cursor { get; set; }
        [JsonPropertyName("sort_direction")]
        public string? SortDirection { get; set; }
        public int? Limit { get; set; }

        public class ListEntityActivitiesRequestBuilder
        {
            private string? _entityId;
            private string? _activityLevel;
            private string[]? _symbols;
            private string[]? _categories;
            private string[]? _statuses;
            private string? _startTime;
            private string? _endTime;
            private string? _cursor;
            private string? _sortDirection;
            private int? _limit;

            public ListEntityActivitiesRequestBuilder WithEntityId(string entityId)
            {
                _entityId = entityId;
                return this;
            }

            public ListEntityActivitiesRequestBuilder WithActivityLevel(string activityLevel)
            {
                _activityLevel = activityLevel;
                return this;
            }

            public ListEntityActivitiesRequestBuilder WithSymbols(string[] symbols)
            {
                _symbols = symbols;
                return this;
            }

            public ListEntityActivitiesRequestBuilder WithCategories(string[] categories)
            {
                _categories = categories;
                return this;
            }

            public ListEntityActivitiesRequestBuilder WithStatuses(string[] statuses)
            {
                _statuses = statuses;
                return this;
            }

            public ListEntityActivitiesRequestBuilder WithStartTime(string startTime)
            {
                _startTime = startTime;
                return this;
            }

            public ListEntityActivitiesRequestBuilder WithEndTime(string endTime)
            {
                _endTime = endTime;
                return this;
            }

            public ListEntityActivitiesRequestBuilder WithCursor(string cursor)
            {
                _cursor = cursor;
                return this;
            }

            public ListEntityActivitiesRequestBuilder WithSortDirection(string sortDirection)
            {
                _sortDirection = sortDirection;
                return this;
            }

            public ListEntityActivitiesRequestBuilder WithLimit(int limit)
            {
                _limit = limit;
                return this;
            }

            public ListEntityActivitiesRequestBuilder WithPagination(Pagination pagination)
            {
                _cursor = pagination.NextCursor;
                _sortDirection = pagination.SortDirection;
                return this;
            }

            /// <summary>
            /// Validates the builder.
            /// </summary>
            /// <exception cref="CoinbaseClientException">Thrown when <see cref="_entityId" /> is null, empty, or whitespace.</exception>
            private void Validate()
            {
                if (string.IsNullOrWhiteSpace(_entityId))
                {
                    throw new CoinbaseClientException("EntityId is required");
                }
            }

            /// <summary>
            /// Builds the <see cref="ListEntityActivitiesRequest"/>.
            /// </summary>
            /// <returns>The <see cref="ListEntityActivitiesRequest"/>.</returns>
            /// <exception cref="CoinbaseClientException">Thrown when <see cref="_entityId" /> is null, empty, or whitespace.</exception>
            public ListEntityActivitiesRequest Build()
            {
                this.Validate();
                return new ListEntityActivitiesRequest(_entityId!)
                {
                    ActivityLevel = _activityLevel,
                    Symbols = _symbols ?? new string[] { },
                    Categories = _categories ?? new string[] { },
                    Statuses = _statuses ?? new string[] { },
                    StartTime = _startTime,
                    EndTime = _endTime,
                    Cursor = _cursor,
                    SortDirection = _sortDirection,
                    Limit = _limit
                };
            }
        }
    }
}
