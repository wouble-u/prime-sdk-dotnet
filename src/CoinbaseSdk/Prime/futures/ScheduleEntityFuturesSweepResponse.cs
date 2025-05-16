namespace CoinbaseSdk.Prime.Futures
{
  using System.Text.Json.Serialization;

  public class ScheduleEntityFuturesSweepResponse
  {
    public bool Success { get; set; }

    [JsonPropertyName("request_id")]
    public string RequestId { get; set; } = string.Empty;

    public ScheduleEntityFuturesSweepResponse() { }

    public class ScheduleEntityFuturesSweepResponseBuilder
    {
      public ScheduleEntityFuturesSweepResponseBuilder() { }

      public bool Success { get; set; }
      public string RequestId { get; set; } = string.Empty;

      public ScheduleEntityFuturesSweepResponseBuilder WithSuccess(bool success)
      {
        this.Success = success;
        return this;
      }

      public ScheduleEntityFuturesSweepResponseBuilder WithRequestId(string requestId)
      {
        this.RequestId = requestId;
        return this;
      }

      public ScheduleEntityFuturesSweepResponse Build()
      {
        return new ScheduleEntityFuturesSweepResponse
        {
          Success = this.Success,
          RequestId = this.RequestId,
        };
      }
    }
  }
}
