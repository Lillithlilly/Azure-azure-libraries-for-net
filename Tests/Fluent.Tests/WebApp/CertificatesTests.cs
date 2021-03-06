// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Fluent.Tests.WebApp
{
    public class Certificates
    {
        private static readonly string GroupName = "javacsmrg319";
        private static readonly string CertificateName = "javagoodcert319";

        [Fact(Skip = "Manual only: Test requires javacsmrg319 RG to be configured manually")]
        public void CanCRDCertificate()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var keyVaultManager = TestHelper.CreateKeyVaultManager();
                var appServiceManager = TestHelper.CreateAppServiceManager();

                try
                {
                    var vault = keyVaultManager.Vaults.GetByResourceGroup(GroupName, "bananagraphwebapp319com");
                    var certificate = appServiceManager.AppServiceCertificates.Define("bananacert")
                        .WithRegion(Region.USWest)
                        .WithExistingResourceGroup(GroupName)
                        .WithExistingCertificateOrder(appServiceManager.AppServiceCertificateOrders.GetByResourceGroup(GroupName, "graphwebapp319"))
                        .Create();
                    Assert.NotNull(certificate);

                    // CREATE
                    certificate = appServiceManager.AppServiceCertificates.Define(CertificateName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(GroupName)
                        .WithPfxFile("/Users/jianghlu/Documents/code/certs/myserver.Pfx")
                        .WithPfxPassword("StrongPass!123")
                        .Create();
                    Assert.NotNull(certificate);
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

        [Fact]
        public void CanListCertificate()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var appServiceManager = TestHelper.CreateAppServiceManager();

                IEnumerable<IAppServiceCertificate> certificates = appServiceManager.AppServiceCertificates.List();
            }
        }
    }
}