using eClinic.Client.Application.Common;
using eClinic.Client.Domain.Interfaces.Repositories;
using MediatR;

namespace eClinic.Client.Application.Features.Clients.Delete
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Result<bool>>
    {
        private readonly IClientRepository _clientRepository;
        public DeleteClientCommandHandler(IClientRepository repository)
        {
            _clientRepository = repository;
        }

        public async Task<Result<bool>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByPublicIdAsync(request.PublicId);
            if (client is null) return Result<bool>.Failure("Cliente não encontrado");

            await _clientRepository.DeleteAsync(client);

            return Result<bool>.Success(true);
        }
    }
}
