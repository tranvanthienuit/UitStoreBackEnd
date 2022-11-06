using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.factory;

namespace UitStoreBackEnd.Controllers;

public interface ICommentController
{
    Task<IActionResult> create(Comment comment);

    Task<IActionResult> getDetailById(Guid id);

    Task<IActionResult> update(Comment comment);

    Task<IActionResult> delete(Guid id);

    Task<IActionResult> getList();
}

[Route("/api/v1/comment")]
public class CommentController : Controller, ICommentController
{
    private readonly ICommentFactory iCommentFactory;

    public CommentController(ICommentFactory iCommentFactory)
    {
        this.iCommentFactory = iCommentFactory;
    }

    [HttpPost("create")]
    public async Task<IActionResult> create([FromBody] Comment comment)
    {
        return Ok(await iCommentFactory.create(comment));
    }

    [HttpGet("{id}/detail")]
    public async Task<IActionResult> getDetailById(Guid id)
    {
        return Ok(await iCommentFactory.getDetail(id));
    }

    [HttpPut("update")]
    public async Task<IActionResult> update([FromBody] Comment comment)
    {
        return Ok(await iCommentFactory.update(comment));
    }

    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> delete(Guid id)
    {
        return Ok(await iCommentFactory.deleteById(id));
    }

    [HttpGet("list")]
    public async Task<IActionResult> getList()
    {
        return Ok(iCommentFactory.getList());
    }
}