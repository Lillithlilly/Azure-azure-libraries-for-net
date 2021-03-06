// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class ResourceManager : Samples.Tests.TestBase
    {
        public ResourceManager(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait("Samples", "ResourceManager")]
        public void DeployUsingARMTemplateTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                DeployUsingARMTemplate.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "ResourceManager")]
        public void DeployUsingARMTemplateWithProgressTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                DeployUsingARMTemplateWithProgress.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "ResourceManager")]
        public void ManageResourceTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageResource.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "ResourceManager")]
        public void ManageResourceGroupTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageResourceGroup.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "ResourceManager")]
        public void DeployVirtualMachineUsingARMTemplateTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                DeployVirtualMachineUsingARMTemplate.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "ResourceManager")]
        public void ManagePolicyDefinitionTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManagePolicyDefinition.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "ResourceManager")]
        public void ManagePolicyAssignmentTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManagePolicyAssignment.Program.RunSample);
        }
    }
}
