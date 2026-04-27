using eClinic.Client.Application.Features.Clients.Create;
using eClinic.Client.Domain.Enums;
using eClinic.Client.Domain.Interfaces.Repositories;
using eClinic.Client.Domain.ValueObjects;
using NSubstitute;
using Xunit;
using ClientEntity = eClinic.Client.Domain.Entities.Client;

namespace eClinic.Client.Application.Tests.Features.Clients.Create
{
    public class CreateClientCommandHandlerTests
    {
        private readonly IClientRepository _repositoryMock;
        private readonly CreateClientCommandHandler _handler;

        public CreateClientCommandHandlerTests()
        {
            _repositoryMock = Substitute.For<IClientRepository>();
            _handler = new CreateClientCommandHandler(_repositoryMock);
        }

        [Fact]
        public async Task Handle_DeveCriarClienteERetornarSucesso()
        {
            // Arrange
            var command = new CreateClientCommand
            {
                Name = "Anderson Costa",
                Cpf = "12345678900",
                Email = "teste@eclinic.com"
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            await _repositoryMock.Received(1).AddAsync(Arg.Any<ClientEntity>());
        }

        [Fact]
        public async Task Handle_DeveRetornarErroQuandoCpfJaExistir()
        {
            // Arrange
            var command = new CreateClientCommand
            {
                Name = "Anderson Costa",
                Cpf = "12345678900",
                Email = "teste@eclinic.com"
            };

            var existingClient = new ClientEntity(
                "Existing Client",
                Cpf.Create("12345678900"),
                Email.Create("existing@eclinic.com"),
                "1111111111",
                DateTime.UtcNow,
                GenderType.Male);

            _repositoryMock.GetByCpfAsync(command.Cpf).Returns(existingClient);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Já existe um cliente cadastrado com este CPF", result.Error);
        }

    }
}
