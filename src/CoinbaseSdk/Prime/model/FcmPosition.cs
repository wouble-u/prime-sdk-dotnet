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
  public class FcmPosition
  {
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    public FcmPositionSide? Side { get; set; }

    [JsonPropertyName("number_of_contracts")]
    public string? NumberOfContracts { get; set; }

    [JsonPropertyName("daily_realized_pnl")]
    public string? DailyRealizedPnl { get; set; }

    [JsonPropertyName("unrealized_pnl")]
    public string? UnrealizedPnl { get; set; }

    [JsonPropertyName("current_price")]
    public string? CurrentPrice { get; set; }

    [JsonPropertyName("avg_entry_price")]
    public string? AvgEntryPrice { get; set; }

    [JsonPropertyName("expiration_time")]
    public string? ExpirationTime { get; set; }

    public FcmPosition() { }

    public class FcmPositionBuilder
    {
      private string? _productId;
      private FcmPositionSide? _side;
      private string? _numberOfContracts;
      private string? _dailyRealizedPnl;
      private string? _unrealizedPnl;
      private string? _currentPrice;
      private string? _avgEntryPrice;
      private string? _expirationTime;

      public FcmPositionBuilder WithProductId(string productId)
      {
        this._productId = productId;
        return this;
      }

      public FcmPositionBuilder WithSide(FcmPositionSide side)
      {
        this._side = side;
        return this;
      }

      public FcmPositionBuilder WithNumberOfContracts(string numberOfContracts)
      {
        this._numberOfContracts = numberOfContracts;
        return this;
      }

      public FcmPositionBuilder WithDailyRealizedPnl(string dailyRealizedPnl)
      {
        this._dailyRealizedPnl = dailyRealizedPnl;
        return this;
      }

      public FcmPositionBuilder WithUnrealizedPnl(string unrealizedPnl)
      {
        this._unrealizedPnl = unrealizedPnl;
        return this;
      }

      public FcmPositionBuilder WithCurrentPrice(string currentPrice)
      {
        this._currentPrice = currentPrice;
        return this;
      }

      public FcmPositionBuilder WithAvgEntryPrice(string avgEntryPrice)
      {
        this._avgEntryPrice = avgEntryPrice;
        return this;
      }

      public FcmPositionBuilder WithExpirationTime(string expirationTime)
      {
        this._expirationTime = expirationTime;
        return this;
      }

      public FcmPosition Build()
      {
        return new FcmPosition
        {
          ProductId = this._productId,
          Side = this._side,
          NumberOfContracts = this._numberOfContracts,
          DailyRealizedPnl = this._dailyRealizedPnl,
          UnrealizedPnl = this._unrealizedPnl,
          CurrentPrice = this._currentPrice,
          AvgEntryPrice = this._avgEntryPrice,
          ExpirationTime = this._expirationTime
        };
      }
    }
  }
}