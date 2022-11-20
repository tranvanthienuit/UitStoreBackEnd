using System.Net;
using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.base_factory;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.factory;
using UitStoreBackEnd.filter;
using UitStoreBackEnd.model.login;

namespace UitStoreBackEnd.Controllers;

public interface IUserController : IBaseController<Guid, User, UserFilter>
{
    Task<HttpResponseMessage> changePassword(Guid id, string password);

    Task<HttpResponseMessage> login(LoginRequest loginRequest);
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
    public Task<HttpResponseMessage> create([FromBody] User DT)
    {
        return base.create(DT);
    }

    [HttpDelete("{ID}/delete")]
    public Task<HttpResponseMessage> deleteById(Guid ID)
    {
        return base.deleteById(ID);
    }

    [HttpPut("update")]
    public Task<HttpResponseMessage> update([FromBody] User DT)
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
    public Task<HttpResponseMessage> getPage([FromBody] UserFilter Filter)
    {
        return base.getPage(Filter);
    }

    [HttpPost("{id}/change-password")]
    public async Task<HttpResponseMessage> changePassword(Guid id, [FromBody] string password)
    {
        try
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                _responseFactory.successModel(await _userFactory.changePassword(id, password)));
        }
        catch (Exception e)
        {
            return Request.CreateResponse(HttpStatusCode.OK, e.Message);
        }
    }

    [HttpPost("login")]
    public async Task<HttpResponseMessage> login([FromBody] LoginRequest loginRequest)
    {
        try
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                _responseFactory.successModel(await _userFactory.login(loginRequest)));
        }
        catch (Exception e)
        {
            return Request.CreateResponse(HttpStatusCode.OK, e.Message);
        }
    }
}