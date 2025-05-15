namespace CoinbaseSdk.Prime.Futures
{
    using System.Text.Json.Serialization;
    public class CancelEntityFuturesSweepResponse
    {
        public bool? Success { get; set; }

        [JsonPropertyName("request_id")]
        public string? RequestId { get; set; }

        public CancelEntityFuturesSweepResponse() { }

        public class CancelEntityFuturesSweepResponseBuilder
        {
            private bool? _success;
            private string? _requestId;

            public CancelEntityFuturesSweepResponseBuilder WithSuccess(bool success)
            {
                this._success = success;
                return this;
            }

            public CancelEntityFuturesSweepResponseBuilder WithRequestId(string requestId)
            {
                this._requestId = requestId;
                return this;
            }

            public CancelEntityFuturesSweepResponse Build()
            {
                return new CancelEntityFuturesSweepResponse
                {
                    Success = _success,
                    RequestId = _requestId
                };
            }
        }
    }
}