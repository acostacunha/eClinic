using eClinic.Client.Domain.Interfaces.Repositories;
using eClinic.Client.Infrastructure.Context;
using eClinic.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using ClientEntity = eClinic.Client.Domain.Entities.Client;

namespace eClinic.Client.Infrastructure.Repositories
{
    public class ClientRepository : IBaseRepository<ClientEntity>, IClientRepository
    {
        protected readonly EClinicContext _context;
        public ClientRepository(EClinicContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ClientEntity entity)
        {
            _context.Set<ClientEntity>().Add(entity);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(ClientEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public async Task DeleteAsync(ClientEntity entity)
        {
            _context.Set<ClientEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<ClientEntity>> GetAllAsync()
        {
            return _context.Set<ClientEntity>().AsNoTracking().ToList();
        }
        public async Task<ClientEntity?> GetByCpfAsync(string cpf)
        {
            return _context.Set<ClientEntity>().FirstOrDefault(x => x.Cpf.CpfNumber == cpf);
        }

        public async Task<ClientEntity?> GetByIdAsync(long id)
        {
            return _context.Set<ClientEntity>().FirstOrDefault(x => x.Id == id);
        }

        public async Task<ClientEntity?> GetByName(string name)
        {
            return _context.Set<ClientEntity>().FirstOrDefault(x => x.Name == name);
        }

        public async Task<ClientEntity?> GetByPublicIdAsync(Guid publicId)
        {
            return _context.Set<ClientEntity>().FirstOrDefault(x => x.PublicId == publicId);
        }

        public Task<int> CountAsync()
        {
            return _context.Set<ClientEntity>().AsNoTracking().CountAsync();
        }

        public async Task<IEnumerable<ClientEntity>> GetAllPageAsync(int skip, int take)
        {
            return await _context
                .Set<ClientEntity>()
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
    }
}
