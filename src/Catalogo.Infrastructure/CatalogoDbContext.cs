using Catalogo.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infrastructure;

public sealed class CatalogoDbContext : DbContext, IUnitOfWork
{
  public CatalogoDbContext(DbContextOptions options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoDbContext).Assembly);
    base.OnModelCreating(modelBuilder);
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    var results = await base.SaveChangesAsync(cancellationToken);
    return results;
  }
}
