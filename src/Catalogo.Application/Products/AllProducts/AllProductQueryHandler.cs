using Catalogo.Application.Dtos;
using Catalogo.Domain.Products;
using MediatR;

namespace Catalogo.Application.Products.AllProducts;

internal sealed class AllProductQueryHandler
  : IRequestHandler<AllProductQuery, List<ProductDTO>>
{
  private readonly IProductRepository _productRepository;

  public AllProductQueryHandler(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }

  public async Task<List<ProductDTO>> Handle(
    AllProductQuery request,
    CancellationToken cancellationToken)
  {
    var products = await _productRepository.GetAll(cancellationToken);
    return products.ConvertAll(product => product.ToDto(request.HttpContext!));
  }
}
