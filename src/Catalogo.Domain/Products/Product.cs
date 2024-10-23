using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using Catalogo.Domain.Abstractions;
using Catalogo.Domain.Products.Events;

namespace Catalogo.Domain.Products;

public sealed class Product : Entity
{
  public string? Name { get; set; }
  public decimal Price { get; set; }
  public string? Description { get; set; }
  public string? ImageUrl { get; set; }
  public string? Code { get; set; }
  public Guid CategoryId { get; set; }
  private Product() { }
  private Product(
    Guid id,
    string name,
    decimal price,
    string description,
    string imageUrl,
    string code,
    Guid categoryId
    ) : base(id)
  {
    Name = name;
    Price = price;
    Description = description;
    ImageUrl = imageUrl;
    Code = code;
    CategoryId = categoryId;
  }

  public static Product Create(
    string name,
    decimal price,
    string description,
    string imageUrl,
    string code,
    Guid categoryId
    )
  {
    var id = Guid.NewGuid();

    if (string.IsNullOrEmpty(code))
      code = Regex.Replace(
        Convert.ToBase64String(id.ToByteArray()),
        "[/+=]", ""
      );

    var product = new Product(
      id,
      name,
      price,
      description,
      imageUrl,
      code,
      categoryId
    );

    var productDomainEvent = new ProductCreatedDomainEvent(product.Id);
    product.RaiseDomainEvent(productDomainEvent);
    return product;
  }
}
