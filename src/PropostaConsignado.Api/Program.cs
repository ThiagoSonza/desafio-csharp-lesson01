using System.Text.Json.Serialization;
using PropostaConsignado.Api.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDoc();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(options => options.ModelValidatorProviders.Clear())
                .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
builder.Services.AddDependencies(builder.Configuration);
builder.Services.AddMediaTR();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();