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
    /// Specification of the service.
    /// </summary>
    public partial class OperationPropertiesFormatServiceSpecification
    {
        /// <summary>
        /// Initializes a new instance of the
        /// OperationPropertiesFormatServiceSpecification class.
        /// </summary>
        public OperationPropertiesFormatServiceSpecification()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// OperationPropertiesFormatServiceSpecification class.
        /// </summary>
        /// <param name="metricSpecifications">Operation service
        /// specification.</param>
        /// <param name="logSpecifications">Operation log
        /// specification.</param>
        public OperationPropertiesFormatServiceSpecification(IList<MetricSpecification> metricSpecifications = default(IList<MetricSpecification>), IList<LogSpecification> logSpecifications = default(IList<LogSpecification>))
        {
            MetricSpecifications = metricSpecifications;
            LogSpecifications = logSpecifications;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets operation service specification.
        /// </summary>
        [JsonProperty(PropertyName = "metricSpecifications")]
        public IList<MetricSpecification> MetricSpecifications { get; set; }

        /// <summary>
        /// Gets or sets operation log specification.
        /// </summary>
        [JsonProperty(PropertyName = "logSpecifications")]
        public IList<LogSpecification> LogSpecifications { get; set; }

    }
}
