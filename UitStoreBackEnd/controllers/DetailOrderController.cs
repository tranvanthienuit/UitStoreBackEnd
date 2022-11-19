using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.factory;
using UitStoreBackEnd.filter;

namespace UitStoreBackEnd.Controllers;

public interface IDetailOrderController
{
    Task<IActionResult> create(DetailOrder detailOrder);

    Task<IActionResult> getDetailById(Guid id);

    Task<IActionResult> update(DetailOrder detailOrder);

    Task<IActionResult> delete(Guid id);

    Task<IActionResult> getList();

    Task<IActionResult> getPage(DetailOrderFilter detailOrderFilter);
}

[Route("/api/v1/detail-order")]
public class DetailOrderController : Controller, IDetailOrderController
{
    private readonly IDetailOrderFactory iDetailOrderFactory;

    public DetailOrderController(IDetailOrderFactory iDetailOrderFactory)
    {
        this.iDetailOrderFactory = iDetailOrderFactory;
    }

    [HttpPost("create")]
    public async Task<IActionResult> create([FromBody] DetailOrder detailOrder)
    {
        return Ok(await iDetailOrderFactory.create(detailOrder));
    }

    [HttpGet("{id}/detail")]
    public async Task<IActionResult> getDetailById(Guid id)
    {
        return Ok(await iDetailOrderFactory.getDetail(id));
    }

    [HttpPut("update")]
    public async Task<IActionResult> update([FromBody] DetailOrder detailOrder)
    {
        return Ok(await iDetailOrderFactory.update(detailOrder));
    }

    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> delete(Guid id)
    {
        return Ok(await iDetailOrderFactory.deleteById(id));
    }

    [HttpGet("list")]
    public async Task<IActionResult> getList()
    {
        return Ok(iDetailOrderFactory.getList());
    }

    [HttpPost("page")]
    public async Task<IActionResult> getPage([FromBody] DetailOrderFilter detailOrderFilter)
    {
        return Ok(await iDetailOrderFactory.getPage(detailOrderFilter));
    }
}