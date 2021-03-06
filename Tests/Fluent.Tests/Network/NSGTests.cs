// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System.Text;
using Xunit;
using Fluent.Tests.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Rest;
using Xunit.Abstractions;

namespace Fluent.Tests.Network
{
    public class NSG
    {
        [Fact]
        public void CreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string testId = SdkContext.RandomResourceName("", 9);
                string resourceGroupName = "rg" + testId;
                string nsgName = "nsg" + testId;
                string nicName = "nic" + testId;
                Region region = Region.USSouthCentral;

                try
                {
                    var manager = TestHelper.CreateNetworkManager();
                    var nsg = manager.NetworkSecurityGroups.Define(nsgName)
                        .WithRegion(region)
                        .WithNewResourceGroup(resourceGroupName)
                        .DefineRule("rule1")
                            .AllowOutbound()
                            .FromAnyAddress()
                            .FromPort(80)
                            .ToAnyAddress()
                            .ToPort(80)
                            .WithProtocol(SecurityRuleProtocol.Tcp)
                            .Attach()
                        .DefineRule("rule2")
                            .AllowInbound()
                            .FromAnyAddress()
                            .FromAnyPort()
                            .ToAnyAddress()
                            .ToPortRange(22, 25)
                            .WithAnyProtocol()
                            .WithPriority(200)
                            .WithDescription("foo!!")
                            .Attach()
                        .Create();

                    var nic = manager.NetworkInterfaces.Define(nicName)
                            .WithRegion(nsg.Region)
                            .WithExistingResourceGroup(nsg.ResourceGroupName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithExistingNetworkSecurityGroup(nsg)
                            .Create();

                    nsg.Refresh();

                    // Verify
                    Assert.True(nsg.Region.Equals(region));
                    Assert.True(nsg.SecurityRules.Count == 2);

                    // Confirm NIC association
                    Assert.Equal(1, nsg.NetworkInterfaceIds.Count);
                    Assert.True(nsg.NetworkInterfaceIds.Contains(nic.Id.ToLower()));

                    var resource = manager.NetworkSecurityGroups.GetByResourceGroup(resourceGroupName, nsgName);

                    resource = resource.Update()
                        .WithoutRule("rule1")
                        .WithTag("tag1", "value1")
                        .WithTag("tag2", "value2")
                        .DefineRule("rule3")
                            .AllowInbound()
                            .FromAnyAddress()
                            .FromAnyPort()
                            .ToAnyAddress()
                            .ToAnyPort()
                            .WithProtocol(SecurityRuleProtocol.Udp)
                            .Attach()
                        .WithoutRule("rule1")
                        .UpdateRule("rule2")
                            .DenyInbound()
                            .FromAddresses("100.0.0.0/29", "100.1.0.0/29")
                            .FromPortRanges("88-90")
                            .WithPriority(300)
                            .WithDescription("bar!!!")
                            .Parent()
                        .Apply();
                    Assert.True(resource.Tags.ContainsKey("tag1"));
                    INetworkSecurityRule rule2;
                    Assert.True(resource.SecurityRules.TryGetValue("rule2", out rule2));
                    Assert.Equal(0, rule2.SourceApplicationSecurityGroupIds.Count);
                    Assert.Null(rule2.SourceAddressPrefix);
                    Assert.Equal(2, rule2.SourceAddressPrefixes.Count);
                    Assert.Contains("100.1.0.0/29", rule2.SourceAddressPrefixes);
                    Assert.Equal(1, rule2.SourcePortRanges.Count);
                    Assert.Equal("88-90", rule2.SourcePortRanges.ElementAt(0));

                    manager.NetworkSecurityGroups.DeleteById(resource.Id);
                    manager.ResourceManager.ResourceGroups.DeleteByName(resource.ResourceGroupName);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(resourceGroupName);
                    }
                    catch { }
                }
            }
        }

        internal void Print(INetworkSecurityGroup resource)
        {
            var info = new StringBuilder();
            info.Append("NSG: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tTags: ").Append(resource.Tags);

            // Output security rules
            foreach (INetworkSecurityRule rule in resource.SecurityRules.Values)
            {
                info.Append("\n\tRule: ").Append(rule.Name)
                    .Append("\n\t\tAccess: ").Append(rule.Access)
                    .Append("\n\t\tDirection: ").Append(rule.Direction)
                    .Append("\n\t\tFrom address: ").Append(rule.SourceAddressPrefix)
                    .Append("\n\t\tFrom port range: ").Append(rule.SourcePortRange)
                    .Append("\n\t\tTo address: ").Append(rule.DestinationAddressPrefix)
                    .Append("\n\t\tTo port: ").Append(rule.DestinationPortRange)
                    .Append("\n\t\tProtocol: ").Append(rule.Protocol)
                    .Append("\n\t\tPriority: ").Append(rule.Priority)
                    .Append("\n\t\tDescription: ").Append(rule.Description);
            }

            info.Append("\n\tNICs: ").Append(resource.NetworkInterfaceIds);
            TestHelper.WriteLine(info.ToString());
        }
    }
}
