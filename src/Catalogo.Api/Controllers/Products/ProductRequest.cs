namespace Catalogo.Api.Controllers.Products;

public sealed record ProductRequest(
  string Nombre,
  string Descripcion,
  decimal Precio,
  Guid CategoriaId
);
