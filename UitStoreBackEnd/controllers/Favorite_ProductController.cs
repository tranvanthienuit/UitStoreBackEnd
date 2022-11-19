using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.base_factory;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.factory;
using UitStoreBackEnd.filter;

namespace UitStoreBackEnd.Controllers;

public interface IFavorite_ProductController : IBaseController<Guid, Favorite_Product, FavoriteProductFilter>
{
}

[Route("/api/v1/favorite-product")]
public class FavoriteProductController : BaseController<Guid, Favorite_Product, FavoriteProductFilter>,
    IFavorite_ProductController
{
    public FavoriteProductController(IFavorite_ProductFactory baseFactory, IResponseFactory responseFactory) : base(
        baseFactory, responseFactory)
    {
    }

    [HttpPost("create")]
    public Task<IActionResult> create([FromBody] Favorite_Product DT)
    {
        return base.create(DT);
    }

    [HttpDelete("{ID}/delete")]
    public Task<IActionResult> deleteById(Guid ID)
    {
        return base.deleteById(ID);
    }

    [HttpPut("update")]
    public Task<IActionResult> update([FromBody] Favorite_Product DT)
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
    public Task<IActionResult> getPage([FromBody] FavoriteProductFilter Filter)
    {
        return base.getPage(Filter);
    }
}