// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.ServiceFabric.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The application type name resource
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class ApplicationTypeResourceInner : Management.ResourceManager.Fluent.Resource
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationTypeResourceInner
        /// class.
        /// </summary>
        public ApplicationTypeResourceInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ApplicationTypeResourceInner
        /// class.
        /// </summary>
        /// <param name="provisioningState">The current deployment or
        /// provisioning state, which only appears in the response.</param>
        /// <param name="location">It will be deprecated in New API, resource
        /// location depends on the parent resource.</param>
        /// <param name="tags">Azure resource tags.</param>
        /// <param name="etag">Azure resource etag.</param>
        public ApplicationTypeResourceInner(string id = default(string), string name = default(string), string type = default(string), string provisioningState = default(string), string location = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), string etag = default(string))
            : base(id, name, type)
        {
            ProvisioningState = provisioningState;
            Location = location;
            Tags = tags;
            Etag = etag;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the current deployment or provisioning state, which only
        /// appears in the response.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Gets or sets it will be deprecated in New API, resource location
        /// depends on the parent resource.
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets azure resource tags.
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets azure resource etag.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; private set; }

    }
}
