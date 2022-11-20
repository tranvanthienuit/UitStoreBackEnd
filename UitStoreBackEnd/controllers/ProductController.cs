using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.base_factory;
using UitStoreBackEnd.base_factory.response;
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
    public Task<BaseResponse<Product>> create([FromBody] Product DT)
    {
        return base.create(DT);
    }

    [HttpDelete("{ID}/delete")]
    public Task<BaseResponse<bool>> deleteById(Guid ID)
    {
        return base.deleteById(ID);
    }

    [HttpPut("update")]
    public Task<BaseResponse<Product>> update([FromBody] Product DT)
    {
        return base.update(DT);
    }

    [HttpGet("{ID}/detail")]
    public Task<BaseResponse<Product>> getDetailById(Guid ID)
    {
        return base.getDetailById(ID);
    }

    [HttpGet("list")]
    public Task<BaseResponse<List<Product>>> getList()
    {
        return base.getList();
    }

    [HttpPost("page")]
    public Task<BaseResponse<List<Product>>> getPage([FromBody] ProductFilter Filter)
    {
        return base.getPage(Filter);
    }
}