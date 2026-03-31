# Changelog

## [0.5.0] - 2026-MAR-31

### Added

- **New API Endpoints**
  - `FuturesService.GetFcmEquity`
  - `ProductsService.GetCandles`
  - `StakingService.GetStakingStatus`
  - `StakingService.GetUnstakingStatus`
  - `StakingService.PreviewUnstake`
  - `TransactionsService.ListAdvancedTransfers`
  - `TransactionsService.CreateAdvancedTransfer`
  - `TransactionsService.CancelAdvancedTransfer`
  - `TransactionsService.ListAdvancedTransferTransactions`
  - `TransactionsService.GetTransactionTravelRuleData`
  - `TransactionsService.SubmitDepositTravelRuleData`

- **New Examples** (run with `dotnet run --file <path>`)

  ```bash
  # Futures
  dotnet run --file src/CoinbaseSdk/PrimeExample/examples/futures/GetFcmEquity.cs --entityId <entity_id>

  # Products
  dotnet run --file src/CoinbaseSdk/PrimeExample/examples/products/GetCandles.cs --portfolioId <portfolio_id> --productId BTC-USD --granularity ONE_HOUR

  # Staking
  dotnet run --file src/CoinbaseSdk/PrimeExample/examples/staking/GetStakingStatus.cs --portfolioId <portfolio_id> --walletId <wallet_id>
  dotnet run --file src/CoinbaseSdk/PrimeExample/examples/staking/GetUnstakingStatus.cs --portfolioId <portfolio_id> --walletId <wallet_id>
  dotnet run --file src/CoinbaseSdk/PrimeExample/examples/staking/PreviewUnstake.cs --portfolioId <portfolio_id> --walletId <wallet_id> --amount 1.0

  # Advanced Transfers
  dotnet run --file src/CoinbaseSdk/PrimeExample/examples/transactions/ListAdvancedTransfers.cs --portfolioId <portfolio_id>
  dotnet run --file src/CoinbaseSdk/PrimeExample/examples/transactions/CreateAdvancedTransfer.cs --portfolioId <portfolio_id> --transferType BLIND_MATCH
  dotnet run --file src/CoinbaseSdk/PrimeExample/examples/transactions/CancelAdvancedTransfer.cs --portfolioId <portfolio_id> --advancedTransferId <transfer_id>
  dotnet run --file src/CoinbaseSdk/PrimeExample/examples/transactions/ListAdvancedTransferTransactions.cs --portfolioId <portfolio_id> --advancedTransferId <transfer_id>

  # Travel Rule
  dotnet run --file src/CoinbaseSdk/PrimeExample/examples/transactions/GetTransactionTravelRuleData.cs --portfolioId <portfolio_id> --transactionId <transaction_id>
  dotnet run --file src/CoinbaseSdk/PrimeExample/examples/transactions/SubmitDepositTravelRuleData.cs --portfolioId <portfolio_id> --transactionId <transaction_id>
  ```

- **New Domain Models**
  - `AdvancedTransfer`, `BlindMatchMetadata`, `CommissionDetailTotal`
  - `FcmScheduledMaintenance`, `FcmTradingSessionDetails`, `FundMovement`
  - `FutureProductDetails`, `PerpetualProductDetails`
  - `RequestToSubmitTravelRuleDataForAnExistingDepositTransaction`
  - `StakingStatus`, `TravelRuleData`, `ValidatorAllocation`, `ValidatorStakingInfo`

- **New Enums**
  - `AdvancedTransferState`, `AdvancedTransferType`, `ContractExpiryType`
  - `ExpiringContractStatus`, `FcmMarginHealthState`, `FcmTradingSessionClosedReason`
  - `FcmTradingSessionState`, `ProductType`, `RiskManagementType`
  - `SecondaryPermission`, `StakeType`

- **Generator: ExamplePhase** — the SDK generator (`tools/generator`) now automatically creates
  runnable example scripts for any new endpoint that does not yet have one.

## [0.4.0] - 2025-DEC-23

### Added

- **New API Endpoints**
  - `FinancingService.GetCrossMarginOverview`
  - `FinancingService.ListFinancingEligibleAssets`
  - `FinancingService.ListTradeFinanceObligations`
  - `FuturesService.GetFcmMarginCallDetails`
  - `FuturesService.GetFcmRiskLimits`
  - `FuturesService.GetFcmSettings`
  - `FuturesService.SetFcmSettings`
  - `OrdersService.EditOrder`
  - `OrdersService.ListOrderEditHistory`
  - `OrdersService.ListPortfolioFills`
  - `PortfoliosService.GetPortfolioCounterparty`
  - `StakingService.ClaimStakingRewards`
  - `StakingService.CreatePortfolioStake`
  - `StakingService.CreatePortfolioUnstake`
  - `StakingService.ListTransactionValidators`
  - `WalletsService.CreateWalletDepositAddress`
  - `WalletsService.ListWalletAddresses`

- **Comprehensive Examples**
  - Added examples for all SDK service methods across 19 categories:
    activities, addressbook, allocations, assets, balances, commission,
    financing, futures, invoice, onchainaddressbook, orders, paymentmethods,
    portfolios, positions, products, staking, transactions, users, wallets

