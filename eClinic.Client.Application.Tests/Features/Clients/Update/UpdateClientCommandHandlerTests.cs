using eClinic.Client.Application.Features.Clients.Update;
using eClinic.Client.Domain.Enums;
using eClinic.Client.Domain.Interfaces.Repositories;
using eClinic.Client.Domain.ValueObjects;
using NSubstitute;
using Xunit;
using ClientEntity = eClinic.Client.Domain.Entities.Client;

namespace eClinic.Client.Application.Tests.Features.Clients.Update
{
    public class UpdateClientCommandHandlerTests
    {
        private readonly IClientRepository _repositoryMock;
        private readonly UpdateClientCommandHandler _handler;

        public UpdateClientCommandHandlerTests()
        {
            _repositoryMock = Substitute.For<IClientRepository>();
            _handler = new UpdateClientCommandHandler(_repositoryMock);            
        }
        
        [Fact]
        public async Task Handle_DeveAtualizarClienteERetornarSucesso()
        {
            // Arrange
            var emailExpect = "teste@eclinic.com";
            var command = new UpdateClientCommand
            {
                PublicId = new Guid("72A392B4-8E1F-4C5D-AE9A-569B82314F17"),
                Name = "Anderson Costa",
                Email = "teste@eclinic.com"
            };
            _repositoryMock.GetByPublicIdAsync(Arg.Any<Guid>()).Returns(CreateExistingClient());

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            await _repositoryMock.Received(1).UpdateAsync(Arg.Is<ClientEntity>(x => x.Email.Address.Equals(emailExpect)));
        }

        [Fact]
        public async Task Handle_NaoDeveAtualizarClienteERetornarFailure()
        {
            // Arrange
            var command = new UpdateClientCommand
            {
                PublicId = new Guid("72A392B4-8E1F-4C5D-AE9A-569B82314F17"),
                Name = "Anderson Costa",
                Email = "teste@eclinic.com"
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            await _repositoryMock.Received(0).UpdateAsync(Arg.Any<ClientEntity>());
        }
        private ClientEntity CreateExistingClient()
        {

            return new ClientEntity(
                "Existing Client",
                Cpf.Create("12345678900"),
                Email.Create("existing@eclinic.com"),
                "123456789",
                new DateTime(1990, 1, 1),
                GenderType.Male
                );
        }
    }
}
