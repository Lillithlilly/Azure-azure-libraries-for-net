// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.TrafficManager.Fluent;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Globalization;
using System.Linq;
using Xunit;

namespace Fluent.Tests
{
    public class TrafficManager
    {
        [Fact]
        public void CanCreateUpdateTrafficManagerProfile()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var externalEndpointName21 = "external-ep-1";
                var externalEndpointName22 = "external-ep-2";
                var externalEndpointName23 = "external-ep-3";

                var externalFqdn21 = "www.azure.microsoft.com";
                var externalFqdn22 = "www.bing.com";
                var externalFqdn23 = "www.github.com";

                var azureEndpointName = "azure-ep-1";
                var nestedProfileEndpointName = "nested-profile-ep-1";

                var groupName = TestUtilities.GenerateName("rgchashtm");
                var pipName = TestUtilities.GenerateName("pip");
                var pipDnsLabel = TestUtilities.GenerateName("contoso");

                var tmProfileName = TestUtilities.GenerateName("tm");
                var nestedTmProfileName = "nested" + tmProfileName;

                var tmProfileDnsLabel = TestUtilities.GenerateName("tmdns");
                var nestedTmProfileDnsLabel = "nested" + tmProfileDnsLabel;

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    var rgCreatable = azure.ResourceGroups.Define(groupName)
                            .WithRegion(region);

                    // Creates a TM profile that will be used as a nested profile endpoint in parent TM profile
                    //
                    var nestedProfile = azure.TrafficManagerProfiles.Define(nestedTmProfileName)
                            .WithNewResourceGroup(rgCreatable)
                            .WithLeafDomainLabel(nestedTmProfileDnsLabel)
                            .WithPriorityBasedRouting()
                            .DefineExternalTargetEndpoint(externalEndpointName21)
                                .ToFqdn("www.gitbook.com")
                                .FromRegion(Region.IndiaCentral)
                                .Attach()
                            .WithHttpsMonitoring()
                            .WithFastFailover(10, 5)
                            .WithTimeToLive(500)
                            .Create();

                    Assert.True(nestedProfile.IsEnabled);
                    Assert.NotNull(nestedProfile.MonitorStatus);
                    Assert.Equal(443, nestedProfile.MonitoringPort);
                    Assert.Equal("/", nestedProfile.MonitoringPath);
                    Assert.Empty(nestedProfile.AzureEndpoints);
                    Assert.Empty(nestedProfile.NestedProfileEndpoints);
                    Assert.Single(nestedProfile.ExternalEndpoints);
                    Assert.Equal(nestedTmProfileDnsLabel + ".trafficmanager.net", nestedProfile.Fqdn);
                    Assert.Equal(500, nestedProfile.TimeToLive);
                    Assert.Equal(10, nestedProfile.IntervalInSeconds);
                    Assert.Equal(5, nestedProfile.TimeoutInSeconds);

                    nestedProfile.Update()
                        .WithFastFailover(intervalInSeconds:30, timeoutInSeconds:10, toleratedNumberOfFailures:5)
                        .Apply();
                    nestedProfile.Refresh();
                    Assert.Equal(30, nestedProfile.IntervalInSeconds);
                    Assert.Equal(10, nestedProfile.TimeoutInSeconds);
                    Assert.Equal(5, nestedProfile.ToleratedNumberOfFailures);

                    // Creates a public ip to be used as an Azure endpoint
                    //
                    var publicIpAddress = azure.PublicIPAddresses.Define(pipName)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgCreatable)
                            .WithLeafDomainLabel(pipDnsLabel)
                            .Create();

                    Assert.NotNull(publicIpAddress.Fqdn);
                    // Creates a TM profile
                    //

                    // bugfix
                    var updatedProfile = nestedProfile.Update()
                            .DefineAzureTargetEndpoint(azureEndpointName)
                                .ToResourceId(publicIpAddress.Id)
                                .WithTrafficDisabled()
                                .WithRoutingPriority(11)
                                .Attach()
                            .Apply();

                    Assert.Equal(1, updatedProfile.AzureEndpoints.Count);
                    Assert.True(updatedProfile.AzureEndpoints.ContainsKey(azureEndpointName));
                    Assert.Single(updatedProfile.ExternalEndpoints);
                    Assert.True(updatedProfile.ExternalEndpoints.ContainsKey(externalEndpointName21));

