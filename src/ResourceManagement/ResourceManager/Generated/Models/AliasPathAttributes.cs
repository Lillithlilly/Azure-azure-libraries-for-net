// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Models
{
    using Management.ResourceManager;
    using Management.ResourceManager.Fluent;
    using Management.ResourceManager.Fluent.Core;

    using Newtonsoft.Json;
    /// <summary>
    /// Defines values for AliasPathAttributes.
    /// </summary>
    /// <summary>
    /// Determine base value for a given allowed value if exists, else return
    /// the value itself
    /// </summary>
    [JsonConverter(typeof(Fluent.Core.ExpandableStringEnumConverter<AliasPathAttributes>))]
    public class AliasPathAttributes : Fluent.Core.ExpandableStringEnum<AliasPathAttributes>
    {
        public static readonly AliasPathAttributes None = Parse("None");
        public static readonly AliasPathAttributes Modifiable = Parse("Modifiable");
    }
}
