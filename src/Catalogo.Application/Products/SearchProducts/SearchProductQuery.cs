using Catalogo.Application.Dtos;
using MediatR;

namespace Catalogo.Application.Products.SearchProducts;

public sealed class SearchProductQuery : IRequest<ProductDTO>
{
  public string? Code { get; set; }
}
