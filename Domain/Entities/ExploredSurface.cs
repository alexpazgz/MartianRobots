using Domain.Common;

namespace Domain.Entities
{
    public class ExploredSurface : CoordinatesBase
    {
        public virtual Surface Surface { get; set; }
    }
}
