using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class OutputResource : CoordinatesOrientationResource
    {
        public bool Lost { get; set; }

        public OutputResource(int xCoordinate,
            int yCoordinate, Orientation orientation,
            bool lost)
            : base (xCoordinate, yCoordinate, orientation)
        {
            Lost = lost;
        }
    }
}
