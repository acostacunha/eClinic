using eClinic.Client.Application.Features.Clients.Update;
using eClinic.Client.Domain.Enums;
using eClinic.Client.Domain.ValueObjects;
using eClinic.Client.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http.Json;
using Xunit;
using ClientEntity = eClinic.Client.Domain.Entities.Client;

namespace eClinic.Client.API.Tests.Features.Clients
{
    public class UpdateClientControllerTests : IClassFixture<EClinicFactory>
    {
        private readonly HttpClient _client;
        private readonly EClinicFactory _factory;

        public UpdateClientControllerTests(EClinicFactory factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Post_DeveRetornarCreated_QuandoDadosForemValidos()
        {
            // Arrange
            using var scope = _factory.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<EClinicContext>();

            var client = context.Clients.Add(new ClientEntity(            
                name : "Nome Original",
                cpf : Cpf.Create("12345678900"),
                email : Email.Create("original@eclinic.com"),
                birthdate : DateTime.Now,
                gender : GenderType.Male,
                phone : "11 0000000"
            ));

            await context.SaveChangesAsync();

            var publicId = client.Entity.PublicId;
            var command = new UpdateClientCommand
            {
                PublicId = publicId,
                Name = "Anderson Costa",
                Email = "teste@eclinic.com",
                Birthdate = DateTime.Now,
                Gender = GenderType.Male,
                Phone = "11 1111111"
            };

            // Act
            var response = await _client.PutAsJsonAsync("/api/client", command);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("", content);
        }
    }
}
