namespace CoinbaseSdk.Prime.Futures
{
  using System.Text.Json.Serialization;

  public class GetFcmBalanceRequest(string entityId)
  {
    [JsonIgnore, JsonPropertyName("entity_id")]
    public string EntityId { get; set; } = entityId;

    public class GetEntityFcmBalanceRequestBuilder
    {
      private string _entityId = string.Empty;

      public GetEntityFcmBalanceRequestBuilder WithEntityId(string entityId)
      {
        this._entityId = entityId;
        return this;
      }

      public GetFcmBalanceRequest Build()
      {
        return new GetFcmBalanceRequest(_entityId);
      }
    }
  }
}