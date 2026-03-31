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

namespace CoinbaseSdk.Prime.Positions
{
  using CoinbaseSdk.Core.Http;

  public interface IPositionsService
  {
    public ListAggregateEntityPositionsResponse ListAggregateEntityPositions(ListAggregateEntityPositionsRequest request, CallOptions? callOptions = null);

    public Task<ListAggregateEntityPositionsResponse> ListAggregateEntityPositionsAsync(
      ListAggregateEntityPositionsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

    public ListEntityPositionsResponse ListEntityPositions(ListEntityPositionsRequest request, CallOptions? callOptions = null);

    public Task<ListEntityPositionsResponse> ListEntityPositionsAsync(
      ListEntityPositionsRequest request,
      CallOptions? callOptions = null,
      CancellationToken cancellationToken = default);

  }
}
