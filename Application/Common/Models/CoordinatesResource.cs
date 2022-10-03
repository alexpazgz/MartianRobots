using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public  class CoordinatesResource
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public CoordinatesResource()
        {
        }

        public CoordinatesResource(int xCoordinate,
            int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }
    }
}
