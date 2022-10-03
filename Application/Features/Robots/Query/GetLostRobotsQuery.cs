using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Common.ViewModel.GetLostRobotsQuery;
using Application.Features.Outputs.Querys;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Robots.Query
{
    public class GetLostRobotsQuery : IRequest<List<LostRobotsVm>>
    {
    }

    public class GetLostRobotsQueryHandler : IRequestHandler<GetLostRobotsQuery, List<LostRobotsVm>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetLostRobotsQueryHandler(IApplicationDbContext context,
            IMapper mapper)
        {
            this._context = context;
            _mapper = mapper;
        }

        public async Task<List<LostRobotsVm>> Handle(GetLostRobotsQuery request, CancellationToken cancellationToken)
        {
            var lostRobots = await _context.Robot
                .Include(i => i.Surface)
                .Include(i => i.Output)
                .Where(x => x.Output.Lost)
                .ToListAsync();

            var lostRobotsVm = _mapper.Map<List<Robot>, List<LostRobotsVm>>(lostRobots);

            return lostRobotsVm; 
        }
    }
}
