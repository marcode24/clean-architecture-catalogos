using Bogus;
using Catalogo.Domain.Categories;
using Catalogo.Domain.Products;
using Catalogo.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Api.Extensions;

public static class DataSeed
{
  public static async Task SeedCatalogoProduct(
    this IApplicationBuilder applicationBuilder
  )
  {
    using var scope = applicationBuilder.ApplicationServices.CreateScope();
    var service = scope.ServiceProvider;
    var loggerFactory = service.GetRequiredService<ILoggerFactory>();

    try
    {
      var context = service.GetRequiredService<CatalogoDbContext>();
      if (!context.Set<Category>().Any())
      {
        var categoryComputadora = Category.Create("Computadora");
        var categoryTelefono = Category.Create("Teléfono");

        context.AddRange(categoryComputadora, categoryTelefono);

        await context.SaveChangesAsync();
      }

      if (!context.Set<Product>().Any())
      {
        var computadora = await context.Set<Category>()
          .Where(c => c.Name == "Computadora")
          .FirstOrDefaultAsync();

        var telefono = await context.Set<Category>()
          .Where(c => c.Name == "Teléfono")
          .FirstOrDefaultAsync();

        var defaultValue = 1000;
        var faker = new Faker();
        List<Product> products = [];
        for (var i = 1; i <= 10; i++)
        {
          products.Add(
            Product.Create(
              faker.Commerce.ProductName(),
              100.00m,
              faker.Commerce.ProductDescription(),
              faker.Image.PicsumUrl(),
              faker.Hashids.Encode(defaultValue, i * 1000),
              i > 5 ? computadora!.Id : telefono!.Id
            )
          );
        }

        context.AddRange(products);
        await context.SaveChangesAsync();
      }
    }
    catch (Exception ex)
    {
      var logger = loggerFactory.CreateLogger<CatalogoDbContext>();
      logger.LogError(ex, "An error occurred while seeding the database.");
    }
  }
}
