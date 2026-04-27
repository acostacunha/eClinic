using eClinic.Client.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace eClinic.Client.API.Tests
{
    public class EClinicFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptorsToRemove = services
                               .Where(d =>
                                   d.ServiceType == typeof(DbContextOptions<EClinicContext>) ||
                                   d.ServiceType == typeof(DbContextOptions) ||
                                   d.ServiceType.FullName?.Contains("EntityFrameworkCore") == true ||
                                   d.ServiceType == typeof(EClinicContext))
                               .ToList();

                foreach (var descriptor in descriptorsToRemove)
                    services.Remove(descriptor);

                // Registra o InMemory limpo
                services.AddDbContext<EClinicContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryApiTest");
                });
            });
        }
    }
}
