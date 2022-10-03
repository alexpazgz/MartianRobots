using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Common.Model
{
    public class RobotTest
    {

        [Test]
        public async Task ShouldReturnEast()
        {
            RobotResource robotResource = new RobotResource()
            {
                XCoordinate = 1,
                YCoordinate = 1,
                Orientation = Domain.Enums.Orientation.N
            };

            robotResource.DoMovement(Domain.Enums.Instruction.R, new List<ScentResource>());

            var orientation = robotResource.Orientation;

            Assert.NotNull(orientation);
            Assert.That(orientation, Is.EqualTo(Domain.Enums.Orientation.E));

        }

        [Test]
        public async Task ShouldReturnWest()
        {
            RobotResource robotResource = new RobotResource()
            {
                XCoordinate = 1,
                YCoordinate = 1,
                Orientation = Domain.Enums.Orientation.N
            };

            robotResource.DoMovement(Domain.Enums.Instruction.L, new List<ScentResource>());

            var orientation = robotResource.Orientation;

            Assert.NotNull(orientation);
            Assert.That(orientation, Is.EqualTo(Domain.Enums.Orientation.W));

        }

        [Test]
        public async Task ShouldReturnNorth()
        {
            RobotResource robotResource = new RobotResource()
            {
                XCoordinate = 1,
                YCoordinate = 1,
                Orientation = Domain.Enums.Orientation.N
            };

            robotResource.DoMovement(Domain.Enums.Instruction.R, new List<ScentResource>());
            robotResource.DoMovement(Domain.Enums.Instruction.L, new List<ScentResource>());

            var orientation = robotResource.Orientation;

            Assert.NotNull(orientation);
            Assert.That(orientation, Is.EqualTo(Domain.Enums.Orientation.N));

        }

        [Test]
        public async Task ShouldReturnSouth()
        {
            RobotResource robotResource = new RobotResource()
            {
                XCoordinate = 1,
                YCoordinate = 1,
                Orientation = Domain.Enums.Orientation.N
            };

            robotResource.DoMovement(Domain.Enums.Instruction.R, new List<ScentResource>());
            robotResource.DoMovement(Domain.Enums.Instruction.R, new List<ScentResource>());

            var orientation = robotResource.Orientation;

            Assert.NotNull(orientation);
            Assert.That(orientation, Is.EqualTo(Domain.Enums.Orientation.S));

        }

        [Test]
        public async Task ShouldDoForwardNorthMovementOK()
        {
            RobotResource robotResource = new RobotResource()
            {
                XCoordinate = 1,
                YCoordinate = 1,
                Orientation = Domain.Enums.Orientation.N
            };

            robotResource.DoMovement(Domain.Enums.Instruction.F, new List<ScentResource>());

            var coordinatesExpected = new CoordinatesResource(1, 2);
            var coordinates = new CoordinatesResource(robotResource.XCoordinate, robotResource.YCoordinate);

            Assert.NotNull(robotResource);
            Assert.That(coordinatesExpected.XCoordinate, Is.EqualTo(coordinates.XCoordinate));
            Assert.That(coordinatesExpected.YCoordinate, Is.EqualTo(coordinates.YCoordinate));
        }

        [Test]
        public async Task ShouldDoForwardSouthMovementOK()
        {
            RobotResource robotResource = new RobotResource()
            {
                XCoordinate = 1,
                YCoordinate = 1,
                Orientation = Domain.Enums.Orientation.S
            };

            robotResource.DoMovement(Domain.Enums.Instruction.F, new List<ScentResource>());

            var coordinatesExpected = new CoordinatesResource(1, 0);
            var coordinates = new CoordinatesResource(robotResource.XCoordinate, robotResource.YCoordinate);

            Assert.NotNull(robotResource);
            Assert.That(coordinatesExpected.XCoordinate, Is.EqualTo(coordinates.XCoordinate));
            Assert.That(coordinatesExpected.YCoordinate, Is.EqualTo(coordinates.YCoordinate));
        }

        [Test]
        public async Task ShouldDoForwardEasthMovementOK()
        {
            RobotResource robotResource = new RobotResource()
            {
                XCoordinate = 1,
                YCoordinate = 1,
                Orientation = Domain.Enums.Orientation.E
            };

            robotResource.DoMovement(Domain.Enums.Instruction.F, new List<ScentResource>());

            var coordinatesExpected = new CoordinatesResource(2, 1);
            var coordinates = new CoordinatesResource(robotResource.XCoordinate, robotResource.YCoordinate);

            Assert.NotNull(robotResource);
            Assert.That(coordinatesExpected.XCoordinate, Is.EqualTo(coordinates.XCoordinate));
            Assert.That(coordinatesExpected.YCoordinate, Is.EqualTo(coordinates.YCoordinate));
        }

        [Test]
        public async Task ShouldDoForwardWestMovementOK()
        {
            RobotResource robotResource = new RobotResource()
            {
                XCoordinate = 1,
                YCoordinate = 1,
                Orientation = Domain.Enums.Orientation.W
            };

            robotResource.DoMovement(Domain.Enums.Instruction.F, new List<ScentResource>());

            var coordinatesExpected = new CoordinatesResource(0, 1);
            var coordinates = new CoordinatesResource(robotResource.XCoordinate, robotResource.YCoordinate);

            Assert.NotNull(robotResource);
            Assert.That(coordinatesExpected.XCoordinate, Is.EqualTo(coordinates.XCoordinate));
            Assert.That(coordinatesExpected.YCoordinate, Is.EqualTo(coordinates.YCoordinate));
        }
    }
}
