namespace CoinbaseSdk.Prime.Futures
{
  public class SetAutoSweepResponse
  {
    public bool? Success { get; set; }

    public SetAutoSweepResponse() { }

    public class SetAutoSweepResponseBuilder
    {
      public SetAutoSweepResponseBuilder() { }

      public bool? Success { get; set; }

      public SetAutoSweepResponseBuilder WithSuccess(bool success)
      {
        this.Success = success;
        return this;
      }

      public SetAutoSweepResponse Build()
      {
        return new SetAutoSweepResponse { Success = this.Success };
      }
    }
  }
}
