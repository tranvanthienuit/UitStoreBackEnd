using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.factory;
using UitStoreBackEnd.filter;

namespace UitStoreBackEnd.Controllers;

public interface IProductController
{
    Task<IActionResult> create(Product product);

    Task<IActionResult> getDetailById(Guid id);

    Task<IActionResult> update(Product product);

    Task<IActionResult> delete(Guid id);

    Task<IActionResult> getList();

    Task<IActionResult> getPage(ProductFilter productFilter);
}

[Route("/api/v1/product")]
public class ProductController : Controller, IProductController
{
    private readonly IProductFactory iProductFactory;

    public ProductController(IProductFactory iProductFactory)
    {
        this.iProductFactory = iProductFactory;
    }

    [HttpPost("create")]
    public async Task<IActionResult> create([FromBody] Product product)
    {
        return Ok(await iProductFactory.create(product));
    }

    [HttpGet("{id}/detail")]
    public async Task<IActionResult> getDetailById(Guid id)
    {
        return Ok(await iProductFactory.getDetail(id));
    }

    [HttpPut("update")]
    public async Task<IActionResult> update([FromBody] Product product)
    {
        return Ok(await iProductFactory.update(product));
    }

    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> delete(Guid id)
    {
        return Ok(await iProductFactory.deleteById(id));
    }

    [HttpGet("list")]
    public async Task<IActionResult> getList()
    {
        return Ok(await iProductFactory.getList());
    }

    [HttpPost("page")]
    public async Task<IActionResult> getPage([FromBody] ProductFilter productFilter)
    {
        return Ok(await iProductFactory.getPage(productFilter));
    }
}