using Catalogo.Domain.Products;
using Catalogo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Catalogo.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
  {
    services.AddDbContext<CatalogoDbContext>(opt =>
    {
      opt.LogTo(Console.WriteLine, [
        DbLoggerCategory.Database.Command.Name
        ], LogLevel.Information)
        .EnableSensitiveDataLogging();

      opt.UseSqlite(
        configuration.GetConnectionString("SqliteProduct")
      ).UseSnakeCaseNamingConvention();
    });

    services.AddScoped<IProductRepository, ProductRepository>();

    return services;
  }
}
