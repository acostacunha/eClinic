using eClinic.Client.Domain.Interfaces.Repositories;
using MediatR;
using System.Text.RegularExpressions;

namespace eClinic.Client.Application.Features.Clients.GetAll
{
    public class GetAllClientsQueryHandler: IRequestHandler<GetAllClientsQuery, GetAllClientsResult>
    {

        private readonly IClientRepository _clientRepository;

        public GetAllClientsQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<GetAllClientsResult> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var skip = (request.Page - 1) * request.PageSize;


            var clients = await _clientRepository.GetAllPageAsync(skip, request.PageSize);
            var totalItems = await _clientRepository.CountAsync();
            var response = clients.Select(c => new ClientResponse
            {
                PublicId = c.PublicId,
                Name = c.Name,
                Phone = c.Phone,
                Email = c.Email.Address,
                BirthDate = c.Birthdate,
                Gender = c.Gender.ToString(),
            }).ToList();

            return new GetAllClientsResult
            {
                Items = response,
                TotalItems = totalItems,
                Page = request.Page,
                PageSize = request.PageSize,
                TotalPage = (int)Math.Ceiling(totalItems / (double)request.PageSize)
            };
        
        }
    }
}
