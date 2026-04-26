using eClinic.Client.Application.Common;
using eClinic.Client.Domain.Interfaces.Repositories;
using eClinic.Client.Domain.ValueObjects;
using MediatR;
using ClientEntity = eClinic.Client.Domain.Entities.Client;

namespace eClinic.Client.Application.Features.Clients.Create
{
    public class CreateClientCommandHandler : 
        IRequestHandler<CreateClientCommand, Result<Guid>>
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Result<Guid>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var email = Email.Create(request.Email);
                var cpf = Cpf.Create(request.Cpf);
                var cpfJaExistente = await _clientRepository.GetByCpfAsync(cpf.CpfNumber);
                if (cpfJaExistente != null)
                    return Result<Guid>.Failure("Já existe um cliente cadastrado com este CPF");

                var client = new ClientEntity(request.Name, cpf, email, request.Phone, request.Birthdate, request.Gender);

                await _clientRepository.AddAsync(client);
                return Result<Guid>.Success(client.PublicId);
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure($"Erro ao criar cliente: {ex.Message}");
            }
        }
    }
}
