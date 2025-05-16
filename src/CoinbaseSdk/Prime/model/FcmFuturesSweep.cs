/*
 * Copyright 2025-present Coinbase Global, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace CoinbaseSdk.Prime.Model
{
  using System.Text.Json.Serialization;
  public class FcmFuturesSweep
  {
    public string? Id { get; set; }

    [JsonPropertyName("requested_amount")]
    public FcmFuturesSweepRequestAmount? RequestedAmount { get; set; }

    [JsonPropertyName("should_sweep_all")]
    public bool? ShouldSweepAll { get; set; }

    public FcmFuturesSweepStatus? Status { get; set; }

    [JsonPropertyName("scheduled_time")]
    public string? ScheduledTime { get; set; }

    public FcmFuturesSweep() { }

    public class FcmFuturesSweepBuilder
    {
      private string? _id;
      private FcmFuturesSweepRequestAmount? _requestedAmount;
      private bool? _shouldSweepAll;
      private FcmFuturesSweepStatus? _status;
      private string? _scheduledTime;

      public FcmFuturesSweepBuilder WithId(string id)
      {
        this._id = id;
        return this;
      }

      public FcmFuturesSweepBuilder WithRequestedAmount(FcmFuturesSweepRequestAmount requestedAmount)
      {
        this._requestedAmount = requestedAmount;
        return this;
      }

      public FcmFuturesSweepBuilder WithShouldSweepAll(bool shouldSweepAll)
      {
        this._shouldSweepAll = shouldSweepAll;
        return this;
      }

      public FcmFuturesSweepBuilder WithStatus(FcmFuturesSweepStatus status)
      {
        this._status = status;
        return this;
      }

      public FcmFuturesSweepBuilder WithScheduledTime(string scheduledTime)
      {
        this._scheduledTime = scheduledTime;
        return this;
      }

      public FcmFuturesSweep Build()
      {
        return new FcmFuturesSweep
        {
          Id = this._id,
          RequestedAmount = this._requestedAmount,
          ShouldSweepAll = this._shouldSweepAll,
          Status = this._status,
          ScheduledTime = this._scheduledTime
        };
      }
    }
  }
}