                    var updatedProfileFromGet = azure.TrafficManagerProfiles.GetById(updatedProfile.Id);
                    Assert.Equal(1, updatedProfileFromGet.AzureEndpoints.Count);
                    Assert.True(updatedProfileFromGet.AzureEndpoints.ContainsKey(azureEndpointName));
                    Assert.Single(updatedProfileFromGet.ExternalEndpoints);
                    Assert.True(updatedProfileFromGet.ExternalEndpoints.ContainsKey(externalEndpointName21));

                    nestedProfile.Update()
                        .WithoutEndpoint(azureEndpointName)
                        .Apply();

                    Assert.Equal(0, nestedProfile.AzureEndpoints.Count);
                    Assert.Single(nestedProfile.ExternalEndpoints);
                    Assert.True(nestedProfile.ExternalEndpoints.ContainsKey(externalEndpointName21));
                    updatedProfileFromGet = azure.TrafficManagerProfiles.GetById(updatedProfile.Id);
                    Assert.Equal(0, updatedProfileFromGet.AzureEndpoints.Count);
                    Assert.Equal(nestedProfile.AzureEndpoints.Count, updatedProfileFromGet.AzureEndpoints.Count);
                    Assert.Single(updatedProfileFromGet.ExternalEndpoints);
                    Assert.True(updatedProfileFromGet.ExternalEndpoints.ContainsKey(externalEndpointName21));
                    // end of bugfix

                    var profile = azure.TrafficManagerProfiles.Define(tmProfileName)
                            .WithNewResourceGroup(rgCreatable)
                            .WithLeafDomainLabel(tmProfileDnsLabel)
                            .WithWeightBasedRouting()
                            .DefineExternalTargetEndpoint(externalEndpointName21)
                                .ToFqdn(externalFqdn21)
                                .FromRegion(Region.USEast)
                                .WithRoutingPriority(1)
                                .WithRoutingWeight(1)
                                .Attach()
                            .DefineExternalTargetEndpoint(externalEndpointName22)
                                .ToFqdn(externalFqdn22)
                                .FromRegion(Region.USEast2)
                                .WithRoutingPriority(2)
                                .WithRoutingWeight(1)
                                .WithTrafficDisabled()
                                .Attach()
                            .DefineAzureTargetEndpoint(azureEndpointName)
                                .ToResourceId(publicIpAddress.Id)
                                .WithRoutingPriority(3)
                                .Attach()
                            .DefineNestedTargetEndpoint(nestedProfileEndpointName)
                                .ToProfile(nestedProfile)
                                .FromRegion(Region.IndiaCentral)
                                .WithMinimumEndpointsToEnableTraffic(1)
                                .WithRoutingPriority(4)
                            .Attach()
                            .WithHttpMonitoring()
                            .Create();

                    Assert.True(profile.IsEnabled);
                    Assert.NotNull(profile.MonitorStatus);
                    Assert.Equal(80, profile.MonitoringPort);
                    Assert.Equal("/", profile.MonitoringPath);
                    Assert.Single(profile.AzureEndpoints);
                    Assert.Single(profile.NestedProfileEndpoints);
                    Assert.Equal(2, profile.ExternalEndpoints.Count());
                    Assert.Equal(tmProfileDnsLabel + ".trafficmanager.net", profile.Fqdn);
                    Assert.Equal(300, profile.TimeToLive); // Default

                    profile = profile.Refresh();
                    Assert.Single(profile.AzureEndpoints);
                    Assert.Single(profile.NestedProfileEndpoints);
                    Assert.Equal(2, profile.ExternalEndpoints.Count());

                    int c = 0;
                    foreach (var endpoint in profile.ExternalEndpoints.Values)
                    {
                        Assert.Equal(EndpointType.External, endpoint.EndpointType);
                        if (endpoint.Name.Equals(externalEndpointName21, StringComparison.OrdinalIgnoreCase))
                        {
                            Assert.Equal(1, endpoint.RoutingPriority);
                            Assert.Equal(externalFqdn21, endpoint.Fqdn);
                            Assert.NotNull(endpoint.MonitorStatus);
                            Assert.Equal(Region.USEast, endpoint.SourceTrafficLocation);
                            c++;
                        }
                        else if (endpoint.Name.Equals(externalEndpointName22, StringComparison.OrdinalIgnoreCase))
                        {
                            Assert.Equal(2, endpoint.RoutingPriority);
                            Assert.Equal(externalFqdn22, endpoint.Fqdn);
                            Assert.NotNull(endpoint.MonitorStatus);
                            Assert.Equal(Region.USEast2, endpoint.SourceTrafficLocation);
                            c++;
                        }
                    }
                    Assert.Equal(2, c);

