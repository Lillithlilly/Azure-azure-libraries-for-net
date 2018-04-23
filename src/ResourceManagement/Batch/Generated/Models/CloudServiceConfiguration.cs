// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Batch.Fluent.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The configuration for nodes in a pool based on the Azure Cloud Services
    /// platform.
    /// </summary>
    public partial class CloudServiceConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the CloudServiceConfiguration class.
        /// </summary>
        public CloudServiceConfiguration()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CloudServiceConfiguration class.
        /// </summary>
        /// <param name="osFamily">The Azure Guest OS family to be installed on
        /// the virtual machines in the pool.</param>
        /// <param name="targetOSVersion">The Azure Guest OS version to be
        /// installed on the virtual machines in the pool.</param>
        /// <param name="currentOSVersion">The Azure Guest OS Version currently
        /// installed on the virtual machines in the pool.</param>
        public CloudServiceConfiguration(string osFamily, string targetOSVersion = default(string), string currentOSVersion = default(string))
        {
            OsFamily = osFamily;
            TargetOSVersion = targetOSVersion;
            CurrentOSVersion = currentOSVersion;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the Azure Guest OS family to be installed on the
        /// virtual machines in the pool.
        /// </summary>
        /// <remarks>
        /// Possible values are: 2 - OS Family 2, equivalent to Windows Server
        /// 2008 R2 SP1. 3 - OS Family 3, equivalent to Windows Server 2012. 4
        /// - OS Family 4, equivalent to Windows Server 2012 R2. 5 - OS Family
        /// 5, equivalent to Windows Server 2016. For more information, see
        /// Azure Guest OS Releases
        /// (https://azure.microsoft.com/documentation/articles/cloud-services-guestos-update-matrix/#releases).
        /// </remarks>
        [JsonProperty(PropertyName = "osFamily")]
        public string OsFamily { get; set; }

        /// <summary>
        /// Gets or sets the Azure Guest OS version to be installed on the
        /// virtual machines in the pool.
        /// </summary>
        /// <remarks>
        /// The default value is * which specifies the latest operating system
        /// version for the specified OS family.
        /// </remarks>
        [JsonProperty(PropertyName = "targetOSVersion")]
        public string TargetOSVersion { get; set; }

        /// <summary>
        /// Gets or sets the Azure Guest OS Version currently installed on the
        /// virtual machines in the pool.
        /// </summary>
        /// <remarks>
        /// This may differ from targetOSVersion if the pool state is
        /// Upgrading. In this case some virtual machines may be on the
        /// targetOSVersion and some may be on the currentOSVersion during the
        /// upgrade process. Once all virtual machines have upgraded,
        /// currentOSVersion is updated to be the same as targetOSVersion.
        /// </remarks>
        [JsonProperty(PropertyName = "currentOSVersion")]
        public string CurrentOSVersion { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (OsFamily == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "OsFamily");
            }
        }
    }
}