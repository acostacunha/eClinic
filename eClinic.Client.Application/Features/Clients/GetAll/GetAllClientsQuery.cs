using MediatR;
using System.ComponentModel;

namespace eClinic.Client.Application.Features.Clients.GetAll
{
    public class GetAllClientsQuery: IRequest<GetAllClientsResult>
    {
        public int PageSize { get; set; } =10;
        public int Page { get; set; } = 1;

    }
}
