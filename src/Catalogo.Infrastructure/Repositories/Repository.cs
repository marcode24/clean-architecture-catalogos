using Catalogo.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infrastructure.Repositories;

internal abstract class Repository<T>(CatalogoDbContext dbContext)
  where T : Entity
{
  protected readonly CatalogoDbContext _dbContext = dbContext;

  public async Task<T?> GetById(Guid id, CancellationToken cancellationToken)
  {
    return await _dbContext.Set<T>()
      .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
  }

  public void Add(T entity)
  {
    _dbContext.Set<T>().Add(entity);
  }
}
