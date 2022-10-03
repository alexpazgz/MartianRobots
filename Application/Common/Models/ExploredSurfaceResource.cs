using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class ExploredSurfaceResource : CoordinatesResource
    {
        public ExploredSurfaceResource(int xCoordinate,
            int yCoordinate)
            : base (xCoordinate, yCoordinate)
        {

        }
    }
}