                    c = 0;
                    foreach (var endpoint in profile.AzureEndpoints.Values)
                    {
                        Assert.Equal(EndpointType.Azure, endpoint.EndpointType);
                        if (endpoint.Name.Equals(azureEndpointName, StringComparison.OrdinalIgnoreCase))
                        {
                            Assert.Equal(3, endpoint.RoutingPriority);
                            Assert.NotNull(endpoint.MonitorStatus);
                            Assert.Equal(publicIpAddress.Id, endpoint.TargetAzureResourceId);
                            Assert.Equal(TargetAzureResourceType.PublicIP, endpoint.TargetResourceType);
                            c++;
                        }
                    }
                    Assert.Equal(1, c);

                    c = 0;
                    foreach (var endpoint in profile.NestedProfileEndpoints.Values)
                    {
                        Assert.Equal(EndpointType.NestedProfile, endpoint.EndpointType);
                        if (endpoint.Name.Equals(nestedProfileEndpointName, StringComparison.OrdinalIgnoreCase))
                        {
                            Assert.Equal(4, endpoint.RoutingPriority);
                            Assert.NotNull(endpoint.MonitorStatus);
                            Assert.Equal(1, endpoint.MinimumChildEndpointCount);
                            Assert.Equal(nestedProfile.Id, endpoint.NestedProfileId);
                            Assert.Equal(Region.IndiaCentral, endpoint.SourceTrafficLocation);
                            c++;
                        }
                    }
                    Assert.Equal(1, c);

                    // Remove an endpoint, update two endpoints and add new one
                    //
                    profile.Update()
                            .WithTimeToLive(600)
                            .WithHttpMonitoring(8080, "/")
                            .WithPerformanceBasedRouting()
                            .WithoutEndpoint(externalEndpointName21)
                            .UpdateAzureTargetEndpoint(azureEndpointName)
                                .WithRoutingPriority(5)
                                .WithRoutingWeight(2)
                                .Parent()
                            .UpdateNestedProfileTargetEndpoint(nestedProfileEndpointName)
                                .WithTrafficDisabled()
                                .Parent()
                            .DefineExternalTargetEndpoint(externalEndpointName23)
                                .ToFqdn(externalFqdn23)
                                .FromRegion(Region.USCentral)
                                .WithRoutingPriority(6)
                                .Attach()
                            .Apply();

                    Assert.Equal(8080, profile.MonitoringPort);
                    Assert.Equal("/", profile.MonitoringPath);
                    Assert.Single(profile.AzureEndpoints);
                    Assert.Single(profile.NestedProfileEndpoints);
                    Assert.Equal(2, profile.ExternalEndpoints.Count());
                    Assert.Equal(600, profile.TimeToLive);

                    c = 0;
                    foreach (var endpoint in profile.ExternalEndpoints.Values)
                    {
                        Assert.Equal(endpoint.EndpointType, EndpointType.External);
                        if (endpoint.Name.Equals(externalEndpointName22, StringComparison.OrdinalIgnoreCase))
                        {
                            Assert.Equal(2, endpoint.RoutingPriority);
                            Assert.Equal(externalFqdn22, endpoint.Fqdn);
                            Assert.Equal(Region.USEast2, endpoint.SourceTrafficLocation);
                            Assert.NotNull(endpoint.MonitorStatus);
                            c++;
                        }
                        else if (endpoint.Name.Equals(externalEndpointName23, StringComparison.OrdinalIgnoreCase))
                        {
                            Assert.Equal(6, endpoint.RoutingPriority);
                            Assert.Equal(externalFqdn23, endpoint.Fqdn);
                            Assert.NotNull(endpoint.MonitorStatus);
                            Assert.Equal(Region.USCentral, endpoint.SourceTrafficLocation);
                            c++;
                        }
                        else
                        {
                            c++;
                        }
                    }
                    Assert.Equal(2, c);

