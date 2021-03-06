namespace Microsoft.Azure.Management.ServiceFabric.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-cluster-capacity
    /// Durability 
    ///  Gold dedicated machines for example L32s, GS5, G5, DS15_v2, D15_v2
    ///  Silver single core and 50 GB of local SSD
    ///  Bronze 50 GB of local SSD
    /// </summary>
    public class ServiceFabricVirtualMachineSizeTypes : ExpandableStringEnum<ServiceFabricVirtualMachineSizeTypes>
    {
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardA1 = Parse("Standard_A1");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardA10 = Parse("Standard_A10");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardA11 = Parse("Standard_A11");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardA1V2 = Parse("Standard_A1_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardA2 = Parse("Standard_A2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardA2V2 = Parse("Standard_A2_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardA2mV2 = Parse("Standard_A2m_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardA3 = Parse("Standard_A3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardA4 = Parse("Standard_A4");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardA4V2 = Parse("Standard_A4_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardA4mV2 = Parse("Standard_A4m_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardA5 = Parse("Standard_A5");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardA6 = Parse("Standard_A6");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardA7 = Parse("Standard_A7");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardA8 = Parse("Standard_A8");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardA8V2 = Parse("Standard_A8_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardA8mV2 = Parse("Standard_A8m_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardA9 = Parse("Standard_A9");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardB2ms = Parse("Standard_B2ms");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardB2s = Parse("Standard_B2s");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardB4ms = Parse("Standard_B4ms");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardB8ms = Parse("Standard_B8ms");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD1 = Parse("Standard_D1");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD11 = Parse("Standard_D11");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD11V2 = Parse("Standard_D11_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD11V2Promo = Parse("Standard_D11_v2_Promo");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD12 = Parse("Standard_D12");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD12V2 = Parse("Standard_D12_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD12V2Promo = Parse("Standard_D12_v2_Promo");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD13 = Parse("Standard_D13");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD13V2 = Parse("Standard_D13_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD13V2Promo = Parse("Standard_D13_v2_Promo");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD14 = Parse("Standard_D14");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD14V2 = Parse("Standard_D14_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD14V2Promo = Parse("Standard_D14_v2_Promo");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD15V2 = Parse("Standard_D15_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD16V3 = Parse("Standard_D16_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD16sV3 = Parse("Standard_D16s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD1V2 = Parse("Standard_D1_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD2 = Parse("Standard_D2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD2V2 = Parse("Standard_D2_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD2V2Promo = Parse("Standard_D2_v2_Promo");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD2V3 = Parse("Standard_D2_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD2sV3 = Parse("Standard_D2s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD3 = Parse("Standard_D3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD32V3 = Parse("Standard_D32_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD32sV3 = Parse("Standard_D32s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD3V2 = Parse("Standard_D3_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD3V2Promo = Parse("Standard_D3_v2_Promo");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD4 = Parse("Standard_D4");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD4V2 = Parse("Standard_D4_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD4V2Promo = Parse("Standard_D4_v2_Promo");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD4V3 = Parse("Standard_D4_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD4sV3 = Parse("Standard_D4s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD5V2 = Parse("Standard_D5_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD5V2Promo = Parse("Standard_D5_v2_Promo");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD64V3 = Parse("Standard_D64_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD64sV3 = Parse("Standard_D64s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD8V3 = Parse("Standard_D8_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardD8sV3 = Parse("Standard_D8s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS1 = Parse("Standard_DS1");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS11 = Parse("Standard_DS11");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS11V2 = Parse("Standard_DS11_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS11V2Promo = Parse("Standard_DS11_v2_Promo");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS12 = Parse("Standard_DS12");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS12V2 = Parse("Standard_DS12_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS12V2Promo = Parse("Standard_DS12_v2_Promo");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS13 = Parse("Standard_DS13");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS132V2 = Parse("Standard_DS13-2_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS134V2 = Parse("Standard_DS13-4_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS13V2 = Parse("Standard_DS13_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS13V2Promo = Parse("Standard_DS13_v2_Promo");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS14 = Parse("Standard_DS14");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS144V2 = Parse("Standard_DS14-4_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS148V2 = Parse("Standard_DS14-8_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS14V2 = Parse("Standard_DS14_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS14V2Promo = Parse("Standard_DS14_v2_Promo");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS15V2 = Parse("Standard_DS15_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS1V2 = Parse("Standard_DS1_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS2 = Parse("Standard_DS2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS2V2 = Parse("Standard_DS2_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS2V2Promo = Parse("Standard_DS2_v2_Promo");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS3 = Parse("Standard_DS3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS3V2 = Parse("Standard_DS3_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS3V2Promo = Parse("Standard_DS3_v2_Promo");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS4 = Parse("Standard_DS4");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS4V2 = Parse("Standard_DS4_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS4V2Promo = Parse("Standard_DS4_v2_Promo");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS5V2 = Parse("Standard_DS5_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardDS5V2Promo = Parse("Standard_DS5_v2_Promo");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardE16V3 = Parse("Standard_E16_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardE16sV3 = Parse("Standard_E16s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardE2V3 = Parse("Standard_E2_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardE2sV3 = Parse("Standard_E2s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardE3216sV3 = Parse("Standard_E32-16s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardE328sV3 = Parse("Standard_E32-8s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardE32V3 = Parse("Standard_E32_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardE32sV3 = Parse("Standard_E32s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardE4V3 = Parse("Standard_E4_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardE4sV3 = Parse("Standard_E4s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardE6416sV3 = Parse("Standard_E64-16s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardE6432sV3 = Parse("Standard_E64-32s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardE64V3 = Parse("Standard_E64_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardE64sV3 = Parse("Standard_E64s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardE8V3 = Parse("Standard_E8_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardE8sV3 = Parse("Standard_E8s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardF1 = Parse("Standard_F1");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardF16 = Parse("Standard_F16");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardF16s = Parse("Standard_F16s");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardF16sV2 = Parse("Standard_F16s_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardF1s = Parse("Standard_F1s");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardF2 = Parse("Standard_F2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardF2s = Parse("Standard_F2s");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardF2sV2 = Parse("Standard_F2s_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardF32sV2 = Parse("Standard_F32s_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardF4 = Parse("Standard_F4");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardF4s = Parse("Standard_F4s");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardF4sV2 = Parse("Standard_F4s_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardF64sV2 = Parse("Standard_F64s_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardF72sV2 = Parse("Standard_F72s_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardF8 = Parse("Standard_F8");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardF8s = Parse("Standard_F8s");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardF8sV2 = Parse("Standard_F8s_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardG1 = Parse("Standard_G1");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardG2 = Parse("Standard_G2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardG3 = Parse("Standard_G3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardG4 = Parse("Standard_G4");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardG5 = Parse("Standard_G5");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardGS1 = Parse("Standard_GS1");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardGS2 = Parse("Standard_GS2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardGS3 = Parse("Standard_GS3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardGS4 = Parse("Standard_GS4");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardGS44 = Parse("Standard_GS4-4");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardGS48 = Parse("Standard_GS4-8");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardGS5 = Parse("Standard_GS5");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardGS516 = Parse("Standard_GS5-16");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardGS58 = Parse("Standard_GS5-8");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardH16 = Parse("Standard_H16");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardH16m = Parse("Standard_H16m");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardH16mr = Parse("Standard_H16mr");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardH16r = Parse("Standard_H16r");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardH8 = Parse("Standard_H8");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardH8m = Parse("Standard_H8m");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardL16s = Parse("Standard_L16s");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardL32s = Parse("Standard_L32s");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardL4s = Parse("Standard_L4s");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardL8s = Parse("Standard_L8s");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardM12832ms = Parse("Standard_M128-32ms");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardM12864ms = Parse("Standard_M128-64ms");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardM128ms = Parse("Standard_M128ms");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardM128s = Parse("Standard_M128s");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardM6416ms = Parse("Standard_M64-16ms");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardM6432ms = Parse("Standard_M64-32ms");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardM64ms = Parse("Standard_M64ms");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardM64s = Parse("Standard_M64s");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardNC12 = Parse("Standard_NC12");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardNC12sV2 = Parse("Standard_NC12s_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardNC12sV3 = Parse("Standard_NC12s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardNC24 = Parse("Standard_NC24");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardNC24r = Parse("Standard_NC24r");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardNC24rsV2 = Parse("Standard_NC24rs_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardNC24rsV3 = Parse("Standard_NC24rs_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardNC24sV2 = Parse("Standard_NC24s_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardNC24sV3 = Parse("Standard_NC24s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardNC6 = Parse("Standard_NC6");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardNC6sV2 = Parse("Standard_NC6s_v2");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardNC6sV3 = Parse("Standard_NC6s_v3");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardND12s = Parse("Standard_ND12s");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardND24rs = Parse("Standard_ND24rs");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardND24s = Parse("Standard_ND24s");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardND6s = Parse("Standard_ND6s");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardNV12 = Parse("Standard_NV12");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardNV24 = Parse("Standard_NV24");
        public static readonly ServiceFabricVirtualMachineSizeTypes StandardNV6 = Parse("Standard_NV6");
    }
}
