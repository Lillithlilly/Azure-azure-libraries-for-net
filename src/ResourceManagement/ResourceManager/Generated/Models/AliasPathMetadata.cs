// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class AliasPathMetadata
    {
        /// <summary>
        /// Initializes a new instance of the AliasPathMetadata class.
        /// </summary>
        public AliasPathMetadata()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AliasPathMetadata class.
        /// </summary>
        /// <param name="type">The type of the token that the alias path is
        /// referring to. Possible values include: 'NotSpecified', 'Any',
        /// 'String', 'Object', 'Array', 'Integer', 'Number', 'Boolean'</param>
        /// <param name="attributes">The attributes of the token that the alias
        /// path is referring to. Possible values include: 'None',
        /// 'Modifiable'</param>
        public AliasPathMetadata(AliasPathTokenType type = default(AliasPathTokenType), AliasPathAttributes attributes = default(AliasPathAttributes))
        {
            Type = type;
            Attributes = attributes;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the type of the token that the alias path is referring to.
        /// Possible values include: 'NotSpecified', 'Any', 'String', 'Object',
        /// 'Array', 'Integer', 'Number', 'Boolean'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public AliasPathTokenType Type { get; private set; }

        /// <summary>
        /// Gets the attributes of the token that the alias path is referring
        /// to. Possible values include: 'None', 'Modifiable'
        /// </summary>
        [JsonProperty(PropertyName = "attributes")]
        public AliasPathAttributes Attributes { get; private set; }

    }
}