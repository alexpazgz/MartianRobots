using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inputs.Commands
{
    public class CreateEditInputCommand : IRequest<string>
    {
        public OutputResponse OutputResponse { get; }

        public CreateEditInputCommand(OutputResponse outputResponse)
        {
            OutputResponse = outputResponse;
        }
    }

    public class CreateEditInputCommandandler : IRequestHandler<CreateEditInputCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IOutputTextFormatterService _outputTextFormatterService;
        private readonly IMapper _mapper;

        public CreateEditInputCommandandler(IApplicationDbContext context,
            IOutputTextFormatterService outputTextFormatterService,
            IMapper mapper)
        {
            _context = context;
            _outputTextFormatterService = outputTextFormatterService;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateEditInputCommand request, CancellationToken cancellationToken)
        {
            var outputs = request.OutputResponse.Robots.Select(s => s.Output).ToList();
            var response = _outputTextFormatterService.FormatText(outputs);

            var input = _context.Surface
                .Include(i => i.Robots)
                .Include(i => i.ExploredSurfaces)
                    .FirstOrDefault(x => x.XCoordinate == request.OutputResponse.Surface.XCoordinate &&
                    x.YCoordinate == request.OutputResponse.Surface.YCoordinate);

            bool InsertOrUpdate = false;
            if (input == null)
            {
                var surface = _mapper.Map<Surface>(request.OutputResponse);
                _context.Surface.Add(surface);
                InsertOrUpdate = true;
            }
            else
            {
                var newRobots = _mapper.Map<List<Robot>>(request.OutputResponse.Robots);
                foreach (var robot in newRobots)
                {
                    if (!input.Robots.Any(x => x.XCoordinate == robot.XCoordinate &&
                        x.YCoordinate == robot.YCoordinate && 
                        x.Orientation == robot.Orientation &&
                        x.Instruction == robot.Instruction))
                    {
                        input.Robots.Add(robot);
                        InsertOrUpdate = true;
                    }
                }

                if (InsertOrUpdate)
                {
                    var newExploredSurfaces = _mapper.Map<List<ExploredSurface>>(request.OutputResponse.ExploredSurface);
                    foreach (var exploredSurface in newExploredSurfaces)
                    {
                        if (!input.ExploredSurfaces.Any(x => x.XCoordinate == exploredSurface.XCoordinate &&
                            x.YCoordinate == exploredSurface.YCoordinate))
                        {
                            input.ExploredSurfaces.Add(exploredSurface);
                        }
                    }
                }
            }

            if (InsertOrUpdate)
                await _context.SaveChangesAsync(cancellationToken);          

            return response;
        }
    }


}
