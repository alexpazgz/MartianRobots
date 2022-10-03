using Application.Common.Interfaces;
using Application.Common.ViewModel.CommonVm;
using Application.Common.ViewModel.GetExploredSurface;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Outputs.Querys
{
    public class GetExploredSurfaceQuery : IRequest<List<ExploredSurfaceVm>>
    {

    }

    public class GetScentsBySurfaceQueryHandler : IRequestHandler<GetExploredSurfaceQuery, List<ExploredSurfaceVm>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetScentsBySurfaceQueryHandler(IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ExploredSurfaceVm>> Handle(GetExploredSurfaceQuery request, CancellationToken cancellationToken)
        {
            var Surfaces = await _context.Surface
                .Include(i => i.ExploredSurfaces)
                .ToListAsync();

            var exploredSurfaceVm = new List<ExploredSurfaceVm>();
            foreach (var surface in Surfaces)
            {
                var explored = new ExploredSurfaceVm()
                {
                    Surface = new SurfaceVm() { XCoordinate = surface.XCoordinate, YCoordinate = surface.YCoordinate },
                    ExploredSurface = _mapper.Map<List<ExploredSurface>, List<ExploredVm>>(surface.ExploredSurfaces)
                };
                exploredSurfaceVm.Add(explored);
            }

            return exploredSurfaceVm;
        }

        
    }
}
