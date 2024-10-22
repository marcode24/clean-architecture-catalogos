namespace Catalogo.Domain.Products;

public interface IProductRepository
{
  Task<Product> GetByCode(string code);
  Task<List<Product>> GetAll();
  void Add(Product product);
  Task<Product> GetById(Guid id, CancellationToken cancellationToken);
}
