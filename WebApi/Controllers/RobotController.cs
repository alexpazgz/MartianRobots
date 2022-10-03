using Application.Common.Models;
using Application.Features.Inputs.Commands;
using Application.Features.Robots.Query;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebApi.Controllers
{

    public class RobotController : ApiControllerBase
    {
        private readonly ILogger<InputController> _logger;

        public RobotController(ILogger<InputController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet("GetLostRobots")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetLostRobot()
        {

            var getLostRobotsQuery = new GetLostRobotsQuery();

            var response = await Mediator.Send(getLostRobotsQuery);

            return Ok(response);
        }
    }
}
