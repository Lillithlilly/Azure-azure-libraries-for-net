// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Text;
using Xunit;

namespace Fluent.Tests.Network
{
    public class PublicIPAddress
    {

        [Fact]
        public void CreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var testId = TestUtilities.GenerateName("");
                var newPipName = "pip" + testId;
                var newRG = "rg" + testId;
                var manager = TestHelper.CreateNetworkManager();

                try
                { 
                    var pip = manager.PublicIPAddresses.Define(newPipName)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(newRG)
                        .WithDynamicIP()
                        .WithLeafDomainLabel(newPipName)
                        .WithIdleTimeoutInMinutes(10)
                        .Create();

                    var resource = manager.PublicIPAddresses.GetByResourceGroup(newRG, newPipName);
                    var updatedDnsName = resource.LeafDomainLabel + "xx";
                    var updatedIdleTimeout = 15;
                    resource = resource.Update()
                            .WithStaticIP()
                            .WithLeafDomainLabel(updatedDnsName)
                            .WithReverseFqdn(resource.LeafDomainLabel + "." + resource.RegionName + ".cloudapp.azure.com")
                            .WithIdleTimeoutInMinutes(updatedIdleTimeout)
                            .WithTag("tag1", "value1")
                            .WithTag("tag2", "value2")
                            .Apply();
                    Assert.Equal(resource.LeafDomainLabel, updatedDnsName, ignoreCase: true);
                    Assert.True(resource.IdleTimeoutInMinutes == updatedIdleTimeout);

                    manager.PublicIPAddresses.DeleteById(pip.Id);
                    manager.ResourceManager.ResourceGroups.DeleteByName(newRG);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(newRG);
                    }
                    catch { }
                }
            }
        }
        
        internal void Print(IPublicIPAddress resource)
        {
            TestHelper.WriteLine(new StringBuilder().Append("Public IP Address: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tTags: ").Append(resource.Tags)
                    .Append("\n\tIP Address: ").Append(resource.IPAddress)
                    .Append("\n\tLeaf domain label: ").Append(resource.LeafDomainLabel)
                    .Append("\n\tFQDN: ").Append(resource.Fqdn)
                    .Append("\n\tReverse FQDN: ").Append(resource.ReverseFqdn)
                    .Append("\n\tIdle timeout (minutes): ").Append(resource.IdleTimeoutInMinutes)
                    .Append("\n\tIP allocation method: ").Append(resource.IPAllocationMethod.ToString())
                    .ToString());
        }
    }
}
