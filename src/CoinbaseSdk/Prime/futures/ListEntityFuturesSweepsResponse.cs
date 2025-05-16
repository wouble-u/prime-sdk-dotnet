namespace CoinbaseSdk.Prime.Futures
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Prime.Model;
  public class ListEntityFuturesSweepsResponse
  {
    public FcmFuturesSweep[] Sweeps { get; set; } = [];

    [JsonPropertyName("auto_sweep")]
    public bool AutoSweep { get; set; }

    public ListEntityFuturesSweepsResponse() { }

    public class ListEntityFuturesSweepsResponseBuilder
    {
      private FcmFuturesSweep[] _sweeps = [];
      private bool _autoSweep;

      public ListEntityFuturesSweepsResponseBuilder WithSweeps(FcmFuturesSweep[] sweeps)
      {
        _sweeps = sweeps;
        return this;
      }

      public ListEntityFuturesSweepsResponseBuilder WithAutoSweep(bool autoSweep)
      {
        _autoSweep = autoSweep;
        return this;
      }

      public ListEntityFuturesSweepsResponse Build()
      {
        return new ListEntityFuturesSweepsResponse
        {
          Sweeps = _sweeps,
          AutoSweep = _autoSweep,
        };
      }
    }
  }
}