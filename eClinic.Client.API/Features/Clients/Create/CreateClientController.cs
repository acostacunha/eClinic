using eClinic.Client.Application.Features.Clients.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eClinic.Client.API.Features.Clients.Create
{
    [ApiController]
    [Route("api/client")]
    public class CreateClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CreateClientController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateClientCommand command)
        {
                var result = await _mediator.Send(command);

                return result.IsSuccess ?
                Created($"/api/client/{result.Value}", new { publicId = result.Value })
                : BadRequest( new { message = result.Error });
        }
    }
}
