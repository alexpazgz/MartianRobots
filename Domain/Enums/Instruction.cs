using System.Runtime.Serialization;

namespace Domain.Enums
{
    public enum Instruction
    {
        [EnumMember(Value = "Left")]
        L = 1,
        [EnumMember(Value = "Right")]
        R = 2,
        [EnumMember(Value = "Forward")]
        F = 3
    }
}
