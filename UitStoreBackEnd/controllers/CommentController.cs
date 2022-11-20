using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.base_factory;
using UitStoreBackEnd.base_factory.response;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.factory;
using UitStoreBackEnd.filter;

namespace UitStoreBackEnd.Controllers;

public interface ICommentController : IBaseController<Guid, Comment, CommentFilter>
{
}

[Route("/api/v1/comment")]
public class CommentController : BaseController<Guid, Comment, CommentFilter>, ICommentController
{
    public CommentController(ICommentFactory baseFactory, IResponseFactory responseFactory) : base(baseFactory,
        responseFactory)
    {
    }

    [HttpPost("create")]
    public Task<BaseResponse<Comment>> create([FromBody] Comment DT)
    {
        return base.create(DT);
    }

    [HttpDelete("{ID}/delete")]
    public Task<BaseResponse<bool>> deleteById(Guid ID)
    {
        return base.deleteById(ID);
    }

    [HttpPut("update")]
    public Task<BaseResponse<Comment>> update([FromBody] Comment DT)
    {
        return base.update(DT);
    }

    [HttpGet("{ID}/detail")]
    public Task<BaseResponse<Comment>> getDetailById(Guid ID)
    {
        return base.getDetailById(ID);
    }

    [HttpGet("list")]
    public Task<BaseResponse<List<Comment>>> getList()
    {
        return base.getList();
    }

    [HttpPost("{sort}/{page}/{size}/page")]
    public Task<BaseResponse<List<Comment>>> getPage([FromQuery] CommentFilter Filter, string sort = "ASC",
        int page = 0, int size = 10)
    {
        return base.getPage(Filter, sort, page, size);
    }
}