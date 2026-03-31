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

using System.Text;
using CoinbaseSdk.Tools.Generator.Processing;
using CoinbaseSdk.Tools.Generator.Spec;

namespace CoinbaseSdk.Tools.Generator.Phases;

public static class ServicePhase
{
  private static readonly HashSet<string> CreatedAndOk = new(StringComparer.Ordinal)
  {
    "CreateOrder", "CreateQuote", "CreateWallet", "CreateWalletDepositAddress",
    "CreateConversion", "CreateTransfer", "CreateWithdrawal", "CreateOnchainTransaction",
    "CreateAllocation", "CreateNetAllocation", "CreateAddressBookEntry"
  };

  public static string EmitInterface(ServiceDefinition svc, List<(SdkOperationBinding B, ParsedOperation Op)> ops)
  {
    var ns = NamingResolver.FullNamespace(svc);
    var sb = new StringBuilder();
    AppendCopyright(sb);
    sb.AppendLine($"namespace {ns}");
    sb.AppendLine("{");
    sb.AppendLine("  using CoinbaseSdk.Core.Http;");
    sb.AppendLine();
    sb.AppendLine($"  public interface {svc.InterfaceName}");
    sb.AppendLine("  {");
    foreach (var (b, _) in ops)
    {
      if (b.OmitRequest)
      {
        sb.AppendLine($"    public {b.SdkMethod}Response {b.SdkMethod}(");
        sb.AppendLine("      CallOptions? options = null);");
        sb.AppendLine();
        sb.AppendLine($"    public Task<{b.SdkMethod}Response> {b.SdkMethod}Async(");
        sb.AppendLine("      CallOptions? options = null,");
        sb.AppendLine("      CancellationToken cancellationToken = default);");
        sb.AppendLine();
        continue;
      }

      sb.AppendLine($"    public {b.SdkMethod}Response {b.SdkMethod}(");
      sb.AppendLine($"      {b.SdkMethod}Request request,");
      sb.AppendLine("      CallOptions? options = null);");
      sb.AppendLine();
      sb.AppendLine($"    public Task<{b.SdkMethod}Response> {b.SdkMethod}Async(");
      sb.AppendLine($"      {b.SdkMethod}Request request,");
      sb.AppendLine("      CallOptions? options = null,");
      sb.AppendLine("      CancellationToken cancellationToken = default);");
      sb.AppendLine();
    }

    sb.AppendLine("  }");
    sb.AppendLine("}");
    return sb.ToString();
  }

  public static string EmitService(
    GeneratorConfiguration cfg,
    ServiceDefinition svc,
    List<(SdkOperationBinding B, ParsedOperation Op)> ops)
  {
    var ns = NamingResolver.FullNamespace(svc);
    var sb = new StringBuilder();
    AppendCopyright(sb);
    sb.AppendLine($"namespace {ns}");
    sb.AppendLine("{");
    sb.AppendLine("  using System.Net;");
    sb.AppendLine("  using CoinbaseSdk.Core.Client;");
    sb.AppendLine("  using CoinbaseSdk.Core.Http;");
    sb.AppendLine("  using CoinbaseSdk.Core.Service;");
    sb.AppendLine();
    sb.AppendLine($"  public class {svc.ClassName}(ICoinbaseClient client) : CoinbaseService(client), {svc.InterfaceName}");
    sb.AppendLine("  {");
    foreach (var (b, op) in ops)
    {
      var pathExpr = ToCSharpPathExpression(op.Path, b.OmitRequest);
      var method = ToHttpMethodExpression(op.HttpMethod);
      var status = StatusArray(cfg, b.SdkMethod, op.HttpMethod);
      var bodyArg = RequestBodyArgument(b, op);
      if (b.OmitRequest)
      {
        sb.AppendLine($"    public {b.SdkMethod}Response {b.SdkMethod}(");
        sb.AppendLine("      CallOptions? options = null)");
        sb.AppendLine("    {");
        sb.AppendLine($"      return Request<{b.SdkMethod}Response>(");
        sb.AppendLine($"        {method},");
        sb.AppendLine($"        {pathExpr},");
        sb.AppendLine($"        {status},");
        sb.AppendLine("        null,");
        sb.AppendLine("        options);");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine($"    public Task<{b.SdkMethod}Response> {b.SdkMethod}Async(");
        sb.AppendLine("      CallOptions? options = null,");
        sb.AppendLine("      CancellationToken cancellationToken = default)");
        sb.AppendLine("    {");
        sb.AppendLine($"      return RequestAsync<{b.SdkMethod}Response>(");
        sb.AppendLine($"        {method},");
        sb.AppendLine($"        {pathExpr},");
        sb.AppendLine($"        {status},");
        sb.AppendLine("        null,");
        sb.AppendLine("        options,");
        sb.AppendLine("        cancellationToken);");
        sb.AppendLine("    }");
        sb.AppendLine();
        continue;
      }

      sb.AppendLine($"    public {b.SdkMethod}Response {b.SdkMethod}(");
      sb.AppendLine($"      {b.SdkMethod}Request request,");
      sb.AppendLine("      CallOptions? options = null)");
      sb.AppendLine("    {");
      sb.AppendLine($"      return Request<{b.SdkMethod}Response>(");
      sb.AppendLine($"        {method},");
      sb.AppendLine($"        {pathExpr},");
      sb.AppendLine($"        {status},");
      sb.AppendLine($"        {bodyArg},");
      sb.AppendLine("        options);");
      sb.AppendLine("    }");
      sb.AppendLine();
      sb.AppendLine($"    public Task<{b.SdkMethod}Response> {b.SdkMethod}Async(");
      sb.AppendLine($"      {b.SdkMethod}Request request,");
      sb.AppendLine("      CallOptions? options = null,");
      sb.AppendLine("      CancellationToken cancellationToken = default)");
      sb.AppendLine("    {");
      sb.AppendLine($"      return RequestAsync<{b.SdkMethod}Response>(");
      sb.AppendLine($"        {method},");
      sb.AppendLine($"        {pathExpr},");
      sb.AppendLine($"        {status},");
      sb.AppendLine($"        {bodyArg},");
      sb.AppendLine("        options,");
      sb.AppendLine("        cancellationToken);");
      sb.AppendLine("    }");
      sb.AppendLine();
    }

    sb.AppendLine("  }");
    sb.AppendLine("}");
    return sb.ToString();
  }

