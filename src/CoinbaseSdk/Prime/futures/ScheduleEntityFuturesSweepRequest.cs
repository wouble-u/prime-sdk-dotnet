namespace CoinbaseSdk.Prime.Futures
{
    using System.Text.Json.Serialization;

    public class ScheduleEntityFuturesSweepRequest(string entityId)
    {
        [JsonIgnore, JsonPropertyName("entity_id")]
        public string EntityId { get; set; } = entityId;

        public string? Amount { get; set; }
        public string? Currency { get; set; }

        public class ScheduleEntityFuturesSweepRequestBuilder
        {
            public ScheduleEntityFuturesSweepRequestBuilder(string entityId)
            {
                EntityId = entityId;
            }

            public string EntityId { get; }
            public string? Amount { get; set; }
            public string? Currency { get; set; }

            public ScheduleEntityFuturesSweepRequest Build()
            {
                return new ScheduleEntityFuturesSweepRequest(EntityId)
                {
                    Amount = Amount,
                    Currency = Currency,
                };
            }
        }
    }
}

