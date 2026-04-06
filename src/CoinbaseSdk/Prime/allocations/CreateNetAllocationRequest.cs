/*
 * Copyright 2024-present Coinbase Global, Inc.
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

namespace CoinbaseSdk.Prime.Allocations
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Model;
  using CoinbaseSdk.Prime.Model.Enums;

    /// <summary>
    /// Create Portfolio Net Allocations.
    /// </summary>
  public class CreateNetAllocationRequest()
  {
    [JsonPropertyName("source_portfolio_id")]
    public string? SourcePortfolioId { get; set; }

    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    [JsonPropertyName("order_ids")]
    public string[] OrderIds { get; set; } = [];

    [JsonPropertyName("allocation_legs")]
    public AllocationLeg[] AllocationLegs { get; set; } = [];

    [JsonPropertyName("size_type")]
    public AllocationSizeType? SizeType { get; set; }

    [JsonPropertyName("remainder_destination_portfolio")]
    public string? RemainderDestinationPortfolio { get; set; }

    [JsonPropertyName("netting_id")]
    public string? NettingId { get; set; }

    public class CreateNetAllocationRequestBuilder
    {
      private string? _sourcePortfolioId;
      private string? _productId;
      private string[] _orderIds;
      private AllocationLeg[] _allocationLegs;
      private AllocationSizeType? _sizeType;
      private string? _remainderDestinationPortfolio;
      private string? _nettingId;

      public CreateNetAllocationRequestBuilder WithSourcePortfolioId(string? sourcePortfolioId)
      {
        _sourcePortfolioId = sourcePortfolioId;
        return this;
      }

      public CreateNetAllocationRequestBuilder WithProductId(string? productId)
      {
        _productId = productId;
        return this;
      }

      public CreateNetAllocationRequestBuilder WithOrderIds(string[] orderIds)
      {
        _orderIds = orderIds;
        return this;
      }

      public CreateNetAllocationRequestBuilder WithAllocationLegs(AllocationLeg[] allocationLegs)
      {
        _allocationLegs = allocationLegs;
        return this;
      }

      public CreateNetAllocationRequestBuilder WithSizeType(AllocationSizeType? sizeType)
      {
        _sizeType = sizeType;
        return this;
      }

      public CreateNetAllocationRequestBuilder WithRemainderDestinationPortfolio(string? remainderDestinationPortfolio)
      {
        _remainderDestinationPortfolio = remainderDestinationPortfolio;
        return this;
      }

      public CreateNetAllocationRequestBuilder WithNettingId(string? nettingId)
      {
        _nettingId = nettingId;
        return this;
      }

      private void Validate()
      {
      }

      public CreateNetAllocationRequest Build()
      {
        Validate();
        return new CreateNetAllocationRequest()
        {
          SourcePortfolioId = _sourcePortfolioId,
          ProductId = _productId,
          OrderIds = _orderIds ?? [],
          AllocationLegs = _allocationLegs ?? [],
          SizeType = _sizeType,
          RemainderDestinationPortfolio = _remainderDestinationPortfolio,
          NettingId = _nettingId,
        };
      }
    }
  }
}
