using Catalogo.Application.Dtos;
using MediatR;

namespace Catalogo.Application.Products.AllProducts;

public sealed class AllProductQuery
  : IRequest<List<ProductDTO>>
{ }
