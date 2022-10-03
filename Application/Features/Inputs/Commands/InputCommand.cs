using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Inputs.Commands
{
    public class InputCommand : IRequest<OutputResponse>
    {
        public InputResource InputResource { get; }

        public InputCommand(InputResource inputResource)
        {
            InputResource = inputResource;
        }
    }

    public class InputCommandHandler : IRequestHandler<InputCommand, OutputResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMovementOverRectangularSurfaceService _movementOverRectangularSurfaceService;
        private readonly IOutputTextFormatterService _outputTextFormatterService;
        private readonly IMapper _mapper;

        public InputCommandHandler(IApplicationDbContext context,
            IMovementOverRectangularSurfaceService movementOverRectangularSurfaceService,
            IOutputTextFormatterService outputTextFormatterService,
            IMapper mapper)
        {
            _context = context;
            _movementOverRectangularSurfaceService = movementOverRectangularSurfaceService;
            _outputTextFormatterService = outputTextFormatterService;
            _mapper = mapper;
        }

        public async Task<OutputResponse> Handle(InputCommand request, CancellationToken cancellationToken)
        {
            if (request.InputResource == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var responseService = _movementOverRectangularSurfaceService.DoMovementsOverSurface(request.InputResource);

            return await Task.FromResult(responseService);
        }
    }
}
