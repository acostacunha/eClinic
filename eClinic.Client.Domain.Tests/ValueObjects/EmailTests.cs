using eClinic.Client.Domain.ValueObjects;
using Xunit;

namespace eClinic.Client.Domain.Tests.ValueObjects
{
    public class EmailTests
    {
        [Theory]
        [InlineData("teste@eclinic.com")]
        [InlineData("usuario@teste.com")]
        public void Create_ComEmailValido_DeveRetornarSucesso(string emailValido)
        {
            // Act
            var result = Email.Create(emailValido);

            // Assert
            Assert.Equal(emailValido, result.Address);
        }

        [Theory]
        [InlineData("")]
        [InlineData("invalid-email")]
        public void Create_ComEmailInvalido_DeveLancarExcecao(string emailInvalido)
        {
            // Assert & Act
            Assert.Throws<ArgumentException>(() => Email.Create(emailInvalido));
        }
    }
}
