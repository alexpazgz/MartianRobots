using Application.Features.Inputs.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validation
{
    internal class CreateEditInputCommandValidator : AbstractValidator<CreateEditInputCommand>
    {
        public CreateEditInputCommandValidator()
        {
            RuleFor(x => x.OutputResponse)
                .NotNull()
                .WithMessage("OutputResponse is required.")
                .OverridePropertyName("OutputResponse");

            RuleFor(x => x.OutputResponse.Surface)
                .NotNull()
                .WithMessage("Surface is required.")
                .OverridePropertyName("Surface");

            RuleFor(x => x.OutputResponse.Robots)
                .NotNull()
                .WithMessage("Robots is required.")
                .OverridePropertyName("Robots");

            RuleFor(x => x.OutputResponse.ExploredSurface)
                .NotNull()
                .WithMessage("ExploredSurface is required.")
                .OverridePropertyName("ExploredSurface");
        }
    }
}
