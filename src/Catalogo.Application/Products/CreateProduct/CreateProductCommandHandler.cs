using Catalogo.Domain.Abstractions;
using Catalogo.Domain.Products;
using MediatR;

namespace Catalogo.Application.Products.CreateProduct;

internal sealed class CreateProductCommandHandler
  : IRequestHandler<CreateProductCommand, Guid>
{
  private readonly IProductRepository _productRepository;
  private readonly IUnitOfWork _unitOfWork;

  public CreateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork)
  {
    _productRepository = productRepository;
    _unitOfWork = unitOfWork;
  }

  public async Task<Guid> Handle(
    CreateProductCommand request,
    CancellationToken cancellationToken)
  {
    var productNew = Product.Create(
      request.Name,
      request.Price,
      request.Description,
      null!,
      null!,
      request.CategoryId
    );

    _productRepository.Add(productNew);
    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return productNew.Id;
  }
}
