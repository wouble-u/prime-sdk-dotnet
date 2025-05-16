/*
 * Copyright 2025-present Coinbase Global, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace CoinbaseSdk.Prime.Model
{
  public class PositionReference
  {
    public string? Id { get; set; }

    public PositionReferenceType? Type { get; set; }

    public PositionReference() { }

    public class PositionReferenceBuilder
    {
      private string? _id;
      private PositionReferenceType? _type;

      public PositionReferenceBuilder WithId(string id)
      {
        this._id = id;
        return this;
      }

      public PositionReferenceBuilder WithType(PositionReferenceType type)
      {
        this._type = type;
        return this;
      }

      public PositionReference Build()
      {
        return new PositionReference
        {
          Id = this._id,
          Type = this._type
        };
      }
    }
  }
}