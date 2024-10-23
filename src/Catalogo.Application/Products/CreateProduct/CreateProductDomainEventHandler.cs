using Catalogo.Domain.Products.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalogo.Application.Products.CreateProduct;

internal sealed class CreateProductDomainEventHandler
  : INotificationHandler<ProductCreatedDomainEvent>
{
  private readonly ILogger _logger;

  public CreateProductDomainEventHandler(ILoggerFactory loggerFactory)
  {
    _logger = loggerFactory.CreateLogger<CreateProductDomainEventHandler>();
  }

  public Task Handle(
    ProductCreatedDomainEvent notification,
    CancellationToken cancellationToken)
  {
    _logger.LogInformation(
      "Product created with id: {ProductId}",
      notification.ProductId);

    return Task.CompletedTask;
  }
}
