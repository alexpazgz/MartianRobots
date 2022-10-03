using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Common
{
    public abstract class CoordinatesOrientationBase : BaseEntity, ICoordinatesOrientation
    {
        public Orientation Orientation { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
    }
}
