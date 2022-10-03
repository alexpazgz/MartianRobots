using Domain.Common;

namespace Domain.Entities
{
    public class Surface : CoordinatesBase
    {
        public virtual List<Robot> Robots { get; set; }
        public virtual List<ExploredSurface> ExploredSurfaces { get; set; }
    }
}
