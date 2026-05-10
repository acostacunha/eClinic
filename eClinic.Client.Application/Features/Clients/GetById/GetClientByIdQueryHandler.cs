using eClinic.Client.Application.Common;
using eClinic.Client.Application.Features.Clients.GetAll;
using eClinic.Client.Domain.Interfaces.Repositories;
using MediatR;

namespace eClinic.Client.Application.Features.Clients.GetById
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientQuery, Result<ClientResponse>>
    {
        private readonly IClientRepository _clientRepository;

        public GetClientByIdQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<Result<ClientResponse>> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByPublicIdAsync(request.PublicId);
            if(client == null)
                    return Result<ClientResponse>.Failure("Cliente não encontrado");

            return Result<ClientResponse>.Success(new ClientResponse
            {
                Name = client.Name,
                Email = client.Email.Address,
                Phone = client.Phone,
                PublicId = client.PublicId,
                BirthDate = client.Birthdate,
                Gender = client.Gender.ToString()
            });
        }
    }
}
