# Prime SDK Generator

Holistic code generation for the Coinbase Prime .NET SDK from the [Prime OpenAPI specification](https://api.prime.coinbase.com/v1/openapi.yaml).

## What it generates

Every run produces, together:

1. **Models & enums** (`CoinbaseSdk.Prime.Model` / `Model.Enums`) via OpenAPI Generator CLI + post-processing (same pipeline as the former model-only tool).
2. **Request / Response DTOs**, **service interfaces**, and **service implementations** under each feature folder (e.g. `orders/`, `wallets/`), driven by auto-derived operation bindings (`OperationBindingGenerator`), `config/operations-overrides.json`, and `config/generator-config.json`.

There is no mode to generate only one category; output is always kept in sync.

## Architecture

```
tools/generator/
  Program.cs                 # Entry: download spec, run all phases
  config/
    generator-config.json    # Transforms, tagToFolder, services registry, status-code overrides
    operations-overrides.json # Sparse patches per operationId (overrides win)
    .openapi-generator-ignore
    openapitools.json
  phases/
    ModelEnumPhase.cs        # OpenAPI Generator CLI + ModelPostProcessor
    OpenApiGenerator.cs
    ModelPostProcessor.cs
    ClientSurfacePhase.cs    # Orchestrates request/response/service emission
    ResponsePhase.cs
    RequestPhase.cs
    ServicePhase.cs
  processing/
    GeneratorConfiguration.cs
    GeneratorXmlDoc.cs
    SharedTransforms.cs
    NamingResolver.cs
    OpenApiSchemaCodegen.cs
    OperationBindingGenerator.cs
    OperationBindingValidator.cs
  spec/
    SpecParser.cs
    SpecModels.cs
    SpecResponseSchema.cs
  templates/                 # Model templates for CLI; placeholder .mustache for client surface
  sync-copyright-years-from-git.sh  # Aligns file-header Copyright years with Git first-commit dates
```

## Copyright years (generator sources)

- **File headers** under `tools/generator/` should use the year the file was **first added in Git**, not a hardcoded guess. After adding or renaming generator sources, run from the repo root:

```bash
bash tools/generator/sync-copyright-years-from-git.sh
```

- **Emitted C#** under `src/CoinbaseSdk/Prime/` (requests, responses, services, new examples) uses the year from the first commit that added `tools/generator/phases/RequestPhase.cs`, resolved at generator startup via `CopyrightHelper.InitializeSdkEmittedCopyrightYear`. **New** output files (no prior version on disk) get that year in `ApplyCopyrightYear`; existing files keep their on-disk year.

## Prerequisites

- .NET 9.0+
- OpenAPI Generator CLI:
  - `npm install -g @openapitools/openapi-generator-cli`
  - or `brew install openapi-generator`
- Network access to fetch the OpenAPI spec (or override `specUrl` in `generator-config.json`).

## Usage

From the repository root:

```bash
dotnet run --project tools/generator
```

Diagnostic flags (still runs all phases; only affects whether files are written):

```bash
dotnet run --project tools/generator -- --dry-run   # Log paths; do not write
dotnet run --project tools/generator -- --diff      # Compare generated text to files on disk
```

The generator always downloads the current YAML from `specUrl` in `generator-config.json` (cached under `generated/openapi.yaml`, gitignored).

Bindings are derived for every spec operation (see `OperationBindingGenerator`). `operations-overrides.json` may patch any field; stale `operationId` rows fail the run. Overrides that exactly match derived defaults log a warning and can be removed.

Or use the helper script from this directory:

```bash
cd tools/generator
./generate.sh
```

## Configuration

- **`config/generator-config.json`** — `filePathReplacements`, `contentReplacements`, `acronymMappings`, `enumNameMappings`, `tagToFolder` (OpenAPI tag → service key), `services` (folder + namespace + interface/class names), `serviceMethodOrders`, `statusCodeOverrides`, `specUrl`.
- **`config/operations-overrides.json`** — Optional array of sparse patches: `operationId` plus any of `sdkMethod`, `service`, `omitRequest`, `forcePaginated`, `paramTypeOverrides` (merged onto derived values).

### `serviceMethodOrders`

Maps each `service` key (same as binding `service`) to an ordered list of `sdkMethod` names. After binding operations, the generator sorts each service’s operations to match this list so emitted `I*Service` / `*Service` method order stays stable and aligned with the handwritten SDK. Methods not listed sort after known entries, alphabetically.

### `statusCodeOverrides`

Maps `sdkMethod` to HTTP status names accepted as success for `CoinbaseService.Request` / `RequestAsync` (e.g. `Created`, `OK`). The generator first uses OpenAPI-documented success codes (200/201); overrides extend that list when the live API returns **201 Created** but the published spec only lists **200** (or similar). **Confirm with the API team** when adding endpoints: accepting both `Created` and `OK` is permissive and avoids client failures if the server varies by environment or version.

## Workflow

1. Run the generator.
2. Review diff (`--diff` or `git diff`).
3. `dotnet build prime-sdk-dotnet.sln`
4. `dotnet test src/CoinbaseSdk/Prime.Tests/CoinbaseSdk.Prime.Tests.csproj`
5. Commit.

## Technical notes

- Raw OpenAPI YAML is cached under `generated/openapi.yaml` (gitignored). CLI output uses `generated/model-cli/` and is removed after model post-processing.
- Client DTOs and services are emitted as C# strings (see phase classes); additional `.mustache` files under `templates/` are placeholders for future template-driven tweaks.
