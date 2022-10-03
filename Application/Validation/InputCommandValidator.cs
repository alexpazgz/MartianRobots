using Application.Common.Models;
using Application.Features.Inputs.Commands;
using FluentValidation;

namespace Application.Validation
{
    public class InputCommandValidator : AbstractValidator<InputCommand>
    {
        public InputCommandValidator()
        {
            RuleFor(x => x.InputResource.XCoordinate)
                .Must(BeAValidCoordinate)
                .WithMessage("Maximum value for any coordinate is 50.")
                .OverridePropertyName("XCoordinate");

            RuleFor(x => x.InputResource.YCoordinate)
                .Must(BeAValidCoordinate)
                .WithMessage("Maximum value for any coordinate is 50.")
                .OverridePropertyName("YCoordinate");

            RuleForEach(x => x.InputResource.Robots)
                .SetValidator(new RobotResourceValidator());
        }

        private bool BeAValidCoordinate(int coordinate)
        {
            if (coordinate > 50)
                return false;

            return true;
        }
    }
}
