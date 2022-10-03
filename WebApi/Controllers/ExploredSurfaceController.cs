using Application.Features.Outputs.Querys;
using Application.Features.Robots.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ExploredSurfaceController : ApiControllerBase
    {
        private readonly ILogger<InputController> _logger;

        public ExploredSurfaceController(ILogger<InputController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "ExploredSurface")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> Index()
        {
            var getExploredSurfaceQuery = new GetExploredSurfaceQuery();

            var response = await Mediator.Send(getExploredSurfaceQuery);

            return Ok(response);
        }
    }
}
