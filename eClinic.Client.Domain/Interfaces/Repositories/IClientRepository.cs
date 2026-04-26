using eClinic.Shared.Interfaces;
using ClientEntity = eClinic.Client.Domain.Entities.Client;

namespace eClinic.Client.Domain.Interfaces.Repositories
{
    public interface IClientRepository: IBaseRepository<ClientEntity>
    {
        Task<ClientEntity?> GetByCpfAsync(string cpf);
        Task<ClientEntity?> GetByName(string name);

    }
}
