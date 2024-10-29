using Microsoft.Extensions.DependencyInjection;
using PropostaConsignado.Api.Dominio;

namespace PropostaConsignado.IntegrationTests.Setups
{
    public class Base : IClassFixture<TesteIntegracaoSetup>, IDisposable
    {
        private readonly IServiceScope _scope;
        protected readonly PropostaDbContext _context;
        protected readonly CancellationToken _token = new();

        public Base(TesteIntegracaoSetup factory)
        {
            _scope = factory.Services.CreateScope();
            _context = _scope.ServiceProvider.GetRequiredService<PropostaDbContext>();
            DatabaseServiceSetup.ExecuteMigrations(_context).GetAwaiter().GetResult();
        }

        public void Dispose()
        {
            _scope?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}