namespace CoinbaseSdk.Prime.Futures
{
    using CoinbaseSdk.Prime.Common;

    public class ScheduleEntityFuturesSweepRequest(string entityId)
        : BasePrimeRequest(null, entityId)
    {
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

