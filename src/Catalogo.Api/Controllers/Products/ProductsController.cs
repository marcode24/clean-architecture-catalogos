using Catalogo.Application.Products.AllProducts;
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
    HttpContext context = HttpContext;
    var query = new SearchProductQuery { Code = value, HttpContext = context };
    var product = await _sender.Send(query);

    return Ok(product);
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    HttpContext context = HttpContext;
    var query = new AllProductQuery { HttpContext = context };
    var products = await _sender.Send(query);

    return Ok(products);
  }
}
