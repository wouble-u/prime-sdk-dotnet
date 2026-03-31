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

public static class ResponsePhase
{
  public static string EmitResponse(
    ParsedOpenApiDocument doc,
    GeneratorConfiguration cfg,
    SharedTransforms transforms,
    SdkOperationBinding b,
    ParsedOperation op)
  {
    var ns = NamingResolver.FullNamespace(NamingResolver.RequireService(cfg, b.Service));
    var sb = new StringBuilder();
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
    sb.AppendLine($"namespace {ns}");
    sb.AppendLine("{");

    if (string.IsNullOrEmpty(op.SuccessResponseSchemaRef))
    {
      sb.AppendLine();
      sb.AppendLine($"  public class {b.SdkMethod}Response");
      sb.AppendLine("  {");
      sb.AppendLine($"    public {b.SdkMethod}Response() {{ }}");
      sb.AppendLine("  }");
      sb.AppendLine("}");
      return sb.ToString();
    }

    var schema = SpecParser.ResolveRef(doc.Root, op.SuccessResponseSchemaRef);
    var props = OpenApiSchemaCodegen.ListProperties(doc.Root, schema, transforms);
    var useModel = props.Any(p => p.UsesModel);
    var useEnums = props.Any(p => p.UsesEnum);
    // Pagination is in CoinbaseSdk.Prime.Common, not Model
    var useCommon = props.Any(p =>
      string.Equals(p.ClrType, "Pagination", StringComparison.Ordinal) ||
      string.Equals(p.ClrType, "Pagination?", StringComparison.Ordinal));
    var useJson = props.Count > 0;
    if (useJson)
    {
      sb.AppendLine("  using System.Text.Json.Serialization;");
    }

    if (useCommon)
    {
      sb.AppendLine("  using CoinbaseSdk.Prime.Common;");
    }

    if (useModel)
    {
      sb.AppendLine("  using CoinbaseSdk.Prime.Model;");
    }

    if (useEnums)
    {
      sb.AppendLine("  using CoinbaseSdk.Prime.Model.Enums;");
    }

    sb.AppendLine();
    var responseClassDoc = op.SuccessResponseDescription ??
                           XmlDocCommentEmitter.CombineOperationDocs(op.Summary, op.Description);
    XmlDocCommentEmitter.AppendSummary(sb, responseClassDoc, "  ");
    sb.AppendLine($"  public class {b.SdkMethod}Response");
    sb.AppendLine("  {");
    var needRespSep = false;
    foreach (var p in props)
    {
      if (needRespSep)
      {
        sb.AppendLine();
      }

      needRespSep = true;
      XmlDocCommentEmitter.AppendSummary(sb, p.Description, "    ");
      sb.AppendLine($"    [JsonPropertyName(\"{p.JsonName}\")]");
      var def = DefaultForResponseProperty(p.ClrType);
      sb.AppendLine($"    public {p.ClrType} {p.ClrName} {{ get; set; }}{def}");
    }

    sb.AppendLine();
    sb.AppendLine($"    public {b.SdkMethod}Response() {{ }}");
    sb.AppendLine("  }");
    sb.AppendLine("}");
    return sb.ToString();
  }

  private static string DefaultForResponseProperty(string clrType)
  {
    if (clrType.EndsWith("[]", StringComparison.Ordinal))
    {
      return " = [];";
    }

    return string.Empty;
  }
}
