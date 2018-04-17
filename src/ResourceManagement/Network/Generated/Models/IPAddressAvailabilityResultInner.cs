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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Response for CheckIPAddressAvailability API service call
    /// </summary>
    public partial class IPAddressAvailabilityResultInner
    {
        /// <summary>
        /// Initializes a new instance of the IPAddressAvailabilityResultInner
        /// class.
        /// </summary>
        public IPAddressAvailabilityResultInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the IPAddressAvailabilityResultInner
        /// class.
        /// </summary>
        /// <param name="available">Private IP address availability.</param>
        /// <param name="availableIPAddresses">Contains other available private
        /// IP addresses if the asked for address is taken.</param>
        public IPAddressAvailabilityResultInner(bool? available = default(bool?), IList<string> availableIPAddresses = default(IList<string>))
        {
            Available = available;
            AvailableIPAddresses = availableIPAddresses;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets private IP address availability.
        /// </summary>
        [JsonProperty(PropertyName = "available")]
        public bool? Available { get; set; }

        /// <summary>
        /// Gets or sets contains other available private IP addresses if the
        /// asked for address is taken.
        /// </summary>
        [JsonProperty(PropertyName = "availableIPAddresses")]
        public IList<string> AvailableIPAddresses { get; set; }

    }
}
