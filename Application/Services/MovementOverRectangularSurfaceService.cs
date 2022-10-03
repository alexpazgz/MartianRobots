using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MovementOverRectangularSurfaceService : IMovementOverRectangularSurfaceService
    {
        public OutputResponse DoMovementsOverSurface(InputResource input)
        {
            CoordinatesResource surface = new CoordinatesResource(input.XCoordinate, input.YCoordinate);
            
            var inputRobots = input.Robots;

            var outputResponse = new OutputResponse(input.XCoordinate,
                input.YCoordinate);


            var robots = new List<RobotResource>();
            var exploredSurface = new List<ExploredSurfaceResource>();
            var scents = new List<ScentResource>();

            if (inputRobots != null && inputRobots.Any())
            {
                foreach (var robot in inputRobots)
                {
                    var xInitialCoordinate = robot.XCoordinate;
                    var yInitialCoordinate = robot.YCoordinate;
                    var lostRobot = false;
                    if (OffSurface(surface, robot.XCoordinate, robot.YCoordinate))
                    {
                        lostRobot = true;
                        scents.Add(new ScentResource(robot.XCoordinate, robot.YCoordinate, robot.Orientation));
                        robot.Output = new OutputResource(robot.XCoordinate, robot.YCoordinate, robot.Orientation, lostRobot);
                    }

                    if (!lostRobot)
                    {
                        SetVisitedSurface(ref exploredSurface, robot.XCoordinate, robot.YCoordinate);
                        foreach(var instruction in robot.Instructions)
                        {
                            var xPreviousCoordinate = robot.XCoordinate;
                            var yPreviousCoordinate = robot.YCoordinate;
                            robot.DoMovement(instruction, scents);
                            if (OffSurface(surface, robot.XCoordinate, robot.YCoordinate))
                            {
                                lostRobot = true;
                                scents.Add(new ScentResource(xPreviousCoordinate, yPreviousCoordinate, robot.Orientation));
                                robot.Output = new OutputResource(xPreviousCoordinate, yPreviousCoordinate, robot.Orientation, lostRobot);
                                break;
                            }
                            else
                            {
                                SetVisitedSurface(ref exploredSurface, robot.XCoordinate, robot.YCoordinate);
                            }
                        }

                        if(!lostRobot)
                        {
                            robot.Output = new OutputResource(robot.XCoordinate, robot.YCoordinate, robot.Orientation, lostRobot);
                        }
                    }
                    robot.XCoordinate = xInitialCoordinate;
                    robot.YCoordinate = yInitialCoordinate;
                    robots.Add(robot);
                }

                outputResponse.Robots = robots;
                outputResponse.ExploredSurface = exploredSurface;
               
            }
            return outputResponse;
        }

        #region Private methods
        private bool OffSurface(CoordinatesResource surface, int currentX, int currentY)
        {
            if (!(currentX >= 0 && currentX <= surface.XCoordinate &&
                         currentY >= 0 && currentY <= surface.YCoordinate))
            {
                return true;
            }
            return false;
        }

        private void SetVisitedSurface(ref List<ExploredSurfaceResource> exploredSurface, int currentX, int currentY)
        {
            if (!exploredSurface.Any(x => x.XCoordinate == currentX && x.YCoordinate == currentY))
            {
                var visited = new ExploredSurfaceResource(currentX, currentY);
                exploredSurface.Add(visited);
            }
        }
        #endregion

    }
}
