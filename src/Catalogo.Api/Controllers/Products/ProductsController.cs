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

  [HttpGet("code")]
  public async Task<IActionResult> GetByCode(string code)
  {
    var query = new SearchProductQuery { Code = code };
    var product = await _sender.Send(query);

    return Ok(product);
  }
}
