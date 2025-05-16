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
  public class BuyingPower
  {
    [JsonPropertyName("portfolio_id")]
    public string? PortfolioId { get; set; }

    [JsonPropertyName("base_currency")]
    public string? BaseCurrency { get; set; }

    [JsonPropertyName("quote_currency")]
    public string? QuoteCurrency { get; set; }

    [JsonPropertyName("base_buying_power")]
    public string? BaseBuyingPower { get; set; }

    [JsonPropertyName("quote_buying_power")]
    public string? QuoteBuyingPower { get; set; }

    public BuyingPower() { }

    public class BuyingPowerBuilder
    {
      private string? _portfolioId;
      private string? _baseCurrency;
      private string? _quoteCurrency;
      private string? _baseBuyingPower;
      private string? _quoteBuyingPower;

      public BuyingPowerBuilder WithPortfolioId(string? portfolioId)
      {
        this._portfolioId = portfolioId;
        return this;
      }

      public BuyingPowerBuilder WithBaseCurrency(string? baseCurrency)
      {
        this._baseCurrency = baseCurrency;
        return this;
      }

      public BuyingPowerBuilder WithQuoteCurrency(string? quoteCurrency)
      {
        this._quoteCurrency = quoteCurrency;
        return this;
      }

      public BuyingPowerBuilder WithBaseBuyingPower(string? baseBuyingPower)
      {
        this._baseBuyingPower = baseBuyingPower;
        return this;
      }

      public BuyingPowerBuilder WithQuoteBuyingPower(string? quoteBuyingPower)
      {
        this._quoteBuyingPower = quoteBuyingPower;
        return this;
      }

      public BuyingPower Build()
      {
        return new BuyingPower
        {
          PortfolioId = this._portfolioId,
          BaseCurrency = this._baseCurrency,
          QuoteCurrency = this._quoteCurrency,
          BaseBuyingPower = this._baseBuyingPower,
          QuoteBuyingPower = this._quoteBuyingPower
        };
      }
    }
  }
}