using Catalogo.Domain.Categories;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infrastructure.Repositories;

internal sealed class CategoryRepository : Repository<Category>, ICategoryRepository
{
  public CategoryRepository(CatalogoDbContext dbContext) : base(dbContext) { }

  public async Task<List<Category>> GetAll(CancellationToken cancellationToken)
  {
    return await (
        from c in _dbContext.Set<Category>()
        select c
      ).ToListAsync(cancellationToken);

  }
}
