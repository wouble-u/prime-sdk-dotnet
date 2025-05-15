namespace CoinbaseSdk.Prime.Futures
{
    using System.Text.Json.Serialization;
    public class CancelEntityFuturesSweepRequest(string entityId)
    {
        [JsonIgnore, JsonPropertyName("entity_id")]
        public string EntityId { get; set; } = entityId;
    }
}