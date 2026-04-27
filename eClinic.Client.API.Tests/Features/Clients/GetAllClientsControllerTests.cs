using eClinic.Client.Application.Features.Clients.Create;
using eClinic.Client.Application.Features.Clients.GetAll;
using eClinic.Client.Domain.Enums;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Xunit;

namespace eClinic.Client.API.Tests.Features.Clients
{
    public class GetAllClientsControllerTests : IClassFixture<EClinicFactory>
    {
        private readonly HttpClient _client;

        public GetAllClientsControllerTests(EClinicFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_DeveRetornarAllClients_QuandoDadosForemValidos()
        {
            // Arrange
            var url = QueryHelpers.AddQueryString("/api/clients", new Dictionary<string, string?>
            {
                ["page"] = "1",
                ["pageSize"] = "10"
            });

            // Act
            var response = await _client.GetAsync(url);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            Assert.NotNull(content);
        }
    }
}
