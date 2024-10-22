using Catalogo.Api.Extensions;
using Catalogo.Infrastructure;
using Catalogo.Application;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo
  {
    Title = "Catalogo.Api",
    Version = "v1"
  });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.ApplyMigration();

app.MapControllers();

app.Run();
