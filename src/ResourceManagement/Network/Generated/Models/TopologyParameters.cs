// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Parameters that define the representation of topology.
    /// </summary>
    public partial class TopologyParameters
    {
        /// <summary>
        /// Initializes a new instance of the TopologyParameters class.
        /// </summary>
        public TopologyParameters()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TopologyParameters class.
        /// </summary>
        /// <param name="targetResourceGroupName">The name of the target
        /// resource group to perform topology on.</param>
        /// <param name="targetVirtualNetwork">The reference of the Virtual
        /// Network resource.</param>
        /// <param name="targetSubnet">The reference of the Subnet
        /// resource.</param>
        public TopologyParameters(string targetResourceGroupName = default(string), Management.ResourceManager.Fluent.SubResource targetVirtualNetwork = default(Management.ResourceManager.Fluent.SubResource), Management.ResourceManager.Fluent.SubResource targetSubnet = default(Management.ResourceManager.Fluent.SubResource))
        {
            TargetResourceGroupName = targetResourceGroupName;
            TargetVirtualNetwork = targetVirtualNetwork;
            TargetSubnet = targetSubnet;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the name of the target resource group to perform
        /// topology on.
        /// </summary>
        [JsonProperty(PropertyName = "targetResourceGroupName")]
        public string TargetResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the reference of the Virtual Network resource.
        /// </summary>
        [JsonProperty(PropertyName = "targetVirtualNetwork")]
        public Management.ResourceManager.Fluent.SubResource TargetVirtualNetwork { get; set; }

        /// <summary>
        /// Gets or sets the reference of the Subnet resource.
        /// </summary>
        [JsonProperty(PropertyName = "targetSubnet")]
        public Management.ResourceManager.Fluent.SubResource TargetSubnet { get; set; }

    }
}
