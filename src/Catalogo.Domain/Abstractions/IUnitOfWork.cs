namespace Catalogo.Domain.Abstractions;

public interface IUnitOfWork
{
  Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
