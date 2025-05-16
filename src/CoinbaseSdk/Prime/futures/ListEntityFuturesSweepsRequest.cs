namespace CoinbaseSdk.Prime.Futures
{
  using System.Text.Json.Serialization;
  public class ListEntityFuturesSweepsRequest(string entityId)
  {
    [JsonIgnore, JsonPropertyName("entity_id")]
    public string EntityId { get; set; } = entityId;
  }
}