using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.base_factory;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.factory;
using UitStoreBackEnd.filter;

namespace UitStoreBackEnd.Controllers;

public interface IProductController : IBaseController<Guid, Product, ProductFilter>
{
}

[Route("/api/v1/product")]
public class ProductController : BaseController<Guid, Product, ProductFilter>, IProductController
{
    public ProductController(IProductFactory baseFactory, IResponseFactory responseFactory) : base(baseFactory,
        responseFactory)
    {
    }

    [HttpPost("create")]
    public Task<IActionResult> create([FromBody] Product DT)
    {
        return base.create(DT);
    }

    [HttpDelete("{ID}/delete")]
    public Task<IActionResult> deleteById(Guid ID)
    {
        return base.deleteById(ID);
    }

    [HttpPut("update")]
    public Task<IActionResult> update([FromBody] Product DT)
    {
        return base.update(DT);
    }

    [HttpGet("{ID}/detail")]
    public Task<IActionResult> getDetailById(Guid ID)
    {
        return base.getDetailById(ID);
    }

    [HttpGet("list")]
    public Task<IActionResult> getList()
    {
        return base.getList();
    }

    [HttpPost("page")]
    public Task<IActionResult> getPage([FromBody] ProductFilter Filter)
    {
        return base.getPage(Filter);
    }
}