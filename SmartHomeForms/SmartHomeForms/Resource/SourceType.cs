using System;

namespace SmartHomeForms
{
    [Flags]
    public enum SourceType
    {
        ColdWater = 0x1,
        WarmWater = 0x2,
        Electricity = 0x4,
        TechnicalWater = 0x8
    }
}