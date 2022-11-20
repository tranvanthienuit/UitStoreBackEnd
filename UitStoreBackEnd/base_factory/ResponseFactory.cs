using System.Net;
using System.Web.Http;
using UitStoreBackEnd.base_factory.response;

namespace UitStoreBackEnd.base_factory;

public interface IResponseFactory
{
    Task<HttpResponseMessage> successModel<DT>(DT dt);

    Task<HttpResponseMessage> successList<DT>(List<DT> List);

    Task<HttpResponseMessage> error(string exception);

    Task<HttpResponseMessage> delete(bool result);
}

public class ResponseFactory : ApiController, IResponseFactory
{
    public async Task<HttpResponseMessage> successModel<DT>(DT dt)
    {
        var response = new BaseResponse<DT>();
        response.success = true;
        response.data = dt;
        return Request.CreateResponse(HttpStatusCode.OK, response);
    }

    public async Task<HttpResponseMessage> successList<DT>(List<DT> list)
    {
        var response = new BaseResponse<List<DT>>();
        response.success = true;
        response.data = list;
        return Request.CreateResponse(HttpStatusCode.OK, response);
    }

    public async Task<HttpResponseMessage> error(string exception)
    {
        var response = new BaseResponse<string>();
        response.data = exception;
        response.success = false;
        return Request.CreateResponse(HttpStatusCode.OK, response);
    }

    public async Task<HttpResponseMessage> delete(bool result)
    {
        var response = new DeleteResponse();
        response.success = result;
        return Request.CreateResponse(HttpStatusCode.OK, response);
    }
}