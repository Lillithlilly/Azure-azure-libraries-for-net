// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    public enum KnownLinuxVirtualMachineImage
    {
        [EnumName("Canonical UbuntuServer 14.04.4-LTS")]
        UbuntuServer14_04_Lts,

        [EnumName("Canonical UbuntuServer 16.04.0-LTS")]
        UbuntuServer16_04_Lts,

        [EnumName("credativ Debian 8")]
        Debian8,

        [EnumName("OpenLogic CentOS 7.2")]
        CentOS7_2,

        [System.Obsolete("For virtual machine and scale set, use withLatestLinuxImage(String publisher, String offer, String sku) with publisher as 'SUSE', offer as 'openSUSE - Leap' and sku as '42.3'")]
        [EnumName("SUSE openSUSE-Leap 42.1")]
        OpenSuseLeap42_1,

        [System.Obsolete("For virtual machine and scale set, use withLatestLinuxImage(String publisher, String offer, String sku) with publisher as 'SUSE', offer as 'SLES' and sku as '12-SP3'")]
        [EnumName("SUSE SLES 12-SP1")]
        Sles12Sp1
    }
}
