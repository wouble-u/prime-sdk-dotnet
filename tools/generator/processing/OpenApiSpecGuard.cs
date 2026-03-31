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

using System.Security.Cryptography;
using System.Text;
using CoinbaseSdk.Tools.Generator;
using CoinbaseSdk.Tools.Generator.Spec;
using Microsoft.Extensions.Logging;

namespace CoinbaseSdk.Tools.Generator.Processing;

public static class OpenApiSpecGuard
{
  public const string FingerprintFileName = "openapi-spec.sha256";

  public static async Task<string> ComputeSha256Async(string specPath, CancellationToken cancellationToken = default)
  {
    var bytes = await File.ReadAllBytesAsync(specPath, cancellationToken).ConfigureAwait(false);
    var hash = SHA256.HashData(bytes);
    return Convert.ToHexString(hash).ToLowerInvariant();
  }

  public static async Task VerifyFingerprintAsync(
    ILogger logger,
    string specPath,
    string configDir,
    bool allowDrift,
    bool refresh,
    CancellationToken cancellationToken = default)
  {
    var actual = await ComputeSha256Async(specPath, cancellationToken).ConfigureAwait(false);
    var fpPath = Path.Combine(configDir, FingerprintFileName);

    if (refresh)
    {
      await File.WriteAllTextAsync(
          fpPath,
          actual + Environment.NewLine,
          Encoding.UTF8,
          cancellationToken)
        .ConfigureAwait(false);
      logger.LogInformation("Wrote OpenAPI spec fingerprint to {Path}: {Hash}", fpPath, actual);
      return;
    }

    if (!File.Exists(fpPath))
    {
      logger.LogWarning(
        "No pinned OpenAPI fingerprint at {Path}. Commit {File} after verifying a spec update so unexpected remote changes fail the generator.",
        fpPath,
        FingerprintFileName);
      return;
    }

    var expected = (await File.ReadAllTextAsync(fpPath, cancellationToken).ConfigureAwait(false)).Trim();
    if (string.Equals(expected, actual, StringComparison.OrdinalIgnoreCase))
    {
      logger.LogInformation("OpenAPI spec fingerprint OK ({Hash}).", actual);
      return;
    }

    if (allowDrift)
    {
      logger.LogWarning(
        "OpenAPI spec fingerprint mismatch (expected {Expected}, actual {Actual}). Continuing because --allow-spec-drift was passed.",
        expected,
        actual);
      return;
    }

    throw new InvalidOperationException(
      "OpenAPI spec SHA-256 mismatch — the downloaded spec differs from the committed pin.\n" +
      $"  Expected (tools/generator/config/{FingerprintFileName}): {expected}\n" +
      $"  Actual (downloaded): {actual}\n" +
      "If Coinbase published an intentional API update, refresh the pin after review:\n" +
      "  dotnet run --project tools/generator -- --refresh-spec-fingerprint\n" +
      "To bypass once (not for CI): --allow-spec-drift");
  }

  public static void ValidateOperationBindings(
    ILogger logger,
    ParsedOpenApiDocument document,
    IReadOnlyList<SdkOperationBinding> operations)
  {
    var missing = operations
      .Where(b => !document.OperationsById.ContainsKey(b.OperationId))
      .Select(b => b.OperationId)
      .Distinct(StringComparer.Ordinal)
      .OrderBy(x => x, StringComparer.Ordinal)
      .ToList();
    if (missing.Count > 0)
    {
      throw new InvalidOperationException(
        "operations.json references operationId values that are not in the OpenAPI spec: " +
        string.Join(", ", missing));
    }

    var bound = new HashSet<string>(operations.Select(o => o.OperationId), StringComparer.Ordinal);
    var unbound = document.OperationsById.Keys
      .Where(id => !bound.Contains(id))
      .OrderBy(x => x, StringComparer.Ordinal)
      .ToList();
    if (unbound.Count > 0)
    {
      logger.LogWarning(
        "OpenAPI spec lists {Count} operation(s) not present in operations.json (SDK may omit new endpoints until added): {Sample}",
        unbound.Count,
        string.Join(", ", unbound.Take(12)) + (unbound.Count > 12 ? ", …" : string.Empty));
    }
  }
}
