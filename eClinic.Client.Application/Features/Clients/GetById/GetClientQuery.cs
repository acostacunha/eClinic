using eClinic.Client.Application.Common;
using MediatR;

namespace eClinic.Client.Application.Features.Clients.GetById
{
    public class GetClientQuery : IRequest<Result<ClientResponse>>
    {
        public Guid PublicId { get; set; }
    }
}
