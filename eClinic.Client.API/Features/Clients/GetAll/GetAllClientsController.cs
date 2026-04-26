using eClinic.Client.Application.Features.Clients.Create;
using eClinic.Client.Application.Features.Clients.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eClinic.Client.API.Features.Clients.GetAll
{
    [ApiController]
    [Route("api/clients")]
    public class GetAllClientsController : ControllerBase
    {

        private readonly IMediator _mediator;
        public GetAllClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromHeader]GetAllClientsQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
