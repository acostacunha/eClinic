using eClinic.Client.Domain.ValueObjects;
using Xunit;

namespace eClinic.Client.Domain.Tests.ValueObjects
{
    public class AdressTests
    {
        [Fact]
        public void Create_ComDadosValidos_DeveRetornarSucesso()
        {
            // Arrange
            var street = "Rua A";
            var number = "123";
            var complement = "Apto 45";
            var city = "São Paulo";
            var state = "SP";
            var zipcode = "12345-678";
            // Act
            var result = Adress.Create(street, number, complement, city, state, zipcode);
            // Assert
            Assert.Equal(street, result.Street);
            Assert.Equal(number, result.Number);
            Assert.Equal(complement, result.Complement);
            Assert.Equal(city, result.City);
            Assert.Equal(state, result.State);
            Assert.Equal(zipcode, result.ZipCode);
        }
    }
}
