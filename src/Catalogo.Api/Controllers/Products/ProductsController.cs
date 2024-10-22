using Catalogo.Application.Products.SearchProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Api.Controllers.Products;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
  private readonly ISender _sender;

  public ProductController(ISender sender)
  {
    _sender = sender;
  }

  [HttpGet("code/{value}")]
  public async Task<IActionResult> GetByCode(string value)
  {
    var query = new SearchProductQuery { Code = value };
    var product = await _sender.Send(query);

    return Ok(product);
  }
}
