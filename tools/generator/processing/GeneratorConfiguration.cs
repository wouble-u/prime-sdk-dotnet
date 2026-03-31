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

using System.Text.Json;
using System.Text.Json.Serialization;
using CoinbaseSdk.Tools.Generator;

namespace CoinbaseSdk.Tools.Generator.Processing;

public class GeneratorConfiguration
{
  [JsonPropertyName("specUrl")]
  public string SpecUrl { get; set; } = "https://api.prime.coinbase.com/v1/openapi.yaml";

  [JsonPropertyName("filePathReplacements")]
  public Dictionary<string, string> FilePathReplacements { get; set; } = new();

  [JsonPropertyName("contentReplacements")]
  public Dictionary<string, string> ContentReplacements { get; set; } = new();

  [JsonPropertyName("acronymMappings")]
  public List<AcronymMappingEntry> AcronymMappings { get; set; } = new();

  [JsonPropertyName("enumNameMappings")]
  public Dictionary<string, string> EnumNameMappings { get; set; } = new();

  [JsonPropertyName("tagToFolder")]
  public Dictionary<string, string> TagToFolder { get; set; } = new();

  [JsonPropertyName("services")]
  public Dictionary<string, ServiceDefinition> Services { get; set; } = new();

  [JsonPropertyName("statusCodeOverrides")]
  public Dictionary<string, List<string>> StatusCodeOverrides { get; set; } = new();

  public static GeneratorConfiguration Load(string projectRoot)
  {
    var path = Path.Combine(GeneratorPaths.ConfigDirectory(projectRoot), "generator-config.json");
    var json = File.ReadAllText(path);
    var cfg = JsonSerializer.Deserialize<GeneratorConfiguration>(json, JsonOptions())
               ?? throw new InvalidOperationException("Failed to deserialize generator-config.json");
    return cfg;
  }

  public static List<SdkOperationBinding> LoadOperations(string projectRoot)
  {
    var path = Path.Combine(GeneratorPaths.ConfigDirectory(projectRoot), "operations.json");
    var json = File.ReadAllText(path);
    var list = JsonSerializer.Deserialize<List<SdkOperationBinding>>(json, JsonOptions())
               ?? throw new InvalidOperationException("Failed to deserialize operations.json");
    return list;
  }

  private static JsonSerializerOptions JsonOptions()
  {
    return new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true,
      ReadCommentHandling = JsonCommentHandling.Skip,
      AllowTrailingCommas = true
    };
  }
}

public class AcronymMappingEntry
{
  [JsonPropertyName("acronym")]
  public string Acronym { get; set; } = "";

  [JsonPropertyName("normalized")]
  public string Normalized { get; set; } = "";
}

public class ServiceDefinition
{
  [JsonPropertyName("folder")]
  public string Folder { get; set; } = "";

  [JsonPropertyName("namespace")]
  public string Namespace { get; set; } = "";

  [JsonPropertyName("interfaceName")]
  public string InterfaceName { get; set; } = "";

  [JsonPropertyName("className")]
  public string ClassName { get; set; } = "";
}

public class SdkOperationBinding
{
  [JsonPropertyName("operationId")]
  public string OperationId { get; set; } = "";

  [JsonPropertyName("sdkMethod")]
  public string SdkMethod { get; set; } = "";

  [JsonPropertyName("service")]
  public string Service { get; set; } = "";

  [JsonPropertyName("omitRequest")]
  public bool OmitRequest { get; set; }

  /// <summary>
  /// OpenAPI parameter name → CLR type override (e.g. inline string-enums mapped to SDK enum types).
  /// </summary>
  [JsonPropertyName("paramTypeOverrides")]
  public Dictionary<string, string> ParamTypeOverrides { get; set; } = new();

  /// <summary>
  /// When true, the request extends <c>PaginatedRequest</c> even if the OpenAPI operation omits pagination query parameters.
  /// </summary>
  [JsonPropertyName("forcePaginated")]
  public bool ForcePaginated { get; set; }
}
