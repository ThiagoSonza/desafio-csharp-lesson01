using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PropostaConsignado.Api.Dominio;

namespace PropostaConsignado.IntegrationTests.Setups
{
    public class TesteIntegracaoSetup : WebApplicationFactory<PropostaConsignadoApiProgram>, IAsyncLifetime
    {
        public static DatabaseServiceSetup DatabaseServidor { get; private set; } = new();
        public static HttpClient HttpClient { get; private set; } = default!;

        public async Task InitializeAsync()
        {
            await DatabaseServidor.IniciaServidorDb();
            HttpClient = CreateClient();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var descriptorType =
                    typeof(DbContextOptions<PropostaDbContext>);

                var descriptor = services
                    .SingleOrDefault(s => s.ServiceType == descriptorType);

                if (descriptor is not null)
                    services.Remove(descriptor);

                services.AddDbContext<PropostaDbContext>(options =>
                    options.UseSqlServer(DatabaseServidor.ConnectionString));
            });
        }

        Task IAsyncLifetime.DisposeAsync()
            => Task.CompletedTask;
    }
}