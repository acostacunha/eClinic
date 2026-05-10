using eClinic.Client.Application.Features.Clients.GetAll;
using eClinic.Client.Domain.Interfaces.Repositories;
using NSubstitute;
using Xunit;

namespace eClinic.Client.Application.Tests.Features.Clients.GetAll
{
    public class GetAllClientsQueryHandlerTests
    {
        private readonly IClientRepository _repositoryMock;
        private readonly GetAllClientsQueryHandler _handler;
        public GetAllClientsQueryHandlerTests()
        {
            _repositoryMock = Substitute.For<IClientRepository>();
            _handler = new GetAllClientsQueryHandler(_repositoryMock);
        }

        [Fact]
        public async Task Handle_DeveChamarRepositorioComSkipETakeCorretos()
        {
            // Arrange
            var query = new GetAllClientsQuery { Page = 2, PageSize = 10 };
            int expectedSkip = 10;

            // Act
            await _handler.Handle(query, CancellationToken.None);

            // Assert
            await _repositoryMock.Received(1).GetAllPageAsync(expectedSkip, query.PageSize);
        }
    }
}
