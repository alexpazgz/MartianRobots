using Application.Common.Models;

namespace Application.Common.Interfaces
{
    public interface IMovementOverRectangularSurfaceService
    {
        OutputResponse DoMovementsOverSurface(InputResource input);

    }
}
