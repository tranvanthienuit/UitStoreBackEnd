using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.base_factory;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.factory;
using UitStoreBackEnd.filter;
using UitStoreBackEnd.model.login;

namespace UitStoreBackEnd.Controllers;

public interface IUserController : IBaseController<Guid, User, UserFilter>
{
    Task<IActionResult> changePassword(Guid id, string password);

    Task<IActionResult> login(LoginRequest loginRequest);
}

[Route("/api/v1/user")]
public class UserController : BaseController<Guid, User, UserFilter>, IUserController
{
    private readonly IUserFactory _userFactory;

    public UserController(IUserFactory baseFactory, IResponseFactory responseFactory) : base(baseFactory,
        responseFactory)
    {
        _userFactory = baseFactory;
    }

    [HttpPost("create")]
    public Task<IActionResult> create([FromBody] User DT)
    {
        return base.create(DT);
    }

    [HttpDelete("{ID}/delete")]
    public Task<IActionResult> deleteById(Guid ID)
    {
        return base.deleteById(ID);
    }

    [HttpPut("update")]
    public Task<IActionResult> update([FromBody] User DT)
    {
        return base.update(DT);
    }

    [HttpGet("{ID}/detail")]
    public Task<IActionResult> getDetailById(Guid ID)
    {
        return base.getDetailById(ID);
    }

    [HttpGet("list")]
    public Task<IActionResult> getList()
    {
        return base.getList();
    }

    [HttpPost("page")]
    public Task<IActionResult> getPage([FromBody] UserFilter Filter)
    {
        return base.getPage(Filter);
    }

    [HttpPost("{id}/change-password")]
    public async Task<IActionResult> changePassword(Guid id, [FromBody] string password)
    {
        return Ok(_responseFactory.successModel(await _userFactory.changePassword(id, password)));
    }

    [HttpPost("login")]
    public async Task<IActionResult> login([FromBody] LoginRequest loginRequest)
    {
        return Ok(_responseFactory.successModel(await _userFactory.login(loginRequest)));
    }
}