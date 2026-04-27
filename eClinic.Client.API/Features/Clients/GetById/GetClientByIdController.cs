using eClinic.Client.Application.Features.Clients.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eClinic.Client.Application.Features.Clients.GetById
{
    [ApiController]
    [Route("api/client")]
    public class GetClientByIdController : Controller
    {
        private readonly IMediator _mediator;
        public GetClientByIdController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientById([FromQuery]GetClientQuery query)
        {
            var result = await _mediator.Send(query);

            return result.IsSuccess ?
            Ok(result.Value)
            : BadRequest(new { message = result.Error });

        }
    }
}
