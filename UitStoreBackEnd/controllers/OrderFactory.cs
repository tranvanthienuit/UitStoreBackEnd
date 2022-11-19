using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.factory;
using UitStoreBackEnd.filter;

namespace UitStoreBackEnd.Controllers;

public interface IOrderController
{
    Task<IActionResult> create(Order order);

    Task<IActionResult> getDetailById(Guid id);

    Task<IActionResult> update(Order order);

    Task<IActionResult> delete(Guid id);

    Task<IActionResult> getList();

    Task<IActionResult> getPage(OrderFilter orderFilter);
}

[Route("/api/v1/order")]
public class OrderController : Controller, IOrderController
{
    private readonly IOrderFactory iOrderFactory;

    public OrderController(IOrderFactory iOrderFactory)
    {
        this.iOrderFactory = iOrderFactory;
    }

    [HttpPost("create")]
    public async Task<IActionResult> create([FromBody] Order order)
    {
        return Ok(await iOrderFactory.create(order));
    }

    [HttpGet("{id}/detail")]
    public async Task<IActionResult> getDetailById(Guid id)
    {
        return Ok(await iOrderFactory.getDetail(id));
    }

    [HttpPut("update")]
    public async Task<IActionResult> update([FromBody] Order order)
    {
        return Ok(await iOrderFactory.update(order));
    }

    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> delete(Guid id)
    {
        return Ok(await iOrderFactory.deleteById(id));
    }

    public async Task<IActionResult> getList()
    {
        return Ok(await iOrderFactory.getList());
    }

    [HttpPost("page")]
    public async Task<IActionResult> getPage([FromBody] OrderFilter orderFilterd)
    {
        return Ok(await iOrderFactory.getPage(orderFilterd));
    }
}