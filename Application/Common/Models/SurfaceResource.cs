using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class SurfaceResource : CoordinatesResource
    {
        public virtual List<RobotResource> Robots { get; set; }
        public virtual List<ExploredSurfaceResource> ExploredSurfaces { get; set; }
    }
}
