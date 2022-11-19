using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.base_factory.response;

namespace UitStoreBackEnd.base_factory;

public interface IResponseFactory
{
    IActionResult successModel<DT>(DT dt);

    IActionResult successList<DT>(List<DT> List);

    IActionResult error(string exception);

    IActionResult delete(bool result);
}

public class ResponseFactory : Controller, IResponseFactory
{
    public IActionResult successModel<DT>(DT dt)
    {
        var response = new BaseResponse<DT>();
        response.success = true;
        response.data = dt;
        return Ok(response);
    }

    public IActionResult successList<DT>(List<DT> list)
    {
        var response = new BaseResponse<List<DT>>();
        response.success = true;
        response.data = list;
        return Ok(response);
    }

    public IActionResult error(string exception)
    {
        var response = new BaseResponse<string>();
        response.data = exception;
        response.success = false;
        return Ok(response);
    }

    public IActionResult delete(bool result)
    {
        var response = new DeleteResponse();
        response.success = result;
        return Ok(response);
    }
}