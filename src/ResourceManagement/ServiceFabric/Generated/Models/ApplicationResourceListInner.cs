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
    using System.Collections.Generic;

    /// <summary>
    /// The list of application resources.
    /// </summary>
    public partial class ApplicationResourceListInner
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationResourceListInner
        /// class.
        /// </summary>
        public ApplicationResourceListInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ApplicationResourceListInner
        /// class.
        /// </summary>
        /// <param name="nextLink">URL to get the next set of application list
        /// results if there are any.</param>
        public ApplicationResourceListInner(IList<ApplicationResourceInner> value = default(IList<ApplicationResourceInner>), string nextLink = default(string))
        {
            Value = value;
            NextLink = nextLink;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<ApplicationResourceInner> Value { get; set; }

        /// <summary>
        /// Gets URL to get the next set of application list results if there
        /// are any.
        /// </summary>
        [JsonProperty(PropertyName = "nextLink")]
        public string NextLink { get; private set; }

    }
}
