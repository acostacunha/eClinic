using eClinic.Client.Application.Features.Clients.GetById;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Xunit;

namespace eClinic.Client.API.Tests.Features.Clients
{
    public class GetClientByPublicIdTests : IClassFixture<EClinicFactory>
    {
        private readonly HttpClient _client;

        public GetClientByPublicIdTests(EClinicFactory factory)
        {
            _client = factory.CreateClient();            
        }

        [Fact]
        public async Task Get_DeveRetornarClient_QuandoDadosForemValidos()
        {
            var publicId = await CriarClienteAsync();
            // Act
            var response = await _client.GetAsync($"/api/client?publicId={publicId}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains(publicId, content);
        }


        [Fact]
        public async Task Get_DeveRetornarErro_QuandoDadosNaoForemValidos()
        {
            var publicId = Guid.NewGuid().ToString();
            // Act
            var response = await _client.GetAsync($"/api/client?publicId={publicId}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Cliente não encontrado", content);

        }
        private async Task<string> CriarClienteAsync()
        {
            var command = new
            {
                Name = "Anderson Costa",
                Cpf = "12345678900",
                Email = "teste@eclinic.com",
                Phone = "11999999999",
                BirthDate = "1990-01-01",
                Gender = 1
            };

            var createResponse = await _client.PostAsJsonAsync("/api/client", command);
            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

            var createContent = await createResponse.Content.ReadAsStringAsync();
            var created = JsonSerializer.Deserialize<JsonElement>(createContent);

            return created.GetProperty("publicId").GetString();
        }
    }
}
