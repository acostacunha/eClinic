using eClinic.Client.Application.Common;
using MediatR;

namespace eClinic.Client.Application.Features.Clients.Delete
{
    public class DeleteClientCommand : IRequest<Result<bool>>
    {
        public Guid PublicId { get; set; }
    }
}
