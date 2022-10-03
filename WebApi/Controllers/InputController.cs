using Application.Common.Models;
using Application.Features.Inputs.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace WebApi.Controllers
{
    public class InputController : ApiControllerBase
    {
        private readonly ILogger<InputController> _logger;

        public InputController(ILogger<InputController> logger)
        {
            _logger = logger;
        }


        [HttpPost(Name = "Input")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<string> Index()
        {
            var inputRequest = "";
            var req = Request;

            using (StreamReader reader
                  = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
            {
                inputRequest = await reader.ReadToEndAsync();
            }

            var inputResource = new InputResource(inputRequest);           

            var inputCommand = new InputCommand(inputResource);
            var outputResponse = await Mediator.Send(inputCommand);

            var CreateEditInputCommand = new CreateEditInputCommand(outputResponse);
            var response = await Mediator.Send(CreateEditInputCommand);

            return response;
        }
    }
}
