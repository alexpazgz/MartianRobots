using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class ScentResource : CoordinatesOrientationResource
    {
        public ScentResource(int xCoordinate,
            int yCoordinate, Orientation orientation)
            : base(xCoordinate, yCoordinate, orientation)
        {

        }
    }
}
