using Microsoft.EntityFrameworkCore;
using PropostaConsignado.Api.Dominio;
using Testcontainers.MsSql;

namespace PropostaConsignado.IntegrationTests.Setups
{
    public class DatabaseServiceSetup
    {
        private readonly MsSqlContainer _databaseContainer = default!;
        public string ConnectionString { get => _databaseContainer.GetConnectionString(); }

        public DatabaseServiceSetup()
        {
            _databaseContainer = new MsSqlBuilder()
                .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
                .WithPortBinding(6502, 1433)
                .WithPassword("iMpMLmqLlBOKl3n0")
                .WithReuse(true)
                .WithName("sqlserver-csharp-course")
                .Build();
        }

        public async Task IniciaServidorDb()
        {
            await _databaseContainer.StartAsync();
            Environment.SetEnvironmentVariable("DefaultConnection", ConnectionString);
        }

        public async static Task ExecuteMigrations(PropostaDbContext dbContext)
        {
            await dbContext.Database.MigrateAsync();
        }
    }
}