using System.Net;
using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.base_factory;
using UitStoreBackEnd.base_factory.response;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.factory;
using UitStoreBackEnd.filter;
using UitStoreBackEnd.model.login;

namespace UitStoreBackEnd.Controllers;

public interface IUserController : IBaseController<Guid, User, UserFilter>
{
    Task<BaseResponse<User>> changePassword(Guid id, string password);

    Task<BaseResponse<User>> login(LoginRequest loginRequest);
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
    public Task<BaseResponse<User>> create([FromBody] User DT)
    {
        return base.create(DT);
    }

    [HttpDelete("{ID}/delete")]
    public Task<BaseResponse<bool>> deleteById(Guid ID)
    {
        return base.deleteById(ID);
    }

    [HttpPut("update")]
    public Task<BaseResponse<User>> update([FromBody] User DT)
    {
        return base.update(DT);
    }

    [HttpGet("{ID}/detail")]
    public Task<BaseResponse<User>> getDetailById(Guid ID)
    {
        return base.getDetailById(ID);
    }

    [HttpGet("list")]
    public Task<BaseResponse<List<User>>> getList()
    {
        return base.getList();
    }

    [HttpPost("page")]
    public Task<BaseResponse<List<User>>> getPage([FromBody] UserFilter Filter)
    {
        return base.getPage(Filter);
    }

    [HttpPost("{id}/change-password")]
    public async Task<BaseResponse<User>> changePassword(Guid id, [FromBody] string password)
    {
        try
        {
            return await _responseFactory.successModel(await _userFactory.changePassword(id, password));
        }
        catch (Exception e)
        {
            return await _responseFactory.error<User>(e.Message);
        }
    }

    [HttpPost("login")]
    public async Task<BaseResponse<User>> login([FromBody] LoginRequest loginRequest)
    {
        try
        {
            return await _responseFactory.successModel(await _userFactory.login(loginRequest));
        }
        catch (Exception e)
        {
            return await _responseFactory.error<User>(e.Message);
        }
    }
}