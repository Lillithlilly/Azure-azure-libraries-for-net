// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Configuration of the protocol.
    /// </summary>
    public partial class ProtocolConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the ProtocolConfiguration class.
        /// </summary>
        public ProtocolConfiguration()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ProtocolConfiguration class.
        /// </summary>
        public ProtocolConfiguration(HTTPConfiguration hTTPConfiguration = default(HTTPConfiguration))
        {
            HTTPConfiguration = hTTPConfiguration;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "HTTPConfiguration")]
        public HTTPConfiguration HTTPConfiguration { get; set; }

    }
}
