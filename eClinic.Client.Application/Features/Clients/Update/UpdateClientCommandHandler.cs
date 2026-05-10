using eClinic.Client.Application.Common;
using eClinic.Client.Domain.Interfaces.Repositories;
using eClinic.Client.Domain.ValueObjects;
using MediatR;

namespace eClinic.Client.Application.Features.Clients.Update
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Result<bool>>
    {
        private readonly IClientRepository _clientRepository;
        public UpdateClientCommandHandler(IClientRepository repository)
        {
            _clientRepository = repository;
        }

        public async Task<Result<bool>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByPublicIdAsync(request.PublicId);
            if (client is null) return Result<bool>.Failure("Cliente não encontrado."); 

            var email = Email.Create(request.Email);
            client.UpdateClient(request.Name, email, request.Phone, request.Birthdate, request.Gender);

            await _clientRepository.UpdateAsync(client);

            return Result<bool>.Success(true);
        }
    }
}