                    c = 0;
                    foreach (var endpoint in profile.AzureEndpoints.Values)
                    {
                        Assert.Equal(endpoint.EndpointType, EndpointType.Azure);
                        if (endpoint.Name.Equals(azureEndpointName))
                        {
                            Assert.Equal(5, endpoint.RoutingPriority);
                            Assert.Equal(2, endpoint.RoutingWeight);
                            Assert.Equal(TargetAzureResourceType.PublicIP, endpoint.TargetResourceType);
                            c++;
                        }
                    }
                    Assert.Equal(1, c);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanGetGeographicHierarchy()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {

                var azure = TestHelper.CreateRollupClient();
                var root = azure.TrafficManagerProfiles.GetGeographicHierarchyRoot();
                Assert.NotNull(root);
                Assert.NotNull(root.Code);
                Assert.NotNull(root.ChildLocations);
                Assert.NotNull(root.DescendantLocations);
                Assert.False(root.ChildLocations.Count == 0);
                Assert.False(root.DescendantLocations.Count == 0);
            }
        }

        [Fact]
        public void CanCreateUpdateProfileWithGeographicEndpoint()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;

                var groupName = TestUtilities.GenerateName("rgchashtm");
                var tmProfileName = TestUtilities.GenerateName("tm");
                var tmProfileDnsLabel = TestUtilities.GenerateName("tmdns");

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    var geographicLocation = azure.TrafficManagerProfiles.GetGeographicHierarchyRoot();

                    IGeographicLocation california = geographicLocation.DescendantLocations.FirstOrDefault(l => l.Name.Equals("California", StringComparison.OrdinalIgnoreCase));
                    IGeographicLocation bangladesh = geographicLocation.DescendantLocations.FirstOrDefault(l => l.Name.Equals("Bangladesh", StringComparison.OrdinalIgnoreCase));

                    Assert.NotNull(california);
                    Assert.NotNull(bangladesh);

                    var profile = azure.TrafficManagerProfiles.Define(tmProfileName)
                        .WithNewResourceGroup(groupName, region)
                        .WithLeafDomainLabel(tmProfileDnsLabel)
                        .WithGeographicBasedRouting()
                        .DefineExternalTargetEndpoint("external-ep-1")
                            .ToFqdn("www.gitbook.com")
                            .FromRegion(Region.AsiaEast)
                            .WithGeographicLocation(california)
                            .WithGeographicLocation(bangladesh)
                            .Attach()
                        .WithHttpsMonitoring()
                        .WithTimeToLive(500)
                        .Create();

                    Assert.NotNull(profile.Inner);
                    Assert.True(profile.TrafficRoutingMethod.Equals(TrafficRoutingMethod.Geographic));
                    Assert.True(profile.ExternalEndpoints.ContainsKey("external-ep-1"));
                    var endpoint = profile.ExternalEndpoints["external-ep-1"];
                    Assert.NotNull(endpoint.GeographicLocationCodes);
                    Assert.Equal(2, endpoint.GeographicLocationCodes.Count());

                    profile.Update()
                        .UpdateExternalTargetEndpoint("external-ep-1")
                            .WithoutGeographicLocation(california)
                            .Parent()
                        .Apply();

                    Assert.True(profile.TrafficRoutingMethod.Equals(TrafficRoutingMethod.Geographic));
                    Assert.True(profile.ExternalEndpoints.ContainsKey("external-ep-1"));
                    endpoint = profile.ExternalEndpoints["external-ep-1"];
                    Assert.NotNull(endpoint.GeographicLocationCodes);
                    Assert.Single(endpoint.GeographicLocationCodes);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateSubnetRoutingProfile()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;

                var groupName = TestUtilities.GenerateName("rgchashtm");
                var tmProfileName = TestUtilities.GenerateName("tm");
                var tmProfileDnsLabel = TestUtilities.GenerateName("tmdns");

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    var profile = azure.TrafficManagerProfiles.Define(tmProfileName)
                                        .WithNewResourceGroup(groupName, region)
                                        .WithLeafDomainLabel(tmProfileDnsLabel)
                                        .WithSubnetBasedRouting()
                                        .DefineExternalTargetEndpoint("one")
                                            .ToFqdn("1.1.1.1")
                                            .FromRegion(Region.USWest2)
                                            .WithSubnetRouting("1.1.1.0", 24)
                                            .Attach()
                                        .DefineExternalTargetEndpoint("two")
                                            .ToFqdn("2.2.2.2")
                                            .FromRegion(Region.USWest2)
                                            .WithSubnetRouting("2.2.2.0", "2.2.2.255")
                                            .Attach()
                                        .DefineExternalTargetEndpoint("three")
                                            .ToFqdn("3.3.3.3")
                                            .FromRegion(Region.USWest2)
                                            .Attach()
                                        .WithHttpsMonitoring()
                                        .WithTimeToLive(500)
                                        .Create();

                    Assert.NotNull(profile.Inner);
                    Assert.True(profile.TrafficRoutingMethod.Equals(TrafficRoutingMethod.Subnet));
                    Assert.True(profile.ExternalEndpoints.ContainsKey("one"));
                    var endpoint = profile.ExternalEndpoints["one"];
                    Assert.Equal(1, endpoint.SubnetRoute.Count());
                    Assert.False(string.IsNullOrEmpty(endpoint.SubnetRoute.First()));

                    endpoint = profile.ExternalEndpoints["three"];
                    Assert.Equal(0, endpoint.SubnetRoute.Count());                    

                    profile.Update()
                        .UpdateExternalTargetEndpoint("three")
                            .WithSubnetRouting("3.3.3.0", 24)
                            .Parent()
                        .Apply();

                    endpoint = profile.ExternalEndpoints["three"];
                    Assert.Equal(1, endpoint.SubnetRoute.Count());
                    Assert.False(string.IsNullOrEmpty(endpoint.SubnetRoute.First()));
                }
                finally
                {
                    azure.ResourceGroups.BeginDeleteByName(groupName);
                }
            }
        }


        [Fact]
        public void CanCreateMultivalueRoutingProfileAndSetCustomHeaders()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;

                var groupName = TestUtilities.GenerateName("rgchashtm");
                var tmProfileName = TestUtilities.GenerateName("tm");
                var tmProfileDnsLabel = TestUtilities.GenerateName("tmdns");
                var maxReturn = 4;

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    var twoheaders = new System.Collections.Generic.Dictionary<string, string>
                    {
                        {  "twoA", "twoA.com" },
                        {  "twoB", "twoB.com" }
                    };

                    var profile = azure.TrafficManagerProfiles.Define(tmProfileName)
                                        .WithNewResourceGroup(groupName, region)
                                        .WithLeafDomainLabel(tmProfileDnsLabel)
                                        .WithMultiValueBasedRouting(maxReturn)
                                        .DefineExternalTargetEndpoint("one")
                                            .ToFqdn("1.1.1.1")
                                            .FromRegion(Region.USWest2)
                                            .WithCustomHeader("one","one.com")
                                            .Attach()
                                        .DefineExternalTargetEndpoint("two")
                                            .ToFqdn("2.2.2.2")
                                            .FromRegion(Region.USWest2)
                                            .WithCustomHeaders(twoheaders)
                                        .Attach()
                                        .WithHttpsMonitoring()
                                        .WithTimeToLive(500)
                                        .Create();

                    Assert.NotNull(profile.Inner);
                    Assert.True(profile.TrafficRoutingMethod.Equals(TrafficRoutingMethod.MultiValue));
                    Assert.Equal(maxReturn, profile.Inner.MaxReturn);
                    Assert.Equal(2, profile.ExternalEndpoints.Count());
                    Assert.True(profile.ExternalEndpoints.ContainsKey("one"));
                    var endpoint = profile.ExternalEndpoints["one"];
                    Assert.Equal(1, endpoint.CustomHeaders.Count());
                    Assert.Equal("one.com", endpoint.CustomHeaders.First().Value);
                    endpoint = profile.ExternalEndpoints["two"];
                    Assert.Equal(2, endpoint.CustomHeaders.Count());

                    profile.Update()
                            .WithMultiValueBasedRouting(maxReturn + 2)
                            .Apply();

                    Assert.True(profile.TrafficRoutingMethod.Equals(TrafficRoutingMethod.MultiValue));
                    Assert.Equal(maxReturn + 2, profile.Inner.MaxReturn);
                }
                finally
                {
                    azure.ResourceGroups.BeginDeleteByName(groupName);
                }
            }
        }

    }
}
