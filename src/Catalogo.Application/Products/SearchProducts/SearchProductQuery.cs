using Catalogo.Domain.Products;
using MediatR;

namespace Catalogo.Application.Products.SearchProducts;

public sealed class SearchProductQuery : IRequest<Product>
{
  public string? Code { get; set; }
}
