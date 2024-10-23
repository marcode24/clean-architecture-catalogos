using MediatR;

namespace Catalogo.Application.Products.CreateProduct;

public sealed record CreateProductCommand(
  string Name,
  string Description,
  decimal Price,
  Guid CategoryId
) : IRequest<Guid>;
