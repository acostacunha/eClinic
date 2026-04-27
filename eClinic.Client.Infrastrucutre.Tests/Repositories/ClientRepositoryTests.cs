using Azure.Core;
using eClinic.Client.Domain.Entities;
using eClinic.Client.Domain.Enums;
using eClinic.Client.Domain.ValueObjects;
using eClinic.Client.Infrastructure.Repositories;
using eClinic.Client.Infrastrucutre.Tests.Fixtures;
using Microsoft.EntityFrameworkCore;
using Xunit;
using ClientEntity = eClinic.Client.Domain.Entities.Client;
namespace eClinic.Client.Infrastrucutre.Tests.Repositories
{
    public class ClientRepositoryTests : IClassFixture<InfrastrucureBaseFixture>
    {
        private readonly InfrastrucureBaseFixture _fixture;

        public ClientRepositoryTests(InfrastrucureBaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task AddAsync_DevePersistirClienteNoBanco()
        {
            // Arrange
            using var context = _fixture.CreateContext();
            var repository = new ClientRepository(context);
            var cpf = Cpf.Create("12345678900");
            var email = Email.Create("teste@teste.com");
            var cliente = new ClientEntity(name : "Anderson Costa", 
                            cpf : cpf,
                            email : email,
                            phone : "11999999999",
                            birtdate : new DateTime(1990, 1, 1),
                            GenderType.Male
                            );

            // Act
            await repository.AddAsync(cliente);

            // Assert
            var clienteNoBanco = await context.Set<ClientEntity>().FirstOrDefaultAsync();
            Assert.NotNull(clienteNoBanco);
            Assert.Equal("Anderson Costa", clienteNoBanco.Name);
        }

        [Theory]
        [InlineData(15, 0, 10, 10)] // 15 itens, skip 0, take 10 -> retorna 10
        [InlineData(15, 10, 10, 5)] // 15 itens, skip 10, take 10 -> retorna 5
        public async Task GetAllPageAsync_DeveRetornarQuantidadeCorreta(int total, int skip, int take, int esperado)
        {
            // Arrange
            using var context = _fixture.CreateContext();
            for (int i = 0; i < total; i++)
            {

                var cpf = Cpf.Create($"{i}");
                var email = Email.Create($"teste{i}@teste.com");
                var cliente = new ClientEntity(name: $"Cliente {i}",
                cpf: cpf,
                email: email,
                phone: "11999999999",
                birtdate: new DateTime(1990, 1, 1),
                GenderType.Male
                );

                context.Set<ClientEntity>().Add(cliente);
            }
            await context.SaveChangesAsync();

            var repository = new ClientRepository(context);

            // Act
            var result = await repository.GetAllPageAsync(skip, take);

            // Assert
            Assert.Equal(esperado, result.Count());
        }
    }
}
