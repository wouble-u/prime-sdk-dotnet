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
  public class PMAssetInfo
  {
    public string? Symbol { get; set; }

    public string? Amount { get; set; }

    public string? Price { get; set; }

    [JsonPropertyName("notional_amount")]
    public string? NotionalAmount { get; set; }

    [JsonPropertyName("asset_tier")]
    public string? AssetTier { get; set; }

    [JsonPropertyName("margin_eligible")]
    public bool MarginEligible { get; set; }

    [JsonPropertyName("base_margin_requirement")]
    public string? BaseMarginRequirement { get; set; }

    [JsonPropertyName("base_margin_requirement_notional")]
    public string? BaseMarginRequirementNotional { get; set; }

    [JsonPropertyName("adv_30d")]
    public string? Adv30d { get; set; }

    [JsonPropertyName("hist_5d_vol")]
    public string? Hist5dVol { get; set; }

    [JsonPropertyName("hist_30d_vol")]
    public string? Hist30dVol { get; set; }

    [JsonPropertyName("hist_90d_vol")]
    public string? Hist90dVol { get; set; }

    [JsonPropertyName("volatility_addon")]
    public string? VolatilityAddon { get; set; }

    [JsonPropertyName("liquidity_addon")]
    public string? LiquidityAddon { get; set; }

    [JsonPropertyName("total_position_margin")]
    public string? TotalPositionMargin { get; set; }

    [JsonPropertyName("short_nominal")]
    public string? ShortNominal { get; set; }

    [JsonPropertyName("long_nominal")]
    public string? LongNominal { get; set; }

    public PMAssetInfo()
    {
    }

    public class PMAssetInfoBuilder
    {
      private string? _symbol;
      private string? _amount;
      private string? _price;
      private string? _notionalAmount;
      private string? _assetTier;
      private bool _marginEligible;
      private string? _baseMarginRequirement;
      private string? _baseMarginRequirementNotional;
      private string? _adv30d;
      private string? _hist5dVol;
      private string? _hist30dVol;
      private string? _hist90dVol;
      private string? _volatilityAddon;
      private string? _liquidityAddon;
      private string? _totalPositionMargin;
      private string? _shortNominal;
      private string? _longNominal;

      public PMAssetInfoBuilder WithSymbol(string? symbol)
      {
        this._symbol = symbol;
        return this;
      }

      public PMAssetInfoBuilder WithAmount(string? amount)
      {
        this._amount = amount;
        return this;
      }

      public PMAssetInfoBuilder WithPrice(string? price)
      {
        this._price = price;
        return this;
      }

      public PMAssetInfoBuilder WithNotionalAmount(string? notionalAmount)
      {
        this._notionalAmount = notionalAmount;
        return this;
      }

      public PMAssetInfoBuilder WithAssetTier(string? assetTier)
      {
        this._assetTier = assetTier;
        return this;
      }

      public PMAssetInfoBuilder WithMarginEligible(bool marginEligible)
      {
        this._marginEligible = marginEligible;
        return this;
      }
      public PMAssetInfoBuilder WithBaseMarginRequirement(string? baseMarginRequirement)
      {
        this._baseMarginRequirement = baseMarginRequirement;
        return this;
      }
      public PMAssetInfoBuilder WithBaseMarginRequirementNotional(string? baseMarginRequirementNotional)
      {
        this._baseMarginRequirementNotional = baseMarginRequirementNotional;
        return this;
      }
      public PMAssetInfoBuilder WithAdv30d(string? adv30d)
      {
        this._adv30d = adv30d;
        return this;
      }
      public PMAssetInfoBuilder WithHist5dVol(string? hist5dVol)
      {
        this._hist5dVol = hist5dVol;
        return this;
      }
      public PMAssetInfoBuilder WithHist30dVol(string? hist30dVol)
      {
        this._hist30dVol = hist30dVol;
        return this;
      }
      public PMAssetInfoBuilder WithHist90dVol(string? hist90dVol)
      {
        this._hist90dVol = hist90dVol;
        return this;
      }
      public PMAssetInfoBuilder WithVolatilityAddon(string? volatilityAddon)
      {
        this._volatilityAddon = volatilityAddon;
        return this;
      }
      public PMAssetInfoBuilder WithLiquidityAddon(string? liquidityAddon)
      {
        this._liquidityAddon = liquidityAddon;
        return this;
      }
      public PMAssetInfoBuilder WithTotalPositionMargin(string? totalPositionMargin)
      {
        this._totalPositionMargin = totalPositionMargin;
        return this;
      }
      public PMAssetInfoBuilder WithShortNominal(string? shortNominal)
      {
        this._shortNominal = shortNominal;
        return this;
      }
      public PMAssetInfoBuilder WithLongNominal(string? longNominal)
      {
        this._longNominal = longNominal;
        return this;
      }
      public PMAssetInfo Build()
      {
        return new PMAssetInfo
        {
          Symbol = this._symbol,
          Amount = this._amount,
          Price = this._price,
          NotionalAmount = this._notionalAmount,
          AssetTier = this._assetTier,
          MarginEligible = this._marginEligible,
          BaseMarginRequirement = this._baseMarginRequirement,
          BaseMarginRequirementNotional = this._baseMarginRequirementNotional,
          Adv30d = this._adv30d,
          Hist5dVol = this._hist5dVol,
          Hist30dVol = this._hist30dVol,
          Hist90dVol = this._hist90dVol,
          VolatilityAddon = this._volatilityAddon,
          LiquidityAddon = this._liquidityAddon,
          TotalPositionMargin = this._totalPositionMargin,
          ShortNominal = this._shortNominal,
          LongNominal = this._longNominal
        };
      }
    }
  }
}