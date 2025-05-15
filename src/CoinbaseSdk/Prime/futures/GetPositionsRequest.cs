namespace CoinbaseSdk.Prime.Futures
{
    using System.Text.Json.Serialization;
    public class GetPositionsRequest(string entityId)
    {
        [JsonIgnore, JsonPropertyName("entity_id")]
        public string EntityId { get; set; } = entityId;

        [JsonPropertyName("product_id")]
        public string? ProductId { get; set; }

        public class GetPositionsRequestBuilder
        {
            private string? _productId;

            public GetPositionsRequestBuilder WithProductId(string productId)
            {
                _productId = productId;
                return this;
            }

            public GetPositionsRequest Build(string entityId)
            {
                return new GetPositionsRequest(entityId)
                {
                    ProductId = _productId,
                };
            }
        }
    }
}