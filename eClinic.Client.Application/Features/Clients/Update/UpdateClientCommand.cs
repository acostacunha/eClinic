using eClinic.Client.Application.Common;
using eClinic.Client.Domain.Enums;
using MediatR;

namespace eClinic.Client.Application.Features.Clients.Update
{
    public class UpdateClientCommand : IRequest<Result<bool>>
    {
        public Guid PublicId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public GenderType Gender { get; set; }
    }
}
