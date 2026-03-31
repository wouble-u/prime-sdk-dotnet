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

using System.Text.RegularExpressions;

namespace CoinbaseSdk.Tools.Generator.Processing;

/// <summary>
/// Normalizes copyright year in generated file content: preserves the year from an existing
/// on-disk file, or uses the current calendar year for brand-new files.
/// </summary>
public static class CopyrightHelper
{
  /// <summary>
  /// Replaces the hardcoded copyright year in <paramref name="content"/> with:
  /// - The existing year from the on-disk file at <paramref name="outputPath"/> (if it exists), or
  /// - The current calendar year (for brand-new files).
  /// </summary>
  public static string ApplyCopyrightYear(string outputPath, string content)
  {
    string targetYear;
    if (File.Exists(outputPath))
    {
      var onDisk = File.ReadAllText(outputPath);
      var yearMatch = Regex.Match(onDisk, @"Copyright (\d{4})-present");
      targetYear = yearMatch.Success ? yearMatch.Groups[1].Value : DateTime.Now.Year.ToString();
    }
    else
    {
      targetYear = DateTime.Now.Year.ToString();
    }

    return Regex.Replace(
      content,
      @"Copyright \d{4}-present",
      $"Copyright {targetYear}-present");
  }
}
