using Catalogo.Domain.Products;

namespace Catalogo.Application.Dtos;

public static class ProductMapper
{
  public static ProductDTO ToDto(this Product product)
  {
    return new ProductDTO(
      product.Id,
      product.Name!,
      product.Description!,
      product.Price,
      product.ImageUrl!,
      product.Code!,
      product.CategoryId
    );
  }
}

public sealed record ProductDTO(
  Guid Id,
  string Name,
  string Description,
  decimal Price,
  string ImageUrl,
  string Code,
  Guid CategoryId
);
