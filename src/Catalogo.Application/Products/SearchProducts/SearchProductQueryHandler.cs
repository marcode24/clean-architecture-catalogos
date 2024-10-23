using Catalogo.Application.Dtos;
using Catalogo.Domain.Products;
using MediatR;

namespace Catalogo.Application.Products.SearchProducts;

internal sealed class SearchProductQueryHandler
  : IRequestHandler<SearchProductQuery, ProductDTO>
{
  private readonly IProductRepository _productRepository;

  public SearchProductQueryHandler(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }

  public async Task<ProductDTO> Handle(
    SearchProductQuery request,
    CancellationToken cancellationToken)
  {
    var product = await _productRepository.GetByCode(request.Code!, cancellationToken);

    return product!.ToDto(request.HttpContext!);
  }
}
