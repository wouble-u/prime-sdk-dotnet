namespace CoinbaseSdk.Prime.Futures
{
    using System.Text.Json.Serialization;
    using CoinbaseSdk.Prime.Common;

    public class SetAutoSweepRequest(string entityId) : BasePrimeRequest(null, entityId)
    {
        [JsonPropertyName("auto_sweep")]
        public bool? AutoSweep { get; set; }

        public class SetAutoSweepRequestBuilder
        {
            public SetAutoSweepRequestBuilder(string entityId)
            {
                EntityId = entityId;
            }

            public string EntityId { get; }
            public bool? AutoSweep { get; set; }

            public SetAutoSweepRequestBuilder WithAutoSweep(bool autoSweep)
            {
                AutoSweep = autoSweep;
                return this;
            }

            public SetAutoSweepRequest Build()
            {
                return new SetAutoSweepRequest(EntityId) { AutoSweep = AutoSweep };
            }
        }
    }
}
