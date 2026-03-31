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

namespace CoinbaseSdk.Tools.Generator.Processing;

/// <summary>
/// Emits C# XML documentation comments from OpenAPI description text.
/// </summary>
public static class XmlDocCommentEmitter
{
  /// <summary>
  /// Appends a <c>summary</c> block if <paramref name="description"/> is non-empty.
  /// </summary>
  /// <param name="sb">Target buffer.</param>
  /// <param name="description">OpenAPI description or summary text.</param>
  /// <param name="indent">Leading whitespace for each <c>///</c> line (e.g. two spaces).</param>
  public static void AppendSummary(StringBuilder sb, string? description, string indent)
  {
    if (string.IsNullOrWhiteSpace(description))
    {
      return;
    }

    var normalized = description.Replace("\r\n", "\n", StringComparison.Ordinal).Trim();
    var lines = normalized.Split('\n');
    sb.AppendLine($"{indent}/// <summary>");
    foreach (var raw in lines)
    {
      var t = EscapeForXmlDoc(raw.Trim());
      if (t.Length == 0)
      {
        continue;
      }

      sb.AppendLine($"{indent}/// {t}");
    }

    sb.AppendLine($"{indent}/// </summary>");
  }

  /// <summary>
  /// Builds operation-level documentation from summary and description (both optional).
  /// </summary>
  public static string? CombineOperationDocs(string? summary, string? description)
  {
    var s = summary?.Trim();
    var d = description?.Trim();
    if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(d))
    {
      return null;
    }

    if (string.IsNullOrEmpty(s))
    {
      return d;
    }

    if (string.IsNullOrEmpty(d) || string.Equals(s, d, StringComparison.Ordinal))
    {
      return s;
    }

    return s + "\n\n" + d;
  }

  private static string EscapeForXmlDoc(string line)
  {
    return line
      .Replace("&", "&amp;", StringComparison.Ordinal)
      .Replace("<", "&lt;", StringComparison.Ordinal)
      .Replace(">", "&gt;", StringComparison.Ordinal);
  }
}
