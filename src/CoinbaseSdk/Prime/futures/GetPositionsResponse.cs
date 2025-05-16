namespace CoinbaseSdk.Prime.Futures
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Prime.Model;
  public class GetPositionsResponse
  {
    public FcmPosition[] Positions { get; set; } = [];

    [JsonPropertyName("clearing_account_id")]
    public string? ClearingAccountId { get; set; }

    public GetPositionsResponse() { }

    public class GetPositionsResponseBuilder
    {
      private FcmPosition[] _positions = [];
      private string? _clearingAccountId;

      public GetPositionsResponseBuilder WithPositions(FcmPosition[] positions)
      {
        _positions = positions;
        return this;
      }

      public GetPositionsResponseBuilder WithClearingAccountId(string clearingAccountId)
      {
        _clearingAccountId = clearingAccountId;
        return this;
      }

      public GetPositionsResponse Build()
      {
        return new GetPositionsResponse
        {
          Positions = _positions,
          ClearingAccountId = _clearingAccountId,
        };
      }
    }
  }
}