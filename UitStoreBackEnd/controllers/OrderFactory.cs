using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.base_factory;
using UitStoreBackEnd.base_factory.response;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.factory;
using UitStoreBackEnd.filter;
using UitStoreBackEnd.model.order;

namespace UitStoreBackEnd.Controllers;

public interface IOrderController : IBaseController<Guid, Order, OrderFilter>
{
    public Task<BaseResponse<Order>> createOrder(OrderDetail orderDetail);
}

[Route("/api/v1/order")]
public class OrderController : BaseController<Guid, Order, OrderFilter>, IOrderController
{
    private readonly IOrderFactory _orderFactory;

    public OrderController(IOrderFactory baseFactory, IResponseFactory responseFactory, IOrderFactory orderFactory) :
        base(baseFactory,
            responseFactory)
    {
        _orderFactory = orderFactory;
    }

    [HttpPost("create")]
    public Task<BaseResponse<Order>> create([FromBody] Order DT)
    {
        return null;
    }

    [HttpDelete("{ID}/delete")]
    public Task<BaseResponse<bool>> deleteById(Guid ID)
    {
        return base.deleteById(ID);
    }

    [HttpPut("update")]
    public Task<BaseResponse<Order>> update([FromBody] Order DT)
    {
        return base.update(DT);
    }

    [HttpGet("{ID}/detail")]
    public Task<BaseResponse<Order>> getDetailById(Guid ID)
    {
        return base.getDetailById(ID);
    }

    [HttpGet("list")]
    public Task<BaseResponse<List<Order>>> getList()
    {
        return base.getList();
    }

    [HttpPost("{sort}/{page}/{size}/page")]
    public Task<BaseResponse<List<Order>>> getPage([FromQuery] OrderFilter Filter, string sort = "ASC", int page = 0,
        int size = 10)
    {
        return base.getPage(Filter, sort, page, size);
    }

    [HttpPost("create/order")]
    public async Task<BaseResponse<Order>> createOrder([FromBody] OrderDetail orderDetail)
    {
        try
        {
            return await _responseFactory.successModel(await _orderFactory.createOrder(orderDetail));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}