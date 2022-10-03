using Domain.Enums;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Common.Models
{
    public class CoordinatesOrientationResource : CoordinatesResource
    {
        public Orientation Orientation { get; set; }

        public CoordinatesOrientationResource()
        {
        }

        public CoordinatesOrientationResource(int xCoordinate,
            int yCoordinate, Orientation orientation)
            : base (xCoordinate,yCoordinate)
        {
            Orientation = orientation;
        }
    }
}
