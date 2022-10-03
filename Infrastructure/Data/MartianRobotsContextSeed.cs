using Infrastructure.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;

namespace Infrastructure.Data
{
    public class MartianRobotsContextSeed
    {
        private readonly ApplicationDbContext _context;
        public MartianRobotsContextSeed(ApplicationDbContext context)
        {
                _context = context;
        }

        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.Surface.Any())
            {
                var input = GetSurface();

                await context.Surface.AddAsync(input);
                await context.SaveChangesAsync();
            }
        }

        public async Task SeedAsync()
        {
            if (_context.Database.IsSqlServer())
                return;

            if ( !_context.Surface.Any())
            {
                var input = GetSurface();

                await _context.Surface.AddAsync(input);
                await _context.SaveChangesAsync();
            }           
        }

        private static Surface GetSurface()
        {
            var robots = GetRobots();
            var exploredSurfacesList = GetExploredSurfaces();

            var surface = new Surface() { Id = 1, XCoordinate = 5, YCoordinate = 3, Robots = robots, ExploredSurfaces = exploredSurfacesList };

            return surface;
        }

        private static List<Robot> GetRobots()
        {
            var output = new Output() { Id = 1, XCoordinate = 1, YCoordinate = 1, Orientation = Domain.Enums.Orientation.E, Lost = false };
            var robot = new Robot() { Id = 1, XCoordinate = 1, YCoordinate = 1, Orientation = Domain.Enums.Orientation.E, Instruction = "RFRFRFRF", Output = output };

            var output1 = new Output() { Id = 2, XCoordinate = 3, YCoordinate = 3, Orientation = Domain.Enums.Orientation.N, Lost = true };
            var robot1 = new Robot() { Id = 2, XCoordinate = 3, YCoordinate = 2, Orientation = Domain.Enums.Orientation.N, Instruction = "FRRFLLFFRRFLL", Output = output1 };

            var output2 = new Output() { Id = 3, XCoordinate = 4, YCoordinate = 2, Orientation = Domain.Enums.Orientation.N, Lost = false };
            var robot2 = new Robot() { Id = 3, XCoordinate = 0, YCoordinate = 3, Orientation = Domain.Enums.Orientation.W, Instruction = "LLFFFRFLFL", Output = output2 };


            var robots = new List<Robot>() { robot, robot1, robot2 };
            return robots;
        }
        private static List<ExploredSurface> GetExploredSurfaces()
        {
            var exploredSurfaces = new ExploredSurface() { Id = 1, XCoordinate = 1, YCoordinate = 1 };
            var exploredSurfaces1 = new ExploredSurface() { Id = 2, XCoordinate = 3, YCoordinate = 0 };
            var exploredSurfaces2 = new ExploredSurface() { Id = 3, XCoordinate = 0, YCoordinate = 3 };
            var exploredSurfaces3 = new ExploredSurface() { Id = 4, XCoordinate = 1, YCoordinate = 3 };
            var exploredSurfaces4 = new ExploredSurface() { Id = 5, XCoordinate = 2, YCoordinate = 3 };
            var exploredSurfaces5 = new ExploredSurface() { Id = 6, XCoordinate = 3, YCoordinate = 3 };
            var exploredSurfaces6 = new ExploredSurface() { Id = 7, XCoordinate = 3, YCoordinate = 3 };
            var exploredSurfaces7 = new ExploredSurface() { Id = 8, XCoordinate = 3, YCoordinate = 3 };
            var exploredSurfaces8 = new ExploredSurface() { Id = 9, XCoordinate = 3, YCoordinate = 3 };
            var exploredSurfaces9 = new ExploredSurface() { Id = 10, XCoordinate = 2, YCoordinate = 3 };

            var exploredSurfacesList = new List<ExploredSurface>()
            {
                exploredSurfaces,
                exploredSurfaces1,
                exploredSurfaces2,
                exploredSurfaces3,
                exploredSurfaces4,
                exploredSurfaces5,
                exploredSurfaces6,
                exploredSurfaces7,
                exploredSurfaces8,
                exploredSurfaces9
            };
            return exploredSurfacesList;
        }

    }
}
