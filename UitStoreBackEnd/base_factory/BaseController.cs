using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.base_factory.response;

namespace UitStoreBackEnd.base_factory;

public interface IBaseController<I, DT, F>
{
    Task<BaseResponse<DT>> create(DT DT);

    Task<BaseResponse<bool>> deleteById(I ID);

    Task<BaseResponse<DT>> update(DT DT);

    Task<BaseResponse<DT>> getDetailById(I ID);

    Task<BaseResponse<List<DT>>> getList();

    Task<BaseResponse<List<DT>>> getPage(F Filter);
}

public abstract class BaseController<I, DT, F> : ControllerBase
{
    protected readonly IBaseFactory<I, DT, F> _baseFactory;
    protected readonly IResponseFactory _responseFactory;

    protected BaseController(IBaseFactory<I, DT, F> baseFactory, IResponseFactory responseFactory)
    {
        _baseFactory = baseFactory;
        _responseFactory = responseFactory;
    }

    protected async Task<BaseResponse<DT>> create(DT DT)
    {
        try
        {
            return await _responseFactory.successModel(await _baseFactory.create(DT));
        }
        catch (Exception e)
        {
            return await _responseFactory.error<DT>(e.Message);
        }
    }

    protected async Task<BaseResponse<bool>> deleteById(I ID)
    {
        try
        {
            return await _responseFactory.delete(await _baseFactory.deleteById(ID));
        }
        catch (Exception e)
        {
            return await _responseFactory.error<bool>(e.Message);
        }
    }

    protected async Task<BaseResponse<DT>> update(DT DT)
    {
        try
        {
            return await _responseFactory.successModel(await _baseFactory.update(DT));
        }
        catch (Exception e)
        {
            return await _responseFactory.error<DT>(e.Message);
        }
    }


    protected async Task<BaseResponse<DT>> getDetailById(I ID)
    {
        try
        {
            return await _responseFactory.successModel(await _baseFactory.getDetailById(ID));
        }
        catch (Exception e)
        {
            return await _responseFactory.error<DT>(e.Message);
        }
    }


    protected async Task<BaseResponse<List<DT>>> getList()
    {
        try
        {
            return await _responseFactory.successList(await _baseFactory.getList());
        }
        catch (Exception e)
        {
            return await _responseFactory.error<List<DT>>(e.Message);
        }
    }

    protected async Task<BaseResponse<List<DT>>> getPage(F Filter)
    {
        try
        {
            return await _responseFactory.successList(await _baseFactory.getPage(Filter));
        }
        catch (Exception e)
        {
            return await _responseFactory.error<List<DT>>(e.Message);
        }
    }
}