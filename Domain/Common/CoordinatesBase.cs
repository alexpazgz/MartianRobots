using Domain.Interfaces;

namespace Domain.Common
{
    public abstract class CoordinatesBase : BaseEntity, ICoordinates
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
    }
}
