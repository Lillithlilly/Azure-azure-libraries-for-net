// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.ServiceFabric.Fluent.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Describes the delta health policies for the cluster upgrade.
    /// </summary>
    public partial class ClusterUpgradeDeltaHealthPolicy
    {
        /// <summary>
        /// Initializes a new instance of the ClusterUpgradeDeltaHealthPolicy
        /// class.
        /// </summary>
        public ClusterUpgradeDeltaHealthPolicy()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ClusterUpgradeDeltaHealthPolicy
        /// class.
        /// </summary>
        /// <param name="maxPercentDeltaUnhealthyNodes">The maximum allowed
        /// percentage of nodes health degradation allowed during cluster
        /// upgrades.
        /// The delta is measured between the state of the nodes at the
        /// beginning of upgrade and the state of the nodes at the time of the
        /// health evaluation.
        /// The check is performed after every upgrade domain upgrade
        /// completion to make sure the global state of the cluster is within
        /// tolerated limits.
        /// </param>
        /// <param name="maxPercentUpgradeDomainDeltaUnhealthyNodes">The
        /// maximum allowed percentage of upgrade domain nodes health
        /// degradation allowed during cluster upgrades.
        /// The delta is measured between the state of the upgrade domain nodes
        /// at the beginning of upgrade and the state of the upgrade domain
        /// nodes at the time of the health evaluation.
        /// The check is performed after every upgrade domain upgrade
        /// completion for all completed upgrade domains to make sure the state
        /// of the upgrade domains is within tolerated limits.
        /// </param>
        /// <param name="maxPercentDeltaUnhealthyApplications">The maximum
        /// allowed percentage of applications health degradation allowed
        /// during cluster upgrades.
        /// The delta is measured between the state of the applications at the
        /// beginning of upgrade and the state of the applications at the time
        /// of the health evaluation.
        /// The check is performed after every upgrade domain upgrade
        /// completion to make sure the global state of the cluster is within
        /// tolerated limits. System services are not included in this.
        /// </param>
        /// <param name="applicationDeltaHealthPolicies">Defines the
        /// application delta health policy map used to evaluate the health of
        /// an application or one of its child entities when upgrading the
        /// cluster.</param>
        public ClusterUpgradeDeltaHealthPolicy(int maxPercentDeltaUnhealthyNodes, int maxPercentUpgradeDomainDeltaUnhealthyNodes, int maxPercentDeltaUnhealthyApplications, IDictionary<string, ApplicationDeltaHealthPolicy> applicationDeltaHealthPolicies = default(IDictionary<string, ApplicationDeltaHealthPolicy>))
        {
            MaxPercentDeltaUnhealthyNodes = maxPercentDeltaUnhealthyNodes;
            MaxPercentUpgradeDomainDeltaUnhealthyNodes = maxPercentUpgradeDomainDeltaUnhealthyNodes;
            MaxPercentDeltaUnhealthyApplications = maxPercentDeltaUnhealthyApplications;
            ApplicationDeltaHealthPolicies = applicationDeltaHealthPolicies;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the maximum allowed percentage of nodes health
        /// degradation allowed during cluster upgrades.
        /// The delta is measured between the state of the nodes at the
        /// beginning of upgrade and the state of the nodes at the time of the
        /// health evaluation.
        /// The check is performed after every upgrade domain upgrade
        /// completion to make sure the global state of the cluster is within
        /// tolerated limits.
        ///
        /// </summary>
        [JsonProperty(PropertyName = "maxPercentDeltaUnhealthyNodes")]
        public int MaxPercentDeltaUnhealthyNodes { get; set; }

        /// <summary>
        /// Gets or sets the maximum allowed percentage of upgrade domain nodes
        /// health degradation allowed during cluster upgrades.
        /// The delta is measured between the state of the upgrade domain nodes
        /// at the beginning of upgrade and the state of the upgrade domain
        /// nodes at the time of the health evaluation.
        /// The check is performed after every upgrade domain upgrade
        /// completion for all completed upgrade domains to make sure the state
        /// of the upgrade domains is within tolerated limits.
        ///
        /// </summary>
        [JsonProperty(PropertyName = "maxPercentUpgradeDomainDeltaUnhealthyNodes")]
        public int MaxPercentUpgradeDomainDeltaUnhealthyNodes { get; set; }

        /// <summary>
        /// Gets or sets the maximum allowed percentage of applications health
        /// degradation allowed during cluster upgrades.
        /// The delta is measured between the state of the applications at the
        /// beginning of upgrade and the state of the applications at the time
        /// of the health evaluation.
        /// The check is performed after every upgrade domain upgrade
        /// completion to make sure the global state of the cluster is within
        /// tolerated limits. System services are not included in this.
        ///
        /// </summary>
        [JsonProperty(PropertyName = "maxPercentDeltaUnhealthyApplications")]
        public int MaxPercentDeltaUnhealthyApplications { get; set; }

        /// <summary>
        /// Gets or sets defines the application delta health policy map used
        /// to evaluate the health of an application or one of its child
        /// entities when upgrading the cluster.
        /// </summary>
        [JsonProperty(PropertyName = "applicationDeltaHealthPolicies")]
        public IDictionary<string, ApplicationDeltaHealthPolicy> ApplicationDeltaHealthPolicies { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (MaxPercentDeltaUnhealthyNodes > 100)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "MaxPercentDeltaUnhealthyNodes", 100);
            }
            if (MaxPercentDeltaUnhealthyNodes < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "MaxPercentDeltaUnhealthyNodes", 0);
            }
            if (MaxPercentUpgradeDomainDeltaUnhealthyNodes > 100)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "MaxPercentUpgradeDomainDeltaUnhealthyNodes", 100);
            }
            if (MaxPercentUpgradeDomainDeltaUnhealthyNodes < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "MaxPercentUpgradeDomainDeltaUnhealthyNodes", 0);
            }
            if (MaxPercentDeltaUnhealthyApplications > 100)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "MaxPercentDeltaUnhealthyApplications", 100);
            }
            if (MaxPercentDeltaUnhealthyApplications < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "MaxPercentDeltaUnhealthyApplications", 0);
            }
            if (ApplicationDeltaHealthPolicies != null)
            {
                foreach (var valueElement in ApplicationDeltaHealthPolicies.Values)
                {
                    if (valueElement != null)
                    {
                        valueElement.Validate();
                    }
                }
            }
        }
    }
}
