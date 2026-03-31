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

namespace CoinbaseSdk.Prime.Activities
{
  using CoinbaseSdk.Core.Http;

  public interface IActivitiesService
  {
    /// <summary>
    /// Get Activity by Activity ID
    /// Retrieve an activity by its activity ID - this endpoint can retrieve both portfolio and entity activities when passed the appropriate API key
    /// </summary>
    public GetActivityResponse GetActivity(
      GetActivityRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Get Activity by Activity ID
    /// Retrieve an activity by its activity ID - this endpoint can retrieve both portfolio and entity activities when passed the appropriate API key
    /// </summary>
    public Task<GetActivityResponse> GetActivityAsync(
      GetActivityRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// List Entity Activities
    /// List all activities associated with a given entity.
    /// </summary>
    public ListEntityActivitiesResponse ListEntityActivities(
      ListEntityActivitiesRequest request,
      CallOptions? options = null);

    /// <summary>
    /// List Entity Activities
    /// List all activities associated with a given entity.
    /// </summary>
    public Task<ListEntityActivitiesResponse> ListEntityActivitiesAsync(
      ListEntityActivitiesRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// List Activities
    /// List all activities associated with a given portfolio.
    /// </summary>
    public ListActivitiesResponse ListActivities(
      ListActivitiesRequest request,
      CallOptions? options = null);

    /// <summary>
    /// List Activities
    /// List all activities associated with a given portfolio.
    /// </summary>
    public Task<ListActivitiesResponse> ListActivitiesAsync(
      ListActivitiesRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Portfolio Activity by Activity ID
    /// Retrieve an activity by its activity ID
    /// </summary>
    public GetPortfolioActivityResponse GetPortfolioActivity(
      GetPortfolioActivityRequest request,
      CallOptions? options = null);

    /// <summary>
    /// Get Portfolio Activity by Activity ID
    /// Retrieve an activity by its activity ID
    /// </summary>
    public Task<GetPortfolioActivityResponse> GetPortfolioActivityAsync(
      GetPortfolioActivityRequest request,
      CallOptions? options = null,
      CancellationToken cancellationToken = default);

  }
}
