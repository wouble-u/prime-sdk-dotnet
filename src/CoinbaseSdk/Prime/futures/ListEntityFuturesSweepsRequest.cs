namespace CoinbaseSdk.Prime.Futures
{
  using System.Text.Json.Serialization;
  public class ListEntityFuturesSweepsRequest(string entityId)
  {
    [JsonIgnore]
    public string EntityId { get; set; } = entityId;
  }
}