- **Unit Tests**
  - `CoinbasePrimeClientTests`
  - `PaginatedRequestBuilderTests`
  - `PaginatedRequestTests`
  - `PrimeJsonSerializerOptionsFactoryTests`
  - `PrimeSerializationSmokeTests`

- **New Domain Models**
  - `Action`, `Activity`, `ActivityCreationResponse`, `ActivityLevel`
  - `Commission`, `CounterpartyDestination`
  - `ExistingLocate`, `FcmMarginCall`, `FcmMarginCallDetails`, `FcmRiskLimit`
  - `FcmMarginCallState`, `FcmMarginCallType`, `HierarchyType`
  - `MarginAddOnType`, `Network`, `NetworkFamily`
  - `OnchainTransactionDetails`, `OrderEdit`, `OrderFill`, `OrderStatus`
  - `PaginatedRequest`, `PaginatedRequestBuilder`, `PaginatedResponse`
  - `PaymentMethodDestination`, `PmAssetInfo`, `PortfolioBalanceType`
  - `PortfolioStakingMetadata`, `PortfolioUser`
  - `RfqProductDetails`, `RiskAssessment`, `SigningStatus`, `SortDirection`
  - `Transaction`
  - `UserRole`, `VisibilityStatus`, `WalletAddress`
  - `WalletCryptoDepositInstructions`, `WalletDepositInstructionType`
  - `WalletFiatDepositInstructions`, `WalletVisibility`
  - `Web3Asset`, `Web3Balance`, `Web3TransactionMetadata`

### Removed

- **Unused Classes**
  - `ListPortfolioStakingBalancesRequest` / `ListPortfolioStakingBalancesResponse`
  - `ListAggregatePositionsRequest` / `ListAggregatePositionsResponse`
  - `CreateOnchainAddressBookEntryResponse`
  - `UpdateOnchainAddressBookEntryResponse`
  - `DeleteOnchainAddressGroupResponse`
  - `QuoteResponse`
  - `StakingInitiateResponse`
  - `StakingUnstakeResponse`

### Fixed

- **WalletsService** - `CreateWalletDepositAddress`

### Changed

- **Method Renaming**
  - `GetActivityByActivityId` → `GetActivity`
  - `GetEntityActivityByActivityId` → `GetPortfolioActivity`
  - `GetPortfolioAddressBook` → `ListAddressBookEntries`
  - `GetPortfolioAllocations` → `ListPortfolioAllocations`
  - `GetAllocationsByClientNettingId` → `ListAllocationsByClientNettingId`
  - `GetOrderByOrderId` → `GetOrder`
  - `GetPortfolioById` → `GetPortfolio`
  - `GetTransactionByTransactionId` → `GetTransaction`
  - `GetWalletById` → `GetWallet`

- **Model Renaming**
  - `GetActivityByActivityIdRequest/Response` → `GetActivityRequest/Response`
  - `GetEntityActivityByActivityIdRequest` → `GetActivityRequest`
  - `GetActivityByActivityIdRequest` → `GetPortfolioActivityRequest`
  - `GetPortfolioAddressBookRequest/Response` → `ListAddressBookEntriesRequest/Response`
  - `GetOrderByOrderIdRequest/Response` → `GetOrderRequest/Response`
  - `GetPortfolioByIdRequest/Response` → `GetPortfolioRequest/Response`
  - `GetTransactionByTransactionIdRequest/Response` → `GetTransactionRequest/Response`
  - `GetWalletByIdRequest/Response` → `GetWalletRequest/Response`
  - `PMAssetInfo` → `PmAssetInfo`

- **Pagination**
  - Typed `SortDirection` enum
  - Standardized request patterns

- **Model Updates**
  - `OrderFill` - `ClientProductId`, `VenueFees`, `CesCommission`
  - `Transaction` - `NetworkFamily`
  - `CreateOrderRequest` - `NetworkFamily`
  - `CreateWithdrawalRequest`

## [0.3.0] - 2025-MAY-15

### Removed

- Common abstract classes BasePrimeRequest and BaseListRequest

### Added

- Entity Endpoints
  - ListEntityBalances
  - ListEntityPositions
  - ListAggregateEntityPositions
- Futures Endpoints
  - CancelEntityFuturesSweep
  - GetEntityFcmBalance
  - GetEntityPositions
  - ListEntityFuturesSweeps
  - ScheduleEntityFuturesSweeps
  - SetAutoSweep
- RFQ Endpoints
  - CreateQuoteRequest
  - AcceptQuote
- Prime Financing Endpoints
  - ListExistingLocations
  - ListInterestAccruals
  - ListPortfolioInterestAccruals
  - ListMarginCallSummaries
  - ListMarginConversions
  - GetEntityLocateAvailabilities
  - GetMarginInformation
  - GetPortfolioBuyingPower
  - GetPortfolioCreditInformation
  - GetPortfolioWithdrawalPower
  - GetTieredPricingFees
  - CreateNewLocates
- Prime Staking Endpoints
  - CreateStake
  - CreateUnstake
- Moved all models to one communal package for easier export
- Moved all Request/Response object to service specific package
