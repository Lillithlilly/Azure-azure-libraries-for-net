// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Management.Network.Fluent;
    using Management.Network.Fluent.Models;
    using Management.ResourceManager.Fluent.Core;

    internal class NetworkUsageImpl : Wrapper<UsageInner>, INetworkUsage
    {
        public NetworkUsageImpl(UsageInner inner) : base(inner)
        {
        }

        public long CurrentValue
        {
            get
            {
                return Inner.CurrentValue;
            }
        }

        public long Limit
        {
            get
            {
                return Inner.Limit;
            }
        }

        public UsageName Name
        {
            get
            {
                return Inner.Name;
            }
        }

        public NetworkUsageUnit Unit
        {
            get
            {
                return NetworkUsageUnit.Parse(UsageInner.Unit);
            }
        }
    }
}
