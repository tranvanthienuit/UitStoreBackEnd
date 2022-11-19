using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.factory;

namespace UitStoreBackEnd.Controllers;

public interface IUserController
{
    Task<IActionResult> create(User user);

    Task<IActionResult> getDetailById(Guid id);

    Task<IActionResult> update(User user);

    Task<IActionResult> delete(Guid id);

    Task<IActionResult> getList();

    Task<IActionResult> changePassword(Guid id, string password);
}

[Route("/api/v1/user")]
public class UserController : Controller, IUserController
{
    private readonly IUserFactory iUserFactory;

    public UserController(IUserFactory iUserFactory)
    {
        this.iUserFactory = iUserFactory;
    }

    [HttpPost("create")]
    public async Task<IActionResult> create([FromBody] User user)
    {
        return Ok(await iUserFactory.create(user));
    }

    [HttpGet("{id}/detail")]
    public async Task<IActionResult> getDetailById(Guid id)
    {
        return Ok(await iUserFactory.getDetail(id));
    }

    [HttpPut("update")]
    public async Task<IActionResult> update([FromBody] User user)
    {
        return Ok(await iUserFactory.update(user));
    }

    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> delete(Guid id)
    {
        return Ok(await iUserFactory.deleteById(id));
    }

    [HttpGet("list")]
    public async Task<IActionResult> getList()
    {
        return Ok(iUserFactory.getList());
    }

    [HttpPost("{id}/change-password")]
    public async Task<IActionResult> changePassword(Guid id, [FromBody] string password)
    {
        return Ok(await iUserFactory.changePassword(id, password));
    }
}