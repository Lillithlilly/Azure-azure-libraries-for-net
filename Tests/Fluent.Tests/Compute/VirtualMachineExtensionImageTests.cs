// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;

namespace Fluent.Tests.Compute.VirtualMachine
{
    public class ExtensionImage
    {
        [Fact]
        public void CanListExtensionImages()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();
                int maxListing = 20;
                var extensionImages = azure.VirtualMachineExtensionImages
                                .ListByRegion(Region.USEast);
                // Lazy listing
                var firstTwenty = extensionImages.Take(maxListing).ToList();
                Assert.Equal(firstTwenty.Count(), maxListing);
                Assert.DoesNotContain(null, firstTwenty);
                // Make sure all the elements are unique and we did not return any duplicates
                Assert.Equal(firstTwenty.Distinct().Count(), maxListing);
            }
        }


        [Fact]
        public void CanGetExtensionTypeVersionAndImage()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();
                var extensionImages =
                        azure.VirtualMachineExtensionImages
                                .ListByRegion(Region.USEast);

                string dockerExtensionPublisherName = "Microsoft.Azure.Extensions";
                string dockerExtensionImageTypeName = "DockerExtension";

                // Lookup Azure docker extension publisher
                //
                var publishers =
                        azure.VirtualMachineExtensionImages
                                .Publishers
                                .ListByRegion(Region.USEast);

                IVirtualMachinePublisher azureDockerExtensionPublisher = publishers
                    .Where(publisher => publisher.Name.Equals(dockerExtensionPublisherName, StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault();
                Assert.NotNull(azureDockerExtensionPublisher);

                // Lookup Azure docker extension type
                //
                var extensionImageTypes = azureDockerExtensionPublisher.ExtensionTypes;
                Assert.True(extensionImageTypes.List().Count() > 0);
                var dockerExtensionImageType = extensionImageTypes
                    .List()
                    .Where(imageType => imageType.Name.Equals(dockerExtensionImageTypeName, StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault();
                Assert.NotNull(dockerExtensionImageType);

                Assert.NotNull(dockerExtensionImageType.Id);
                Assert.Equal(dockerExtensionImageType.Name, dockerExtensionImageTypeName, ignoreCase: true);
                Assert.Equal("eastus", dockerExtensionImageType.RegionName, ignoreCase: true);
                Assert.EndsWith("/Providers/Microsoft.Compute/Locations/eastus/Publishers/Microsoft.Azure.Extensions/ArtifactTypes/VMExtension/Types/DockerExtension".ToLower(), dockerExtensionImageType.Id
                        .ToLower()
);
                Assert.NotNull(dockerExtensionImageType.Publisher);
                Assert.Equal(dockerExtensionImageType.Publisher.Name, dockerExtensionPublisherName, ignoreCase: true);

                // Fetch Azure docker extension versions
                //
                var extensionImageVersions = dockerExtensionImageType.Versions;
                Assert.True(extensionImageVersions.List().Count() > 0);

                IVirtualMachineExtensionImageVersion extensionImageFirstVersion = extensionImageVersions.List().FirstOrDefault();
                Assert.NotNull(extensionImageFirstVersion);
                String versionName = extensionImageFirstVersion.Name;
                Assert.EndsWith(("/Providers/Microsoft.Compute/Locations/eastus/Publishers/Microsoft.Azure.Extensions/ArtifactTypes/VMExtension/Types/DockerExtension/Versions/" + versionName).ToLower(), extensionImageFirstVersion.Id
                        .ToLower()
);
                Assert.NotNull(extensionImageFirstVersion.Type);

                // Fetch the Azure docker extension image
                //
                var dockerExtensionImage = extensionImageFirstVersion.GetImage();

                Assert.Equal("eastus", dockerExtensionImage.RegionName, ignoreCase: true);
                Assert.Equal(dockerExtensionImage.PublisherName, dockerExtensionPublisherName, ignoreCase: true);
                Assert.Equal(dockerExtensionImage.TypeName, dockerExtensionImageTypeName, ignoreCase: true);
                Assert.Equal(dockerExtensionImage.VersionName, versionName, ignoreCase: true);
                Assert.True(dockerExtensionImage.OSType == OperatingSystemTypes.Linux || dockerExtensionImage.OSType == OperatingSystemTypes.Windows);
            }
        }
    }
}
