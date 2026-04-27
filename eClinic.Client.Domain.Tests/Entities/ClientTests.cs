using eClinic.Client.Domain.Enums;
using eClinic.Client.Domain.ValueObjects;
using Xunit;
using ClientEntity = eClinic.Client.Domain.Entities.Client;
namespace eClinic.Client.Domain.Tests.Entities
{
    public class ClientTests
    {
        [Fact]
        public void Construtor_DeveInicializarComPublicId()
        {
            // Arrange
            var cpf = Cpf.Create("12345678900");
            var email = Email.Create("teste@eclinic.com");

            // Act
            var client = new ClientEntity("Bob", cpf, email, "11999999999", DateTime.Now.AddYears(-30), GenderType.Male);

            // Assert
            Assert.NotEqual(Guid.Empty, client.PublicId);
            Assert.True(client.Id == 0); // Id do banco ainda é zero
        }
    }
}
