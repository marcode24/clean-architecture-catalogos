using Catalogo.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infrastructure;

public sealed class CatalogoDbContext : DbContext, IUnitOfWork
{

  private readonly IPublisher _publisher;
  public CatalogoDbContext(
    DbContextOptions options,
    IPublisher publisher
    ) : base(options)
  {
    _publisher = publisher;
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoDbContext).Assembly);
    base.OnModelCreating(modelBuilder);
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    var results = await base.SaveChangesAsync(cancellationToken);
    await PublishNotifications();
    return results;
  }

  private async Task PublishNotifications()
  {
    var domainEventNotifications = ChangeTracker
      .Entries<Entity>()
      .Select(entry => entry.Entity)
      .SelectMany(entity =>
      {
        var eventNotifications = entity.GetDomainEvents();
        entity.ClearDomainEvents();
        return eventNotifications;
      })
      .ToList();

    foreach (var eventNotification in domainEventNotifications)
      await _publisher.Publish(eventNotification);

  }
}