  private static string RequestBodyArgument(SdkOperationBinding b, ParsedOperation op)
  {
    if (b.OmitRequest)
    {
      return "null";
    }

    var hasQuery = op.Parameters.Any(p => p.In == "query");
    var hasBody = op.RequestBodyJsonSchema != null;
    if (op.HttpMethod == "GET")
    {
      return hasQuery ? "request" : "null";
    }

    if (op.HttpMethod == "POST" || op.HttpMethod == "PUT" || op.HttpMethod == "PATCH")
    {
      return hasBody || hasQuery ? "request" : "null";
    }

    return "null";
  }

  private static string StatusArray(GeneratorConfiguration cfg, string sdkMethod, string httpMethod)
  {
    if (cfg.StatusCodeOverrides.TryGetValue(sdkMethod, out var list))
    {
      return "[" + string.Join(", ", list.Select(s => $"HttpStatusCode.{s}")) + "]";
    }

    if (httpMethod == "POST" && CreatedAndOk.Contains(sdkMethod))
    {
      return "[HttpStatusCode.Created, HttpStatusCode.OK]";
    }

    return "[HttpStatusCode.OK]";
  }

  private static string ToCSharpPathExpression(string openApiPath, bool omitRequest)
  {
    var p = openApiPath.StartsWith("/v1/", StringComparison.Ordinal)
      ? openApiPath[3..]
      : openApiPath;
    var sb = new StringBuilder();
    sb.Append("$\"");
    var i = 0;
    while (i < p.Length)
    {
      if (p[i] == '{')
      {
        if (omitRequest)
        {
          throw new InvalidOperationException(
            "omitRequest operations cannot include path template parameters.");
        }

        var end = p.IndexOf('}', i);
        var raw = p.Substring(i + 1, end - i - 1);
        var prop = OpenApiSchemaCodegen.ToPascalCase(raw);
        sb.Append("{request.").Append(prop).Append('}');
        i = end + 1;
      }
      else
      {
        sb.Append(p[i]);
        i++;
      }
    }

    sb.Append('"');
    return sb.ToString();
  }

  private static string ToHttpMethodExpression(string method)
  {
    return method.ToUpperInvariant() switch
    {
      "GET" => "HttpMethod.Get",
      "POST" => "HttpMethod.Post",
      "PUT" => "HttpMethod.Put",
      "PATCH" => "HttpMethod.Patch",
      "DELETE" => "HttpMethod.Delete",
      _ => "HttpMethod.Get"
    };
  }

  private static void AppendCopyright(StringBuilder sb)
  {
    sb.AppendLine("/*");
    sb.AppendLine(" * Copyright 2025-present Coinbase Global, Inc.");
    sb.AppendLine(" *");
    sb.AppendLine(" *  Licensed under the Apache License, Version 2.0 (the \"License\");");
    sb.AppendLine(" *  you may not use this file except in compliance with the License.");
    sb.AppendLine(" *  You may obtain a copy of the License at");
    sb.AppendLine(" *");
    sb.AppendLine(" *  http://www.apache.org/licenses/LICENSE-2.0");
    sb.AppendLine(" *");
    sb.AppendLine(" *  Unless required by applicable law or agreed to in writing, software");
    sb.AppendLine(" *  distributed under the License is distributed on an \"AS IS\" BASIS,");
    sb.AppendLine(" *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.");
    sb.AppendLine(" *  See the License for the specific language governing permissions and");
    sb.AppendLine(" *  limitations under the License.");
    sb.AppendLine(" */");
    sb.AppendLine();
  }
}
