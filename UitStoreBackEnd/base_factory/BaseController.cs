using System.Web.Http;

namespace UitStoreBackEnd.base_factory;

public interface IBaseController<I, DT, F>
{
    Task<HttpResponseMessage> create(DT DT);

    Task<HttpResponseMessage> deleteById(I ID);

    Task<HttpResponseMessage> update(DT DT);

    Task<HttpResponseMessage> getDetailById(I ID);

    Task<HttpResponseMessage> getList();

    Task<HttpResponseMessage> getPage(F Filter);
}

public abstract class BaseController<I, DT, F> : ApiController
{
    protected readonly IBaseFactory<I, DT, F> _baseFactory;
    protected readonly IResponseFactory _responseFactory;

    protected BaseController(IBaseFactory<I, DT, F> baseFactory, IResponseFactory responseFactory)
    {
        _baseFactory = baseFactory;
        _responseFactory = responseFactory;
    }

    protected async Task<HttpResponseMessage> create(DT DT)
    {
        try
        {
            return await _responseFactory.successModel(await _baseFactory.create(DT));
        }
        catch (Exception e)
        {
            return Request.CreateResponse(await _responseFactory.error(e.Message));
        }
    }

    protected async Task<HttpResponseMessage> deleteById(I ID)
    {
        try
        {
            return await _responseFactory.delete(await _baseFactory.deleteById(ID));
        }
        catch (Exception e)
        {
            return await _responseFactory.error(e.Message);
        }
    }

    protected async Task<HttpResponseMessage> update(DT DT)
    {
        try
        {
            return await _responseFactory.successModel(await _baseFactory.update(DT));
        }
        catch (Exception e)
        {
            return await _responseFactory.error(e.Message);
        }
    }


    protected async Task<HttpResponseMessage> getDetailById(I ID)
    {
        try
        {
            return await _responseFactory.successModel(await _baseFactory.getDetailById(ID));
        }
        catch (Exception e)
        {
            return await _responseFactory.error(e.Message);
        }
    }


    protected async Task<HttpResponseMessage> getList()
    {
        try
        {
            return await _responseFactory.successList(await _baseFactory.getList());
        }
        catch (Exception e)
        {
            return await _responseFactory.error(e.Message);
        }
    }

    protected async Task<HttpResponseMessage> getPage(F Filter)
    {
        try
        {
            return await _responseFactory.successList(await _baseFactory.getPage(Filter));
        }
        catch (Exception e)
        {
            return await _responseFactory.error(e.Message);
        }
    }
}