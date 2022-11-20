using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.base_factory;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.factory;
using UitStoreBackEnd.filter;

namespace UitStoreBackEnd.Controllers;

public interface IOrderController : IBaseController<Guid, Order, OrderFilter>
{
}

[Route("/api/v1/order")]
public class OrderController : BaseController<Guid, Order, OrderFilter>, IOrderController
{
    public OrderController(IOrderFactory baseFactory, IResponseFactory responseFactory) : base(baseFactory,
        responseFactory)
    {
    }

    [HttpPost("create")]
    public Task<HttpResponseMessage> create([FromBody] Order DT)
    {
        return base.create(DT);
    }

    [HttpDelete("{ID}/delete")]
    public Task<HttpResponseMessage> deleteById(Guid ID)
    {
        return base.deleteById(ID);
    }

    [HttpPut("update")]
    public Task<HttpResponseMessage> update([FromBody] Order DT)
    {
        return base.update(DT);
    }

    [HttpGet("{ID}/detail")]
    public Task<HttpResponseMessage> getDetailById(Guid ID)
    {
        return base.getDetailById(ID);
    }

    [HttpGet("list")]
    public Task<HttpResponseMessage> getList()
    {
        return base.getList();
    }

    [HttpPost("page")]
    public Task<HttpResponseMessage> getPage([FromBody] OrderFilter Filter)
    {
        return base.getPage(Filter);
    }
}