using FluentValidation;

namespace Catalogo.Application.Products.CreateProduct;

public class CreateProductCommandValidator
  : AbstractValidator<CreateProductCommand>
{
  public CreateProductCommandValidator()
  {
    RuleFor(c => c.Name)
      .NotEmpty();

    RuleFor(c => c.Description)
      .NotEmpty();
  }
}
