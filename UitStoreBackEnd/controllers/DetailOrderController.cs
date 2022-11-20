using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.base_factory;
using UitStoreBackEnd.base_factory.response;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.factory;
using UitStoreBackEnd.filter;

namespace UitStoreBackEnd.Controllers;

public interface IDetailOrderController : IBaseController<Guid, DetailOrder, DetailOrderFilter>
{
}

[Route("/api/v1/detail-order")]
public class DetailOrderController : BaseController<Guid, DetailOrder, DetailOrderFilter>
{
    public DetailOrderController(IDetailOrderFactory baseFactory, IResponseFactory responseFactory) : base(baseFactory,
        responseFactory)
    {
    }

    [HttpPost("create")]
    public Task<BaseResponse<DetailOrder>> create([FromBody] DetailOrder DT)
    {
        return base.create(DT);
    }

    [HttpDelete("{ID}/delete")]
    public Task<BaseResponse<bool>> deleteById(Guid ID)
    {
        return base.deleteById(ID);
    }

    [HttpPut("update")]
    public Task<BaseResponse<DetailOrder>> update([FromBody] DetailOrder DT)
    {
        return base.update(DT);
    }

    [HttpGet("{ID}/detail")]
    public Task<BaseResponse<DetailOrder>> getDetailById(Guid ID)
    {
        return base.getDetailById(ID);
    }

    [HttpGet("list")]
    public Task<BaseResponse<List<DetailOrder>>> getList()
    {
        return base.getList();
    }

    [HttpPost("{sort}/{page}/{size}/page")]
    public Task<BaseResponse<List<DetailOrder>>> getPage([FromQuery] DetailOrderFilter Filter, string sort = "ASC",
        int page = 0, int size = 10)
    {
        return base.getPage(Filter, sort, page, size);
    }
}