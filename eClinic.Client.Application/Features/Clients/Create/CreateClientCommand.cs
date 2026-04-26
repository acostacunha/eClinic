using eClinic.Client.Application.Common;
using eClinic.Client.Domain.Enums;
using MediatR;

namespace eClinic.Client.Application.Features.Clients.Create
{
    public class CreateClientCommand : IRequest<Result<Guid>>
    {
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set;  } = string.Empty;
        public string Phone {  get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public GenderType Gender { get; set; }
    }
}
