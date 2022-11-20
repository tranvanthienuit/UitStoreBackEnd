using UitStoreBackEnd.base_factory.response;

namespace UitStoreBackEnd.base_factory;

public interface IResponseFactory
{
    Task<BaseResponse<DT>> successModel<DT>(DT dt);

    Task<BaseResponse<List<DT>>> successList<DT>(List<DT> List);

    Task<BaseResponse<DT>> error<DT>(string exception);

    Task<BaseResponse<bool>> delete(bool result);
}

public class ResponseFactory : IResponseFactory
{
    public async Task<BaseResponse<DT>> successModel<DT>(DT dt)
    {
        var response = new BaseResponse<DT>();
        response.success = true;
        response.data = dt;
        return response;
    }

    public async Task<BaseResponse<List<DT>>> successList<DT>(List<DT> list)
    {
        var response = new BaseResponse<List<DT>>();
        response.success = true;
        response.data = list;
        return response;
    }

    public async Task<BaseResponse<DT>> error<DT>(string exception)
    {
        var response = new BaseResponse<DT>();
        response.data = default;
        response.success = false;
        return response;
    }

    public async Task<BaseResponse<bool>> delete(bool result)
    {
        var response = new BaseResponse<bool>();
        response.success = result;
        response.data = true;
        return response;
    }
}