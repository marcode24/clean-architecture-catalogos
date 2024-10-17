using Catalogo.Domain.Abstractions;
using Catalogo.Domain.Products.Events;

namespace Catalogo.Domain.Products;

public sealed class Product : Entity
{
  public string? Name { get; set; }
  public decimal Price { get; set; }
  public string? Description { get; set; }
  public string? ImageUrl { get; set; }
  private Product(
    Guid id,
    string name,
    decimal price,
    string description,
    string imageUrl
    ) : base(id)
  {
    Name = name;
    Price = price;
    Description = description;
    ImageUrl = imageUrl;
  }

  public static Product Create(
    string name,
    decimal price,
    string description,
    string imageUrl
    )
  {
    var product = new Product(
      Guid.NewGuid(),
      name,
      price,
      description,
      imageUrl
    );
    var productDomainEvent = new ProductCreatedDomainEvent(product.Id);
    product.RaiseDomainEvent(productDomainEvent);
    return product;
  }
}