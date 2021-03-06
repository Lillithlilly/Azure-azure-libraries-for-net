// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.TrafficManager.Fluent;
    using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateAzureEndpoint;
    using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateDefinition;
    using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateExternalEndpoint;
    using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateNestedProfileEndpoint;

    /// <summary>
    /// The stage of the traffic manager profile update allowing to specify the endpoint monitoring configuration.
    /// </summary>
    public interface IWithMonitoringConfiguration
    {
        /// <summary>
        /// Specify to use HTTP monitoring for the endpoints that checks for HTTP 200 response from the path '/'
        /// at regular intervals, using port 80.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate WithHttpMonitoring();

        /// <summary>
        /// Specify the HTTP monitoring for the endpoints that checks for HTTP 200 response from the specified
        /// path at regular intervals, using the specified port.
        /// </summary>
        /// <param name="port">The monitoring port.</param>
        /// <param name="path">The monitoring path.</param>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate WithHttpMonitoring(int port, string path);

        /// <summary>
        /// Specify to use HTTPS monitoring for the endpoints that checks for HTTPS 200 response from the path '/'
        /// at regular intervals, using port 443.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate WithHttpsMonitoring();

        /// <summary>
        /// Specify the HTTPS monitoring for the endpoints that checks for HTTPS 200 response from the specified
        /// path at regular intervals, using the specified port.
        /// </summary>
        /// <param name="port">The monitoring port.</param>
        /// <param name="path">The monitoring path.</param>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate WithHttpsMonitoring(int port, string path);
    }

    /// <summary>
    /// The stage of the traffic manager profile update allowing to specify the fast failover settings for monitoring.
    /// </summary>
    public interface IWithMonitoringFastFailover
    {
        /// <summary>
        /// Specify the fast failover settings for monitoring.
        /// </summary>
        /// <param name="intervalInSeconds">The monitor interval for endpoints in this profile. This is the interval at which Traffic Manager will check the health of each endpoint in this profile. Possible values include: 10, 30.</param>
        /// <param name="timeoutInSeconds">The monitor timeout for endpoints in this profile. This is the time that Traffic Manager allows endpoints in this profile to response to the health check. Possible values: between 5 to 10.</param>
        /// <param name="toleratedNumberOfFailures">The number of consecutive failed health check that Traffic Manager tolerates before declaring an endpoint in this profile Degraded after the next failed health check. Possible values: between 0 and 9.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate WithFastFailover(long? intervalInSeconds, long? timeoutInSeconds, long? toleratedNumberOfFailures = default(long?));
    }

    /// <summary>
    /// The stage of the traffic manager profile update allowing to specify the DNS TTL.
    /// </summary>
    public interface IWithTtl
    {
        /// <summary>
        /// Specify the DNS TTL in seconds.
        /// </summary>
        /// <param name="ttlInSeconds">DNS TTL in seconds.</param>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate WithTimeToLive(int ttlInSeconds);
    }

    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// Call  Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile>,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithTrafficRoutingMethod,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithMonitoringConfiguration,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithMonitoringFastFailover,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithEndpoint,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithTtl,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithProfileStatus,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of the traffic manager profile update allowing to specify endpoints.
    /// </summary>
    public interface IWithEndpoint
    {
        /// <summary>
        /// Begins the description of an update of an existing Azure endpoint in this profile.
        /// </summary>
        /// <param name="name">The name of the Azure endpoint.</param>
        /// <return>The stage representing updating configuration for the Azure endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateAzureEndpoint.IUpdateAzureEndpoint UpdateAzureTargetEndpoint(string name);

        /// <summary>
        /// Removes an endpoint in the profile.
        /// </summary>
        /// <param name="name">The name of the endpoint.</param>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate WithoutEndpoint(string name);

        /// <summary>
        /// Begins the definition of a nested profile endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateDefinition.INestedProfileTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate> DefineNestedTargetEndpoint(string name);

        /// <summary>
        /// Begins the definition of an external endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateDefinition.IExternalTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate> DefineExternalTargetEndpoint(string name);

        /// <summary>
        /// Begins the description of an update of an existing external endpoint in this profile.
        /// </summary>
        /// <param name="name">The name of the external endpoint.</param>
        /// <return>The stage representing updating configuration for the external endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateExternalEndpoint.IUpdateExternalEndpoint UpdateExternalTargetEndpoint(string name);

        /// <summary>
        /// Begins the definition of an Azure endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateDefinition.IAzureTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate> DefineAzureTargetEndpoint(string name);

        /// <summary>
        /// Begins the description of an update of an existing nested traffic manager profile endpoint
        /// in this profile.
        /// </summary>
        /// <param name="name">The name of the nested profile endpoint.</param>
        /// <return>The stage representing updating configuration for the nested traffic manager profile endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateNestedProfileEndpoint.IUpdateNestedProfileEndpoint UpdateNestedProfileTargetEndpoint(string name);
    }

    /// <summary>
    /// The stage of the traffic manager profile update allowing to disable or enable the profile.
    /// </summary>
    public interface IWithProfileStatus
    {
        /// <summary>
        /// Specify that the profile needs to be disabled.
        /// Disabling the profile will disables traffic to all endpoints in the profile.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate WithProfileStatusDisabled();

        /// <summary>
        /// Specify that the profile needs to be enabled.
        /// Enabling the profile will enables traffic to all endpoints in the profile.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate WithProfileStatusEnabled();
    }

    /// <summary>
    /// The stage of the traffic manager profile update allowing to specify the traffic routing method
    /// for the profile.
    /// </summary>
    public interface IWithTrafficRoutingMethod
    {
        /// <summary>
        /// Specifies that end user traffic should be distributed to the endpoints based on the weight assigned
        /// to the endpoint.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate WithWeightBasedRouting();

        /// <summary>
        /// Specifies that end user traffic should be routed to the endpoint based on its priority
        /// i.e. use the endpoint with highest priority and if it is not available fallback to next highest
        /// priority endpoint.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate WithPriorityBasedRouting();

        /// <summary>
        /// Specifies the traffic routing method for the profile.
        /// </summary>
        /// <param name="routingMethod">The traffic routing method for the profile.</param>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate WithTrafficRoutingMethod(TrafficRoutingMethod routingMethod);

        /// <summary>
        /// Specifies that end user traffic should be routed based on the closest available endpoint in terms
        /// of the lowest network latency.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate WithPerformanceBasedRouting();

        /// <summary>
        /// Specifies that end user traffic should be routed to the endpoint that is designated to serve users
        /// geographic region.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate WithGeographicBasedRouting();

        /// <summary>
        /// Specifies that end user traffic should return multiple address values
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate WithMultiValueBasedRouting();

        /// <summary>
        /// Specifies that end user traffic should return multiple address values
        /// </summary>
        /// <param name="maxReturn">max number of address to be returned</param>
        /// <returns></returns>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate WithMultiValueBasedRouting(int maxReturn);

        /// <summary>
        /// Subnet traffic-routing method to map sets of end-user IP address ranges to a specific endpoint within a Traffic Manager profile. 
        /// When a request is received, the endpoint returned will be the one mapped for that request?s source IP address
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate WithSubnetBasedRouting();
    }
}