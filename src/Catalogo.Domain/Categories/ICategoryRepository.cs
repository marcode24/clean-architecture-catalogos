namespace Catalogo.Domain.Categories;

public interface ICategoryRepository
{
  Task<List<Category>> GetAll();
  void Add(Category category);
  Task<Category> GetById(Guid id, CancellationToken cancellationToken);
}
