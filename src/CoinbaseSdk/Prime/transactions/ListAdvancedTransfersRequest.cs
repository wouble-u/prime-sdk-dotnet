/*
 * Copyright 2026-present Coinbase Global, Inc.
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

namespace CoinbaseSdk.Prime.Transactions
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Common;
  using CoinbaseSdk.Prime.Model.Enums;

  /// <summary>
  /// List Advanced Transfers
  /// List advanced transfers for a given portfolio. This API is currently not available to all clients. Please reach out to Prime Operations with any questions.
  /// </summary>
  public class ListAdvancedTransfersRequest(string portfolioId) : PaginatedRequest
  {
    /// <summary>
    /// The portfolio ID
    /// </summary>
    [JsonIgnore]
    public string PortfolioId { get; set; } = portfolioId;

    /// <summary>
    /// The state of the Advanced Transfer to filter by
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// The type of the Advanced Transfer to filter by
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// UTC timestamp of creation from which to filter the response (inclusive, ISO-8601 format)
    /// </summary>
    [JsonPropertyName("start_time")]
    public string? StartTime { get; set; }

    /// <summary>
    /// UTC timestamp of creation until which to filter the response (exclusive, ISO-8601 format)
    /// </summary>
    [JsonPropertyName("end_time")]
    public string? EndTime { get; set; }

    /// <summary>
    /// The reference ID of the Advanced Transfer to filter by
    /// </summary>
    [JsonPropertyName("reference_id")]
    public string? ReferenceId { get; set; }

    public class Builder
    {
      private string? _portfolioId;
      private string? _state;
      private string? _type;
      private string? _startTime;
      private string? _endTime;
      private string? _referenceId;
      private string? _cursor;
      private SortDirection? _sortDirection;
      private int? _limit;

      /// <summary>
      /// The portfolio ID
      /// </summary>
      public Builder WithPortfolioId(string portfolioId)
      {
        _portfolioId = portfolioId;
        return this;
      }

      /// <summary>
      /// The state of the Advanced Transfer to filter by
      /// </summary>
      public Builder WithState(string? state)
      {
        _state = state;
        return this;
      }

      /// <summary>
      /// The type of the Advanced Transfer to filter by
      /// </summary>
      public Builder WithType(string? type)
      {
        _type = type;
        return this;
      }

      /// <summary>
      /// UTC timestamp of creation from which to filter the response (inclusive, ISO-8601 format)
      /// </summary>
      public Builder WithStartTime(string? startTime)
      {
        _startTime = startTime;
        return this;
      }

      /// <summary>
      /// UTC timestamp of creation until which to filter the response (exclusive, ISO-8601 format)
      /// </summary>
      public Builder WithEndTime(string? endTime)
      {
        _endTime = endTime;
        return this;
      }

      /// <summary>
      /// The reference ID of the Advanced Transfer to filter by
      /// </summary>
      public Builder WithReferenceId(string? referenceId)
      {
        _referenceId = referenceId;
        return this;
      }

      public Builder WithCursor(string cursor)
      {
        _cursor = cursor;
        return this;
      }

      public Builder WithSortDirection(SortDirection sortDirection)
      {
        _sortDirection = sortDirection;
        return this;
      }

      public Builder WithLimit(int limit)
      {
        _limit = limit;
        return this;
      }

      /// <summary>
      /// Validates required path parameters before building the request.
      /// </summary>
      private void Validate()
      {
        if (string.IsNullOrWhiteSpace(_portfolioId))
        {
          throw new CoinbaseClientException("PortfolioId is required");
        }
      }

      /// <summary>
      /// Builds a new <see cref="ListAdvancedTransfersRequest"/>.
      /// </summary>
      public ListAdvancedTransfersRequest Build()
      {
        Validate();
        return new ListAdvancedTransfersRequest(_portfolioId!)
        {
          State = _state,
          Type = _type,
          StartTime = _startTime,
          EndTime = _endTime,
          ReferenceId = _referenceId,
          Cursor = _cursor,
          SortDirection = _sortDirection,
          Limit = _limit,
        };
      }
    }
  }
}
