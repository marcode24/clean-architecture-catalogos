using Catalogo.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Catalogo.Application.Products.AllProducts;

public sealed class AllProductQuery
  : IRequest<List<ProductDTO>>
{
  public HttpContext? HttpContext { get; set; }
}
