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

namespace CoinbaseSdk.Prime.Invoice
{
  using System.Text.Json.Serialization;
  using CoinbaseSdk.Core.Error;
  using CoinbaseSdk.Prime.Common;
  using CoinbaseSdk.Prime.Model.Enums;

  /// <summary>
  /// List Invoices
  /// Retrieve a list of invoices belonging to an entity.
  /// </summary>
  public class ListInvoicesRequest(string entityId) : PaginatedRequest
  {
    /// <summary>
    /// The entity ID
    /// </summary>
    [JsonIgnore]
    public string EntityId { get; set; } = entityId;

    /// <summary>
    /// Invoice states to filter the response
    /// </summary>
    [JsonPropertyName("states")]
    public string?[] States { get; set; } = [];

    /// <summary>
    /// Filter invoices by year
    /// </summary>
    [JsonPropertyName("billing_year")]
    public int? BillingYear { get; set; }

    /// <summary>
    /// Integer representing the month to filter by, 1 for January, 12 for December
    /// </summary>
    [JsonPropertyName("billing_month")]
    public int? BillingMonth { get; set; }

    public class Builder
    {
      private string? _entityId;
      private string?[]? _states;
      private int? _billingYear;
      private int? _billingMonth;
      private string? _cursor;
      private SortDirection? _sortDirection;
      private int? _limit;

      /// <summary>
      /// The entity ID
      /// </summary>
      public Builder WithEntityId(string entityId)
      {
        _entityId = entityId;
        return this;
      }

      /// <summary>
      /// Invoice states to filter the response
      /// </summary>
      public Builder WithStates(string?[] states)
      {
        _states = states;
        return this;
      }

      /// <summary>
      /// Filter invoices by year
      /// </summary>
      public Builder WithBillingYear(int? billingYear)
      {
        _billingYear = billingYear;
        return this;
      }

      /// <summary>
      /// Integer representing the month to filter by, 1 for January, 12 for December
      /// </summary>
      public Builder WithBillingMonth(int? billingMonth)
      {
        _billingMonth = billingMonth;
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
        if (string.IsNullOrWhiteSpace(_entityId))
        {
          throw new CoinbaseClientException("EntityId is required");
        }
      }

      /// <summary>
      /// Builds a new <see cref="ListInvoicesRequest"/>.
      /// </summary>
      public ListInvoicesRequest Build()
      {
        Validate();
        return new ListInvoicesRequest(_entityId!)
        {
          States = _states,
          BillingYear = _billingYear,
          BillingMonth = _billingMonth,
          Cursor = _cursor,
          SortDirection = _sortDirection,
          Limit = _limit,
        };
      }
    }
  }
}
