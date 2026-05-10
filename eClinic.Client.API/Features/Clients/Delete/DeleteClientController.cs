using eClinic.Client.Application.Features.Clients.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eClinic.Client.API.Features.Clients.Delete
{
    [ApiController]
    [Route("api/client")]
    public class DeleteClientController : Controller
    {
        private readonly IMediator _mediator;
        public DeleteClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteClientCommand { PublicId = id });

            return result.IsSuccess ? NoContent()
            : BadRequest(new { message = result.Error });
        }
    }
}
