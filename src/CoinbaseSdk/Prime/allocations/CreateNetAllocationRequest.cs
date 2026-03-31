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
  /// Create Portfolio Net Allocations
  /// Create net allocation for a given portfolio.
  /// </summary>
  public class CreateNetAllocationRequest()
  {
    /// <summary>
    /// The source portfolio id for the allocation
    /// </summary>
    [JsonPropertyName("source_portfolio_id")]
    public string? SourcePortfolioId { get; set; }

    /// <summary>
    /// The product for the allocation
    /// </summary>
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    /// <summary>
    /// The list of order ids in the allocation
    /// </summary>
    [JsonPropertyName("order_ids")]
    public string?[] OrderIds { get; set; } = [];

    /// <summary>
    /// The list of allocation_legs for the allocation
    /// </summary>
    [JsonPropertyName("allocation_legs")]
    public AllocationLeg[] AllocationLegs { get; set; } = [];

    [JsonPropertyName("size_type")]
    public AllocationSizeType SizeType { get; set; }

    /// <summary>
    /// The portfolio where to allocate the remainder of the size
    /// </summary>
    [JsonPropertyName("remainder_destination_portfolio")]
    public string? RemainderDestinationPortfolio { get; set; }

    /// <summary>
    /// The ID to identify an in-flight net allocation.
    /// </summary>
    [JsonPropertyName("netting_id")]
    public string? NettingId { get; set; }

    public class Builder
    {
      private string? _sourcePortfolioId;
      private string? _productId;
      private string?[] _orderIds;
      private AllocationLeg[] _allocationLegs;
      private AllocationSizeType _sizeType;
      private string? _remainderDestinationPortfolio;
      private string? _nettingId;

      /// <summary>
      /// The source portfolio id for the allocation
      /// </summary>
      public Builder WithSourcePortfolioId(string? sourcePortfolioId)
      {
        _sourcePortfolioId = sourcePortfolioId;
        return this;
      }

      /// <summary>
      /// The product for the allocation
      /// </summary>
      public Builder WithProductId(string? productId)
      {
        _productId = productId;
        return this;
      }

      /// <summary>
      /// The list of order ids in the allocation
      /// </summary>
      public Builder WithOrderIds(string?[] orderIds)
      {
        _orderIds = orderIds;
        return this;
      }

      /// <summary>
      /// The list of allocation_legs for the allocation
      /// </summary>
      public Builder WithAllocationLegs(AllocationLeg[] allocationLegs)
      {
        _allocationLegs = allocationLegs;
        return this;
      }

      public Builder WithSizeType(AllocationSizeType sizeType)
      {
        _sizeType = sizeType;
        return this;
      }

      /// <summary>
      /// The portfolio where to allocate the remainder of the size
      /// </summary>
      public Builder WithRemainderDestinationPortfolio(string? remainderDestinationPortfolio)
      {
        _remainderDestinationPortfolio = remainderDestinationPortfolio;
        return this;
      }

      /// <summary>
      /// The ID to identify an in-flight net allocation.
      /// </summary>
      public Builder WithNettingId(string? nettingId)
      {
        _nettingId = nettingId;
        return this;
      }

      /// <summary>
      /// Validates required path parameters before building the request.
      /// </summary>
      private void Validate()
      {
      }

      /// <summary>
      /// Builds a new <see cref="CreateNetAllocationRequest"/>.
      /// </summary>
      public CreateNetAllocationRequest Build()
      {
        Validate();
        return new CreateNetAllocationRequest()
        {
          SourcePortfolioId = _sourcePortfolioId,
          ProductId = _productId,
          OrderIds = _orderIds,
          AllocationLegs = _allocationLegs,
          SizeType = _sizeType,
          RemainderDestinationPortfolio = _remainderDestinationPortfolio,
          NettingId = _nettingId,
        };
      }
    }
  }
}
