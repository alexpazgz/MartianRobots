using Domain.Enums;

namespace Domain.Interfaces
{
    public  interface ICoordinatesOrientation : ICoordinates
    {
        public Orientation Orientation { get; set; }
    }
}
