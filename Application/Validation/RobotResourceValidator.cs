using Application.Common.Models;
using Domain.Enums;
using FluentValidation;

namespace Application.Validation
{
    public class RobotResourceValidator: AbstractValidator<RobotResource>
    {
        public RobotResourceValidator()
        {
            RuleFor(x => x.XCoordinate)
                .Must(BeAValidCoordinate)
                .WithMessage("Maximum value for any coordinate is 50.")
                .OverridePropertyName("XCoordinate");

            RuleFor(x => x.YCoordinate)
                .Must(BeAValidCoordinate)
                .WithMessage("Maximum value for any coordinate is 50.")
                .OverridePropertyName("YCoordinate");

            RuleFor(x => x.Orientation)
                .Must(BeAValidOrientationCharacter)
                .WithMessage("Robot orientation should be a letter N, S, E or W.")
                .OverridePropertyName("YCoordinate");

            RuleFor(x => x.Instructions)
                .Must(BeAValidInstruction)
                .WithMessage("Instruction should be less than 100 characters.")
                .OverridePropertyName("Instructions");

            RuleFor(x => x.Instructions)
                .Must(BeAValidInstructionCharacter)
                .WithMessage("Robot instruction should be a string of the letters L, R, and F.")
                .OverridePropertyName("Instructions");

        }

        private bool BeAValidCoordinate(int coordinate)
        {

            if (coordinate > 50)
                return false;

            return true;
        }

        private bool BeAValidInstruction(List<Instruction> instructions)
        {

            if (!instructions.Any() && instructions.Count >= 100)
                return false;

            return true;
        }

        private bool BeAValidOrientationCharacter(Orientation orientation)
        {
            if (!Enum.IsDefined(typeof(Orientation), orientation))
            {
                return false;
            }           

            return true;
        }

        private bool BeAValidInstructionCharacter(List<Instruction> instructions)
        {
            foreach (var intruction in instructions)
            {
                if (!Enum.IsDefined(typeof(Instruction), intruction))
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}
