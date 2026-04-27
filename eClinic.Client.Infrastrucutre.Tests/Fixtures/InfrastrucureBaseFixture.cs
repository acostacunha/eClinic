using eClinic.Client.Infrastructure.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace eClinic.Client.Infrastrucutre.Tests.Fixtures
{
    public class InfrastrucureBaseFixture
    {
        public EClinicContext CreateContext()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<EClinicContext>()
            .UseSqlite(connection)
            .Options;

            var context = new EClinicContext(options);
            context.Database.EnsureCreated();
            return context;
        }
    }
}
