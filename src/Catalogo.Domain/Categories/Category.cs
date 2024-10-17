using Catalogo.Domain.Abstractions;
using Catalogo.Domain.Categories.Events;

namespace Catalogo.Domain.Categories;

public sealed class Category : Entity
{
  public string? Name { get; private set; }
  private Category(Guid id, string name) : base(id)
  {
    Name = name;
  }
  public static Category Create(string name)
  {
    var category = new Category(Guid.NewGuid(), name);
    var categoryDomainEvent = new CategoryCreatedDomainEvent(category.Id);
    category.RaiseDomainEvent(categoryDomainEvent);
    return category;
  }
}
