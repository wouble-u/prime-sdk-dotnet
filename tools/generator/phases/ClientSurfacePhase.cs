/*
 * Copyright 2025-present Coinbase Global, Inc.
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

using CoinbaseSdk.Tools.Generator.Processing;
using CoinbaseSdk.Tools.Generator.Spec;
using Microsoft.Extensions.Logging;

namespace CoinbaseSdk.Tools.Generator.Phases;

/// <summary>
/// Holistic generation of request DTOs, response DTOs, service interfaces, and service implementations
/// for all configured SDK operations (see <see cref="ResponsePhase"/>, <see cref="RequestPhase"/>, <see cref="ServicePhase"/>).
/// </summary>
public sealed class ClientSurfacePhase
{
  private readonly ILogger<ClientSurfacePhase> _logger;
  private readonly ParsedOpenApiDocument _doc;
  private readonly GeneratorConfiguration _cfg;
  private readonly SharedTransforms _transforms;
  private readonly string _primeSrcRoot;

  public ClientSurfacePhase(
    ILogger<ClientSurfacePhase> logger,
    ParsedOpenApiDocument doc,
    GeneratorConfiguration cfg,
    SharedTransforms transforms,
    string primeSrcRoot)
  {
    _logger = logger;
    _doc = doc;
    _cfg = cfg;
    _transforms = transforms;
    _primeSrcRoot = primeSrcRoot;
  }

  public async Task RunAsync(
    IReadOnlyList<SdkOperationBinding> bindings,
    bool dryRun,
    bool diffMode)
  {
    var byService = new Dictionary<string, List<(SdkOperationBinding B, ParsedOperation Op)>>(StringComparer.Ordinal);
    foreach (var b in bindings)
    {
      if (!_doc.OperationsById.TryGetValue(b.OperationId, out var op))
      {
        _logger.LogWarning("OpenAPI spec missing operationId {Id}; skipping.", b.OperationId);
        continue;
      }

      if (!byService.TryGetValue(b.Service, out var list))
      {
        list = new List<(SdkOperationBinding, ParsedOperation)>();
        byService[b.Service] = list;
      }

      list.Add((b, op));
    }

    foreach (var (_, ops) in byService.OrderBy(kv => kv.Key, StringComparer.Ordinal))
    {
      foreach (var (b, op) in ops)
      {
        if (!b.OmitRequest)
        {
          var req = RequestPhase.EmitRequest(_doc, _cfg, _transforms, b, op);
          await WriteOrDiffAsync(
            Path.Combine(_primeSrcRoot, NamingResolver.RequireService(_cfg, b.Service).Folder, $"{b.SdkMethod}Request.cs"),
            req,
            dryRun,
            diffMode);
        }

        var resp = ResponsePhase.EmitResponse(_doc, _cfg, _transforms, b, op);
        await WriteOrDiffAsync(
          Path.Combine(_primeSrcRoot, NamingResolver.RequireService(_cfg, b.Service).Folder, $"{b.SdkMethod}Response.cs"),
          resp,
          dryRun,
          diffMode);
      }
    }

    foreach (var (serviceKey, ops) in byService.OrderBy(kv => kv.Key, StringComparer.Ordinal))
    {
      var svcDef = NamingResolver.RequireService(_cfg, serviceKey);
      var iface = ServicePhase.EmitInterface(svcDef, ops);
      var impl = ServicePhase.EmitService(_cfg, svcDef, ops);
      await WriteOrDiffAsync(
        Path.Combine(_primeSrcRoot, svcDef.Folder, svcDef.InterfaceName + ".cs"),
        iface,
        dryRun,
        diffMode);
      await WriteOrDiffAsync(
        Path.Combine(_primeSrcRoot, svcDef.Folder, svcDef.ClassName + ".cs"),
        impl,
        dryRun,
        diffMode);
    }
  }

  private async Task WriteOrDiffAsync(string path, string content, bool dryRun, bool diffMode)
  {
    content = CopyrightHelper.ApplyCopyrightYear(path, content);

    if (diffMode)
    {
      if (!File.Exists(path))
      {
        _logger.LogInformation("DIFF missing file would be created: {Path}", path);
        return;
      }

      var existing = await File.ReadAllTextAsync(path);
      var normExisting = NormalizeNl(existing);
      var normContent = NormalizeNl(content);
      if (!string.Equals(normExisting, normContent, StringComparison.Ordinal))
      {
        _logger.LogWarning("DIFF differs: {Path}", path);
        ShowUnifiedDiff(path, normExisting, normContent);
      }

      return;
    }

    if (dryRun)
    {
      _logger.LogInformation("DRY-RUN would write {Path} ({Len} chars)", path, content.Length);
      return;
    }

    Directory.CreateDirectory(Path.GetDirectoryName(path)!);
    await File.WriteAllTextAsync(path, content);
  }

  private void ShowUnifiedDiff(string path, string existing, string generated)
  {
    var existingLines = existing.Split('\n');
    var generatedLines = generated.Split('\n');

    var diffs = new List<string>();
    var maxLines = Math.Max(existingLines.Length, generatedLines.Length);
    for (var i = 0; i < maxLines; i++)
    {
      var eL = i < existingLines.Length ? existingLines[i] : null;
      var gL = i < generatedLines.Length ? generatedLines[i] : null;
      if (eL != gL)
      {
        if (eL != null)
        {
          diffs.Add($"  - {eL}");
        }

        if (gL != null)
        {
          diffs.Add($"  + {gL}");
        }

        if (diffs.Count >= 20)
        {
          diffs.Add("  ... (truncated)");
          break;
        }
      }
    }

    foreach (var d in diffs)
    {
      _logger.LogInformation("{Diff}", d);
    }
  }

  private static string NormalizeNl(string s)
  {
    return s.Replace("\r\n", "\n", StringComparison.Ordinal);
  }
}
