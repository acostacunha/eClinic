namespace eClinic.Shared.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(long id);
        Task<TEntity?> GetByPublicIdAsync(Guid publicId);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<int> CountAsync();

        Task<IEnumerable<TEntity>> GetAllPageAsync(int skip, int take);

    }
}
