namespace CoinbaseSdk.Prime.Futures
{
    using CoinbaseSdk.Prime.Common;

    public class GetFcmBalanceRequest(string entityId) : BasePrimeRequest(null, entityId)
    {
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