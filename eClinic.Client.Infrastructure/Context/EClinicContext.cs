using eClinic.Client.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ClientEntity = eClinic.Client.Domain.Entities.Client;

namespace eClinic.Client.Infrastructure.Context
{
    public class EClinicContext : DbContext
    {
        public EClinicContext(DbContextOptions<EClinicContext> options)
        : base(options)
        {

        }

        public DbSet<ClientEntity> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("client");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EClinicContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entity in ChangeTracker.Entries<AuditableEntity>())
            {
                if(entity.State == EntityState.Modified)
                {
                    entity.Entity.UpdateAt = DateTime.UtcNow;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
