// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class PrivateDns : Samples.Tests.TestBase
    {
        public PrivateDns(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait("Sample", "PrivateDns")]
        public void ManagePrivateDnsTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManagePrivateDns.Program.RunSample(rollUpClient);
            }
        }
    }
}
