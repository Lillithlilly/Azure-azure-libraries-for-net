// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Fluent.Tests.WebApp
{
    public class AppServicePlans
    {
        [Fact]
        public void CanCRUDAppServicePlan()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string GroupName = TestUtilities.GenerateName("javacsmrg");
                string AppServicePlanName = TestUtilities.GenerateName("java-asp-");

                var appServiceManager = TestHelper.CreateAppServiceManager();

                try
                {
                    // CREATE
                    var appServicePlan = appServiceManager.AppServicePlans
                        .Define(AppServicePlanName)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(GroupName)
                        .WithPricingTier(PricingTier.PremiumP1)
                        .WithOperatingSystem(OperatingSystem.Windows)
                        .WithPerSiteScaling(false)
                        .WithCapacity(2)
                        .Create();
                    Assert.NotNull(appServicePlan);
                    Assert.Equal(PricingTier.PremiumP1, appServicePlan.PricingTier);
                    Assert.False(appServicePlan.PerSiteScaling);
                    Assert.Equal(2, appServicePlan.Capacity);
                    Assert.Equal(0, appServicePlan.NumberOfWebApps);
                    Assert.Equal(20, appServicePlan.MaxInstances);
                    // GET
                    Assert.NotNull(appServiceManager.AppServicePlans.GetByResourceGroup(GroupName, AppServicePlanName));
                    // LIST
                    var appServicePlans = appServiceManager.AppServicePlans.ListByResourceGroup(GroupName);
                    var found = false;
                    foreach (var asp in appServicePlans)
                    {
                        if (AppServicePlanName.Equals(asp.Name))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.True(found);
                    // UPDATE
                    appServicePlan = appServicePlan.Update()
                        .WithPricingTier(PricingTier.StandardS1)
                        .WithPerSiteScaling(true)
                        .WithCapacity(3)
                        .Apply();
                    Assert.NotNull(appServicePlan);
                    Assert.Equal(PricingTier.StandardS1, appServicePlan.PricingTier);
                    Assert.True(appServicePlan.PerSiteScaling);
                    Assert.Equal(3, appServicePlan.Capacity);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }
    }
}