using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class RobotResource : CoordinatesOrientationResource, IRobot
    {
        public List<Instruction> Instructions { get; set; }
        public OutputResource Output { get; set; }
        public RobotResource()
        {
        }

        public RobotResource(string inputRobots, string instructionsRobots)
        {
            try
            {
                var robotCoordinatesOrientationSplited = inputRobots.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (robotCoordinatesOrientationSplited.Any() && 
                    robotCoordinatesOrientationSplited.Length == 3)
                {
                    if(Int32.TryParse(robotCoordinatesOrientationSplited[0], out int xCoordinate) &&
                        Int32.TryParse(robotCoordinatesOrientationSplited[1], out int yCoordinate))
                    {
                        XCoordinate = xCoordinate;
                        YCoordinate = yCoordinate;
                        Enum.TryParse(robotCoordinatesOrientationSplited[2], out Orientation orientation);
                        Orientation = orientation;
                        Instructions = new List<Instruction>();
                        var instructions = instructionsRobots.Trim();
                        foreach (char c in instructions)
                        {
                            Enum.TryParse(c.ToString(), out Instruction instruction);
                            Instructions.Add(instruction);
                        }
                    }
                    else
                    {
                        throw new InputException("Robots coordinates should be a string x, y position and orientation (N, S, E, W)");
                    }                 
                }
                else
                {
                    throw new InputException("Invalid coordinates in input");
                }               
            }
            catch (Exception ex)
            {
                throw new InputException("Invalid coordinates in input", ex);
            }
        }

        public void DoMovement(Instruction instruction, List<ScentResource> scents)
        {
            switch (instruction)
            {
                case Instruction.L:
                    MoveLeft();
                    break;
                case Instruction.R:
                    MoveRight();
                    break;
                case Instruction.F:
                    MoveForward(scents);
                    break;
                default:
                    throw new Exception("Instrucion not defined");
            }
        }

        #region private mhetods
        private void MoveLeft()
        {
            switch (Orientation)
            {
                case Orientation.N:
                    Orientation = Orientation.W;
                    break;
                case Orientation.S:
                    Orientation = Orientation.E;
                    break;
                case Orientation.E:
                    Orientation = Orientation.N;
                    break;
                case Orientation.W:
                    Orientation = Orientation.S;
                    break;
                default:
                    throw new Exception("Orientation not defined");
            }
        }

        private void MoveRight()
        {
            switch (Orientation)
            {
                case Orientation.N:
                    Orientation = Orientation.E;
                    break;
                case Orientation.S:
                    Orientation = Orientation.W;
                    break;
                case Orientation.E:
                    Orientation = Orientation.S;
                    break;
                case Orientation.W:
                    Orientation = Orientation.N;
                    break;
                default:
                    throw new Exception("Orientation not defined");
            }
        }

        private void MoveForward(List<ScentResource> scents)
        {
            if (!scents.Any(x => x.XCoordinate == XCoordinate && x.YCoordinate == YCoordinate && x.Orientation == Orientation))
            {
                switch (Orientation)
                {
                    case Orientation.N:
                        YCoordinate++;
                        break;
                    case Orientation.S:
                        YCoordinate--;
                        break;
                    case Orientation.E:
                        XCoordinate++;
                        break;
                    case Orientation.W:
                        XCoordinate--;
                        break;
                    default:
                        throw new Exception("Orientation not defined");
                }
            }
        }
        #endregion
    }
}
