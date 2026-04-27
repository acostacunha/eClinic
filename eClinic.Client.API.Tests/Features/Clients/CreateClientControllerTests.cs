using eClinic.Client.Application.Features.Clients.Create;
using eClinic.Client.Domain.Enums;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace eClinic.Client.API.Tests.Features.Clients
{
    public class CreateClientControllerTests : IClassFixture<EClinicFactory>
    {
        private readonly HttpClient _client;

        public CreateClientControllerTests(EClinicFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Post_DeveRetornarCreated_QuandoDadosForemValidos()
        {
            // Arrange
            var command = new CreateClientCommand
            {
                Name = "Anderson Costa",
                Cpf = "12345678900",
                Email = "teste@eclinic.com",
                Phone = "11999999999",
                Birthdate = DateTime.Now,
                Gender = GenderType.Male
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/client", command);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("-", content);
        }
    }
}
