using eClinic.Client.Application.Features.Clients.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eClinic.Client.API.Features.Clients.Update
{
    [ApiController]
    [Route("api/client")]
    public class UpdateClientController : Controller
    {
        private readonly IMediator _mediator;
        public UpdateClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateClientCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccess ? NoContent()
            : BadRequest(new { message = result.Error });
        }
    }
}
