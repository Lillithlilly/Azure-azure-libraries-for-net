// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class Compute : Samples.Tests.TestBase
    {
        public Compute(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void CreateVirtualMachinesInParallelTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                CreateVirtualMachinesInParallel.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void CreateVMsUsingCustomImageOrSpecializedVHDTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                RunSampleAsTest(this.GetType().FullName, CreateVMsUsingCustomImageOrSpecializedVHD.Program.RunSample);
            }
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void ListVirtualMachineExtensionImagesTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ListVirtualMachineExtensionImages.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void ListVirtualMachineImagesTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ListVirtualMachineImages.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void ManageAvailabilitySetTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageAvailabilitySet.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void ManageVirtualMachineWithUnmanagedDisksTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageVirtualMachineWithUnmanagedDisks.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void ManageVirtualMachineExtensionTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageVirtualMachineExtension.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void ManageVirtualMachineScaleSetWithUnmanagedDisksTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageVirtualMachineScaleSetWithUnmanagedDisks.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void ManageVirtualMachinesInParallelTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageVirtualMachinesInParallel.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void ManageVirtualMachinesInParallelWithNetworkTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageVirtualMachinesInParallelWithNetwork.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void CreateVirtualMachineUsingCustomImageFromVHDTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                RunSampleAsTest(this.GetType().FullName, CreateVirtualMachineUsingCustomImageFromVHD.Program.RunSample);
            }
        }


        [Fact]
        [Trait("Samples", "Compute")]
        public void CreateVirtualMachineUsingCustomImageFromVMTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                RunSampleAsTest(this.GetType().FullName, CreateVirtualMachineUsingCustomImageFromVM.Program.RunSample);
            }
        }


        [Fact]
        [Trait("Samples", "Compute")]
        public void CreateVirtualMachineUsingSpecializedDiskFromSnapshotTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                CreateVirtualMachineUsingSpecializedDiskFromSnapshot.Program.RunSample(rollUpClient);
            }
        }


        [Fact]
        [Trait("Samples", "Compute")]
        public void CreateVirtualMachineUsingSpecializedDiskFromVhdTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                CreateVirtualMachineUsingSpecializedDiskFromVhd.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void ManageVirtualMachineWithDiskTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageVirtualMachineWithDisk.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void ConvertVirtualMachineToManagedDisksTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ConvertVirtualMachineToManagedDisks.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void ManageVirtualMachineScaleSetTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageVirtualMachineScaleSet.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Network")]
        public void ManageVirtualMachineScaleSetTestAsync()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                (azure) => ManageVirtualMachineScaleSetAsync.Program
                            .RunSampleAsync(azure)
                            .GetAwaiter()
                            .GetResult());
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void ManageVirtualMachineTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageVirtualMachine.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void ManageVirtualMachineAsyncTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                (azure) => ManageVirtualMachineAsync.Program
                            .RunSampleAsync(azure)
                            .GetAwaiter()
                            .GetResult());
        }

        [Fact(Skip = "Service Bug: Disks or snapshot cannot be resized down [Starting from compute-2017-12-01]")]
        [Trait("Samples", "Compute")]
        public void ManageManagedDisksTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageManagedDisks.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void ManageStorageFromMSIEnabledVirtualMachineTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageStorageFromMSIEnabledVirtualMachine.Program.RunSample(rollUpClient);
            }
        }

        [Fact(Skip = "Skipping for now - looks like a service side issue")]
        [Trait("Samples", "Compute")]
        public void ManageResourceFromMSIEnabledVirtualMachineBelongsToAADGroupTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageResourceFromMSIEnabledVirtualMachineBelongsToAADGroup.Program.RunSample(rollUpClient);
            }
        }

        [Fact(Skip = "Sample requires new AzureClient (with User Assigned MSI) to be published to nuget")]
        [Trait("Samples", "Compute")]
        public void ManageUserAssignedMSIEnabledVirtualMachineTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageUserAssignedMSIEnabledVirtualMachine.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void ManageZonalVirtualMachineTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageZonalVirtualMachine.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void ManageZonalVirtualMachineScaleSetTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageZonalVirtualMachineScaleSet.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Compute")]
        public void ListComputeSkusTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ListComputeSkus.Program.RunSample(rollUpClient);
            }
        }
    }
}
