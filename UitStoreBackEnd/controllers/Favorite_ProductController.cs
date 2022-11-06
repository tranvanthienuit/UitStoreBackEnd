using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.factory;

namespace UitStoreBackEnd.Controllers;

public interface IFavorite_ProductController
{
    Task<IActionResult> create(Favorite_Product favoriteProduct);

    Task<IActionResult> getDetailById(Guid id);

    Task<IActionResult> update(Favorite_Product favoriteProduct);

    Task<IActionResult> delete(Guid id);

    Task<IActionResult> getList();
}

[Route("/api/v1/favorite-product")]
public class Favorite_ProductController : Controller, IFavorite_ProductController
{
    private readonly IFavorite_ProductFactory iFavorite_ProductFactory;

    public Favorite_ProductController(IFavorite_ProductFactory iFavorite_ProductFactory)
    {
        this.iFavorite_ProductFactory = iFavorite_ProductFactory;
    }

    [HttpPost("create")]
    public async Task<IActionResult> create([FromBody] Favorite_Product favoriteProduct)
    {
        return Ok(await iFavorite_ProductFactory.create(favoriteProduct));
    }

    [HttpGet("{id}/detail")]
    public async Task<IActionResult> getDetailById(Guid id)
    {
        return Ok(await iFavorite_ProductFactory.getDetail(id));
    }

    [HttpPut("update")]
    public async Task<IActionResult> update([FromBody] Favorite_Product favoriteProduct)
    {
        return Ok(await iFavorite_ProductFactory.update(favoriteProduct));
    }

    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> delete(Guid id)
    {
        return Ok(await iFavorite_ProductFactory.deleteById(id));
    }

    [HttpGet("list")]
    public async Task<IActionResult> getList()
    {
        return Ok(iFavorite_ProductFactory.getList());
    }
}