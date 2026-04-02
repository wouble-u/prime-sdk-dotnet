/*
 * Copyright 2026-present Coinbase Global, Inc.
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

namespace CoinbaseSdk.Prime.Tests.Services
{
  using System;
  using System.Linq;
  using CoinbaseSdk.Core.Client;
  using CoinbaseSdk.Core.Http;
  using CoinbaseSdk.Prime.AdvancedTransfer;
  using Moq;
  using Xunit;

  public class AdvancedTransferServiceTests
  {
    [Fact]
    public void AdvancedTransferService_ShouldImplementIAdvancedTransferService()
    {
      var mockClient = new Mock<ICoinbaseClient>();
      var service = new AdvancedTransferService(mockClient.Object);
      Assert.IsAssignableFrom<IAdvancedTransferService>(service);
    }

    [Theory]
    [InlineData(nameof(IAdvancedTransferService.ListAdvancedTransfers), typeof(ListAdvancedTransfersRequest))]
    [InlineData(nameof(IAdvancedTransferService.CreateAdvancedTransfer), typeof(CreateAdvancedTransferRequest))]
    [InlineData(nameof(IAdvancedTransferService.CancelAdvancedTransfer), typeof(CancelAdvancedTransferRequest))]
    [InlineData(
      nameof(IAdvancedTransferService.ListAdvancedTransferTransactions),
      typeof(ListAdvancedTransferTransactionsRequest))]
    public void IAdvancedTransferService_ShouldDeclareSyncMethod(string methodName, Type requestType)
    {
      var method = typeof(IAdvancedTransferService).GetMethod(
        methodName,
        new[] { requestType, typeof(CallOptions) });
      Assert.NotNull(method);
    }

    [Theory]
    [InlineData(nameof(IAdvancedTransferService.ListAdvancedTransfers))]
    [InlineData(nameof(IAdvancedTransferService.CreateAdvancedTransfer))]
    [InlineData(nameof(IAdvancedTransferService.CancelAdvancedTransfer))]
    [InlineData(nameof(IAdvancedTransferService.ListAdvancedTransferTransactions))]
    public void IAdvancedTransferService_ShouldDeclareAsyncMethod(string methodBaseName)
    {
      var asyncName = methodBaseName + "Async";
      var methods = typeof(IAdvancedTransferService).GetMethods().Where(m => m.Name == asyncName).ToList();
      Assert.Single(methods);
    }
  }
}
