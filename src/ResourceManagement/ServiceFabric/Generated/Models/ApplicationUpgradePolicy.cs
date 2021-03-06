// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.ServiceFabric.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Describes the policy for a monitored application upgrade.
    /// </summary>
    public partial class ApplicationUpgradePolicy
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationUpgradePolicy class.
        /// </summary>
        public ApplicationUpgradePolicy()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ApplicationUpgradePolicy class.
        /// </summary>
        /// <param name="upgradeReplicaSetCheckTimeout">The maximum amount of
        /// time to block processing of an upgrade domain and prevent loss of
        /// availability when there are unexpected issues. When this timeout
        /// expires, processing of the upgrade domain will proceed regardless
        /// of availability loss issues. The timeout is reset at the start of
        /// each upgrade domain. Valid values are between 0 and 42949672925
        /// inclusive. (unsigned 32-bit integer).</param>
        /// <param name="forceRestart">If true, then processes are forcefully
        /// restarted during upgrade even when the code version has not changed
        /// (the upgrade only changes configuration or data).</param>
        /// <param name="rollingUpgradeMonitoringPolicy">The policy used for
        /// monitoring the application upgrade</param>
        /// <param name="applicationHealthPolicy">Defines a health policy used
        /// to evaluate the health of an application or one of its children
        /// entities.
        /// </param>
        public ApplicationUpgradePolicy(string upgradeReplicaSetCheckTimeout = default(string), bool? forceRestart = default(bool?), ArmRollingUpgradeMonitoringPolicy rollingUpgradeMonitoringPolicy = default(ArmRollingUpgradeMonitoringPolicy), ArmApplicationHealthPolicy applicationHealthPolicy = default(ArmApplicationHealthPolicy))
        {
            UpgradeReplicaSetCheckTimeout = upgradeReplicaSetCheckTimeout;
            ForceRestart = forceRestart;
            RollingUpgradeMonitoringPolicy = rollingUpgradeMonitoringPolicy;
            ApplicationHealthPolicy = applicationHealthPolicy;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the maximum amount of time to block processing of an
        /// upgrade domain and prevent loss of availability when there are
        /// unexpected issues. When this timeout expires, processing of the
        /// upgrade domain will proceed regardless of availability loss issues.
        /// The timeout is reset at the start of each upgrade domain. Valid
        /// values are between 0 and 42949672925 inclusive. (unsigned 32-bit
        /// integer).
        /// </summary>
        [JsonProperty(PropertyName = "upgradeReplicaSetCheckTimeout")]
        public string UpgradeReplicaSetCheckTimeout { get; set; }

        /// <summary>
        /// Gets or sets if true, then processes are forcefully restarted
        /// during upgrade even when the code version has not changed (the
        /// upgrade only changes configuration or data).
        /// </summary>
        [JsonProperty(PropertyName = "forceRestart")]
        public bool? ForceRestart { get; set; }

        /// <summary>
        /// Gets or sets the policy used for monitoring the application upgrade
        /// </summary>
        [JsonProperty(PropertyName = "rollingUpgradeMonitoringPolicy")]
        public ArmRollingUpgradeMonitoringPolicy RollingUpgradeMonitoringPolicy { get; set; }

        /// <summary>
        /// Gets or sets defines a health policy used to evaluate the health of
        /// an application or one of its children entities.
        ///
        /// </summary>
        [JsonProperty(PropertyName = "applicationHealthPolicy")]
        public ArmApplicationHealthPolicy ApplicationHealthPolicy { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ApplicationHealthPolicy != null)
            {
                ApplicationHealthPolicy.Validate();
            }
        }
    }
}
