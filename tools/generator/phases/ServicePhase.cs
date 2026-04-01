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

using System.Text;
using CoinbaseSdk.Tools.Generator.Processing;
using CoinbaseSdk.Tools.Generator.Spec;

namespace CoinbaseSdk.Tools.Generator.Phases;

public static class ServicePhase
{

  public static string EmitInterface(ServiceDefinition svc, List<(SdkOperationBinding B, ParsedOperation Op)> ops)
  {
    var ns = NamingResolver.FullNamespace(svc);
    var sb = new StringBuilder();
    AppendCopyright(sb);
    sb.Append($$"""
    namespace {{ns}}
    {
      using CoinbaseSdk.Core.Http;

      public interface {{svc.InterfaceName}}
      {

    """);
    foreach (var (b, _) in ops)
    {
      sb.Append(InterfaceMethodBlock(b));
    }

    sb.Append("""
      }
    }

    """);
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
    sb.Append($$"""
    namespace {{ns}}
    {
      using System.Net;
      using CoinbaseSdk.Core.Client;
      using CoinbaseSdk.Core.Http;
      using CoinbaseSdk.Core.Service;

      public class {{svc.ClassName}}(ICoinbaseClient client) : CoinbaseService(client), {{svc.InterfaceName}}
      {

    """);
    foreach (var (b, op) in ops)
    {
      var pathExpr = ToCSharpPathExpression(op.Path, b.OmitRequest);
      var method = ToHttpMethodExpression(op.HttpMethod);
      var status = StatusArray(cfg, b.SdkMethod, op);
      var bodyArg = RequestBodyArgument(b, op);
      sb.Append(ServiceMethodBlock(b, pathExpr, method, status, bodyArg));
    }

    sb.Append("""
      }
    }

    """);
    return sb.ToString();
  }

  private static string InterfaceMethodBlock(SdkOperationBinding b)
  {
    return b.OmitRequest
      ? $$"""
        public {{b.SdkMethod}}Response {{b.SdkMethod}}(
          CallOptions? options = null);

        public Task<{{b.SdkMethod}}Response> {{b.SdkMethod}}Async(
          CallOptions? options = null,
          CancellationToken cancellationToken = default);


    """
      : $$"""
        public {{b.SdkMethod}}Response {{b.SdkMethod}}(
          {{b.SdkMethod}}Request request,
          CallOptions? options = null);

        public Task<{{b.SdkMethod}}Response> {{b.SdkMethod}}Async(
          {{b.SdkMethod}}Request request,
          CallOptions? options = null,
          CancellationToken cancellationToken = default);


    """;
  }

  private static string ServiceMethodBlock(
    SdkOperationBinding b,
    string pathExpr,
    string method,
    string status,
    string bodyArg)
  {
    return b.OmitRequest
      ? $$"""
        public {{b.SdkMethod}}Response {{b.SdkMethod}}(
          CallOptions? options = null)
        {
          return Request<{{b.SdkMethod}}Response>(
            {{method}},
            {{pathExpr}},
            {{status}},
            null,
            options);
        }

        public Task<{{b.SdkMethod}}Response> {{b.SdkMethod}}Async(
          CallOptions? options = null,
          CancellationToken cancellationToken = default)
        {
          return RequestAsync<{{b.SdkMethod}}Response>(
            {{method}},
            {{pathExpr}},
            {{status}},
            null,
            options,
            cancellationToken);
        }


    """
      : $$"""
        public {{b.SdkMethod}}Response {{b.SdkMethod}}(
          {{b.SdkMethod}}Request request,
          CallOptions? options = null)
        {
          return Request<{{b.SdkMethod}}Response>(
            {{method}},
            {{pathExpr}},
            {{status}},
            {{bodyArg}},
            options);
        }

        public Task<{{b.SdkMethod}}Response> {{b.SdkMethod}}Async(
          {{b.SdkMethod}}Request request,
          CallOptions? options = null,
          CancellationToken cancellationToken = default)
        {
          return RequestAsync<{{b.SdkMethod}}Response>(
            {{method}},
            {{pathExpr}},
            {{status}},
            {{bodyArg}},
            options,
            cancellationToken);
        }


    """;
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

  private static string StatusArray(GeneratorConfiguration cfg, string sdkMethod, ParsedOperation op)
  {
    if (cfg.StatusCodeOverrides.TryGetValue(sdkMethod, out var list))
    {
      return "[" + string.Join(", ", list.Select(s => $"HttpStatusCode.{s}")) + "]";
    }

    if (op.SuccessStatusCodes.Count > 0)
    {
      return "[" + string.Join(", ", op.SuccessStatusCodes.Select(ToHttpStatusCode)) + "]";
    }

    return "[HttpStatusCode.OK]";
  }

  private static string ToHttpStatusCode(int code) => code switch
  {
    200 => "HttpStatusCode.OK",
    201 => "HttpStatusCode.Created",
    _ => $"(HttpStatusCode){code}"
  };

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
    CopyrightHelper.AppendEmittedCsFileLicense(sb, CopyrightHelper.SdkEmittedCopyrightYear);
  }
}
