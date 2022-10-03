using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Robot : CoordinatesOrientationBase
    {
        public string Instruction { get; set; }
        public virtual Surface Surface { get; set; }
        public virtual Output Output { get; set; }
    }
}
