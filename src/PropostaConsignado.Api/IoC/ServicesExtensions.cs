using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PropostaConsignado.Api.Dominio;
using PropostaConsignado.Api.Dominio.Agentes.Aplicacao;
using PropostaConsignado.Api.Dominio.Agentes.Infraestrutura;
using PropostaConsignado.Api.Dominio.Convenios.Aplicacao;
using PropostaConsignado.Api.Dominio.Convenios.Infraestrutura;
using PropostaConsignado.Api.Dominio.Operacao.Aplicacao;
using PropostaConsignado.Api.Dominio.Operacao.Infraestrutura;
using PropostaConsignado.Api.Dominio.Proponentes.Infraestrutura;
using PropostaConsignado.Api.Dominio.Proposta.Aplicacao;
using PropostaConsignado.Api.Dominio.Proposta.Infraestrutura;
using PropostaConsignado.Api.Dominio.Regras.Infraestrutura;

namespace PropostaConsignado.Api.IoC
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(x => x.ToString());
                c.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey
                    }
                );

                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    }
                );

                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Proposta Consignado Api",
                        Description = "Api de Proposta consignado",
                        Version = "v1"
                    }
                );
            });
            return services;
        }

        public static void AddDependencies(this IServiceCollection services, ConfigurationManager configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PropostaDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<AgenteRepositorio>();
            services.AddScoped<ConvenioRepositorio>();
            services.AddScoped<OperacaoRepositorio>();
            services.AddScoped<PropostaRepositorio>();
            services.AddScoped<RegraRepositorio>();
            services.AddScoped<ProponenteRepositorio>();

            services.AddScoped<CriarAgenteHandler>();
            services.AddScoped<CriarConvenioHandler>();
            services.AddScoped<CriarOperacaoHandler>();
            services.AddScoped<CriarPropostaHandler>();
        }

        public static void AddMediaTR(this IServiceCollection services)
        {
            string applicationAssemblyName = Assembly.GetExecutingAssembly().GetName().Name!;
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
        }
    }
}