using eClinic.Client.Domain.ValueObjects;
using Xunit;

namespace eClinic.Client.Domain.Tests.ValueObjects
{
    public class CpfTests
    {
        [Theory]
        [InlineData("12345678900")] // Válido (supondo que seu método valide)
        [InlineData("98765432100")]
        public void Create_ComCpfValido_DeveRetornarSucesso(string cpfValido)
        {
            // Act
            var result = Cpf.Create(cpfValido);

            // Assert
            Assert.Equal(cpfValido, result.CpfNumber);
        }

        [Theory]
        [InlineData("")]
        public void Create_ComCpfInvalido_DeveLancarExcecao(string cpfInvalido)
        {
            // Assert & Act
            Assert.Throws<ArgumentException>(() => Cpf.Create(cpfInvalido));
        }
    }
}
