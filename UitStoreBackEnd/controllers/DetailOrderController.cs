using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.base_factory;
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
    public Task<HttpResponseMessage> create([FromBody] DetailOrder DT)
    {
        return base.create(DT);
    }

    [HttpDelete("{ID}/delete")]
    public Task<HttpResponseMessage> deleteById(Guid ID)
    {
        return base.deleteById(ID);
    }

    [HttpPut("update")]
    public Task<HttpResponseMessage> update([FromBody] DetailOrder DT)
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
    public Task<HttpResponseMessage> getPage([FromBody] DetailOrderFilter Filter)
    {
        return base.getPage(Filter);
    }
}