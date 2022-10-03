using System.Runtime.Serialization;

namespace Domain.Enums
{
    public enum Orientation
    {
        [EnumMember(Value = "North")]
        N = 1,
        [EnumMember(Value = "South")]
        S = 2,
        [EnumMember(Value = "East")]
        E = 3,
        [EnumMember(Value = "West")]
        W = 4
    }
}
