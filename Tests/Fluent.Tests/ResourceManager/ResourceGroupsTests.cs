// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Fluent.Tests.ResourceManager
{
    public class ResourceGroups
    {
        [Fact]
        public void CanCRUDResourceGroup()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgchash-");
                Action<IResourceGroup> checkResourceGroup = (IResourceGroup resourceGroup) =>
                {
                    Assert.NotNull(resourceGroup.Name);
                    Assert.Equal(resourceGroup.Name, rgName, ignoreCase: true);
                    Assert.NotNull(resourceGroup.RegionName);
                    Assert.True(StringComparer.CurrentCultureIgnoreCase.Equals(resourceGroup.RegionName, Region.USEast2.Name));
                    Assert.NotNull(resourceGroup.Id);
                    Assert.NotNull(resourceGroup.Tags);
                    Assert.Equal(3, resourceGroup.Tags.Count);
                };

                try
                {
                    var resourceManager = TestHelper.CreateResourceManager();
                    var resourceGroup = resourceManager.ResourceGroups.Define(rgName)
                        .WithRegion(Region.USEast2)
                        .WithTag("t1", "v1")
                        .WithTag("t2", "v2")
                        .WithTag("t3", "v3")
                        .Create();
                    checkResourceGroup(resourceGroup);

                    // Check existence  
                    Assert.True(resourceManager.ResourceGroups.Contain(rgName));

                    resourceGroup = resourceManager.ResourceGroups.GetByName(rgName);
                    checkResourceGroup(resourceGroup);

                    // check tag list 
                    var resourceGroups = resourceManager.ResourceGroups.ListByTag("t3", "v3").ToList();

                    Assert.Single(resourceGroups);
                    checkResourceGroup(resourceGroups.ElementAt(0));

                    // check tag list with single quotes also works
                    resourceGroups = resourceManager.ResourceGroups.ListByTag("'t2'", "'v2'").ToList();

                    Assert.Single(resourceGroups);
                    checkResourceGroup(resourceGroups.ElementAt(0));

                    resourceGroup.Update()
                        .WithoutTag("t1")
                        .WithTag("t4", "v4")
                        .WithTag("t5", "v5")
                        .Apply();
                    Assert.NotNull(resourceGroup.Tags);
                    Assert.Equal(4, resourceGroup.Tags.Count);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch
                    { }
                }
            }
        }
    }
}
