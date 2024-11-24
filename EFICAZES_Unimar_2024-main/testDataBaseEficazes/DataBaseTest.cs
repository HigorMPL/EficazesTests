using Xunit;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories.Data;
using Core.Models;
using System.Linq;

public class EficazesDbContextIntegrationTests
{
    private DbContextOptions<EficazesDbContext> CreateMySqlOptions()
    {
        var connectionString = "server=localhost;user id=root;password=1234;database=eficazes";
        return new DbContextOptionsBuilder<EficazesDbContext>()
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .Options;
    }

    [Fact]
    public void DeveSalvarClienteNoBancoDeDados()
    {
        // Arrange
        var options = CreateMySqlOptions();

        using (var context = new EficazesDbContext(options))
        {
            context.Database.EnsureCreated();

            context.Clientes.RemoveRange(context.Clientes);
            context.SaveChanges();

            var cliente = new Cliente
            {
                Nome = "Ana Souza",
                Apelido = "Aninha",
                Cpf = "12345678901",
                DataNascimento = new DateTime(1992, 10, 10),
                Telefone = "14 992837564",
                Email = "ana@email.com",
                Senha = "anitta",
                Genero = "Feminino"
            };

            // Act
            context.Clientes.Add(cliente);
            context.SaveChanges();

            // Assert
            var clienteSalvo = context.Clientes.FirstOrDefault(c => c.Cpf == "12345678901");

            Assert.NotNull(clienteSalvo);
            Assert.Equal("Ana Souza", clienteSalvo.Nome);
            Assert.Equal("Aninha", clienteSalvo.Apelido);
            Assert.Equal("ana@email.com", clienteSalvo.Email);
        }
    }
}
