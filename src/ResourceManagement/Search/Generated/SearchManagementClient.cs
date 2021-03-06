// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Search.Fluent
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Search;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Serialization;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;

    /// <summary>
    /// Client that can be used to manage Azure Search services and API keys.
    /// </summary>
    public partial class SearchManagementClient : FluentServiceClientBase<SearchManagementClient>, ISearchManagementClient, IAzureClient
    {
        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        public JsonSerializerSettings SerializationSettings { get; private set; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        public JsonSerializerSettings DeserializationSettings { get; private set; }
        
        /// <summary>
        /// The unique identifier for a Microsoft Azure subscription. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// The API version to use for each request. The current version is 2015-08-19.
        /// </summary>
        public string ApiVersion { get; private set; }

        /// <summary>
        /// Gets or sets the preferred language for the response.
        /// </summary>
        public string AcceptLanguage { get; set; }

        /// <summary>
        /// Gets or sets the retry timeout in seconds for Long Running Operations.
        /// Default value is 30.
        /// </summary>
        public int? LongRunningOperationRetryTimeout { get; set; }

        /// <summary>
        /// When set to true a unique x-ms-client-request-id value is generated and
        /// included in each request. Default is true.
        /// </summary>
        public bool? GenerateClientRequestId { get; set; }

        /// <summary>
        /// Gets the IAdminKeysOperations.
        /// </summary>
        public virtual IAdminKeysOperations AdminKeys { get; private set; }

        /// <summary>
        /// Gets the IQueryKeysOperations.
        /// </summary>
        public virtual IQueryKeysOperations QueryKeys { get; private set; }

        /// <summary>
        /// Gets the IServicesOperations.
        /// </summary>
        public virtual IServicesOperations Services { get; private set; }

        /// <summary>
        /// Initializes a new instance of the SearchManagementClient class.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public SearchManagementClient(RestClient restClient) 
            : base(restClient)
        {
        }

        private SearchManagementClient(RestClient restClient, System.Net.Http.HttpClient httpClient) : base(restClient, httpClient)
        {
        }

        public static SearchManagementClient NewInstance(RestClient restClient)
        {
            return restClient.HttpClient == null ? new SearchManagementClient(restClient) : new SearchManagementClient(restClient, restClient.HttpClient);
        }

        /// <summary>
        /// An optional partial-method to perform custom initialization.
        /// </summary>
        partial void CustomInitialize();
        /// <summary>
        /// Initializes client properties.
        /// </summary>
        protected override void Initialize()
        {
            AdminKeys = new AdminKeysOperations(this);
            QueryKeys = new QueryKeysOperations(this);
            Services = new ServicesOperations(this);
            BaseUri = new System.Uri("https://management.azure.com");
            ApiVersion = "2015-08-19";
            AcceptLanguage = "en-US";
            LongRunningOperationRetryTimeout = 30;
            GenerateClientRequestId = true;
            SerializationSettings = new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            SerializationSettings.Converters.Add(new TransformationJsonConverter());
            DeserializationSettings = new JsonSerializerSettings
            {
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            CustomInitialize();
            DeserializationSettings.Converters.Add(new TransformationJsonConverter());
            DeserializationSettings.Converters.Add(new CloudErrorJsonConverter());
        }
    }
}
