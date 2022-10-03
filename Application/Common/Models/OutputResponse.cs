using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class OutputResponse
    {
        public CoordinatesResource Surface { get; set; }
        public List<RobotResource> Robots { get; set; }
        public List<ExploredSurfaceResource> ExploredSurface { get; set; }

        public OutputResponse(CoordinatesResource surface,
            List<RobotResource> robots,
            List<ExploredSurfaceResource> exploredSurface)
        {
            Surface = surface;
            Robots = robots;
            ExploredSurface = exploredSurface;
        }

        public OutputResponse(int xSurfaceCoordinate,
            int ySurfaceCoordinate)
        {
            Surface = new CoordinatesResource(xSurfaceCoordinate, ySurfaceCoordinate);
            ExploredSurface = new List<ExploredSurfaceResource>();
        }
    }
}
