// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fluent.Tests.ResourceManager
{
    public class GenericResources
    {
        [Fact]
        public async Task CanCreateUpdateMoveResource()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var resourceName = TestUtilities.GenerateName("rgweb");
                var rgName = TestUtilities.GenerateName("csmrg");
                var newRgName = TestUtilities.GenerateName("csmrg");

                try
                {
                    IResourceManager resourceManager = TestHelper.CreateResourceManager();
                    IGenericResources genericResources = resourceManager.GenericResources;

                    IGenericResource resource = genericResources.Define(resourceName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithResourceType("sites")
                        .WithProviderNamespace("Microsoft.Web")
                        .WithoutPlan()
                        .WithApiVersion("2015-08-01")
                        .WithProperties(JsonConvert.DeserializeObject("{\"SiteMode\":\"Limited\",\"ComputeMode\":\"Shared\"}"))
                        .Create();

                    // List
                    var found = (from r in await genericResources.ListByResourceGroupAsync(rgName)
                                 where string.Equals(r.Name, resourceName, StringComparison.OrdinalIgnoreCase)
                                 select r).FirstOrDefault();
                    Assert.NotNull(found);

                    // Get
                    resource = genericResources.Get(rgName,
                        resource.ResourceProviderNamespace,
                        resource.ParentResourceId,
                        resource.ResourceType,
                        resource.Name,
                        resource.ApiVersion);

                    // Move
                    IResourceGroup newGroup = resourceManager
                        .ResourceGroups
                        .Define(newRgName)
                        .WithRegion(Region.USEast)
                        .Create();
                    genericResources.MoveResources(rgName, newGroup, new List<string>
                    {
                        resource.Id
                    });

                    // Check existence [TODO: Server returned "MethodNotAllowed" for CheckExistence call]
                    /*bool exists = genericResources.CheckExistence(newRgName,
                        resource.ResourceProviderNamespace,
                        resource.ParentResourceId,
                        resource.ResourceType,
                        resource.Name,
                        resource.ApiVersion);

                    Assert.True(exists);
                    */

                    // Get and update
                    resource = genericResources.Get(newRgName,
                        resource.ResourceProviderNamespace,
                        resource.ParentResourceId,
                        resource.ResourceType,
                        resource.Name,
                        resource.ApiVersion);
                    resource.Update()
                        .WithApiVersion("2015-08-01")
                        .WithProperties(JsonConvert.DeserializeObject("{\"SiteMode\":\"Limited\",\"ComputeMode\":\"Dynamic\"}"))
                        .Apply();

                    Assert.Equal(newRgName, resource.ResourceGroupName);

                    resourceManager.ResourceGroups.BeginDeleteByName(newRgName);
                    resourceManager.ResourceGroups.BeginDeleteByName(rgName);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(newRgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public async Task CanCRUDWithProviderApiVersion()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var resourceName = TestUtilities.GenerateName("rgweb");
                var rgName = TestUtilities.GenerateName("csmrg");
                var newRgName = TestUtilities.GenerateName("csmrg");

                try
                {
                    IResourceManager resourceManager = TestHelper.CreateResourceManager();
                    IGenericResources genericResources = resourceManager.GenericResources;

                    IGenericResource resource = genericResources.Define(resourceName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithResourceType("sites")
                        .WithProviderNamespace("Microsoft.Web")
                        .WithoutPlan()
                        .WithApiVersion()
                        .WithProperties(JsonConvert.DeserializeObject("{\"SiteMode\":\"Limited\",\"ComputeMode\":\"Shared\"}"))
                        .Create();

                    // List
                    var found = (from r in await genericResources.ListByResourceGroupAsync(rgName)
                                 where string.Equals(r.Name, resourceName, StringComparison.OrdinalIgnoreCase)
                                 select r).FirstOrDefault();
                    Assert.NotNull(found);
                    Assert.NotNull(found.ApiVersion);

                    // Get
                    resource = genericResources.Get(rgName,
                        resource.ResourceProviderNamespace,
                        resource.ParentResourceId,
                        resource.ResourceType,
                        resource.Name);
                    Assert.NotNull(resource.ApiVersion);

                    // Move
                    IResourceGroup newGroup = resourceManager
                        .ResourceGroups
                        .Define(newRgName)
                        .WithRegion(Region.USEast)
                        .Create();
                    genericResources.MoveResources(rgName, newGroup, new List<string>
                    {
                        resource.Id
                    });
                    // Get and update
                    resource = genericResources.Get(newRgName,
                        resource.ResourceProviderNamespace,
                        resource.ParentResourceId,
                        resource.ResourceType,
                        resource.Name);
                    resource.Update()
                        .WithApiVersion("2015-08-01")
                        .WithProperties(JsonConvert.DeserializeObject("{\"SiteMode\":\"Limited\",\"ComputeMode\":\"Dynamic\"}"))
                        .Apply();

                    var target = genericResources.GetById(resource.Id);
                    Assert.Equal(newRgName, target.ResourceGroupName);

                    resourceManager.ResourceGroups.BeginDeleteByName(newRgName);
                    resourceManager.ResourceGroups.BeginDeleteByName(rgName);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(newRgName);
                    }
                    catch { }
                }
            }
        }
    }
}

