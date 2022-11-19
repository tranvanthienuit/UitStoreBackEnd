using Microsoft.AspNetCore.Mvc;

namespace UitStoreBackEnd.base_factory;

public interface IBaseController<I, DT, F>
{
    Task<IActionResult> create(DT DT);

    Task<IActionResult> deleteById(I ID);

    Task<IActionResult> update(DT DT);

    Task<IActionResult> getDetailById(I ID);

    Task<IActionResult> getList();

    Task<IActionResult> getPage(F Filter);
}

public abstract class BaseController<I, DT, F> : Controller
{
    protected readonly IBaseFactory<I, DT, F> _baseFactory;
    protected readonly IResponseFactory _responseFactory;

    protected BaseController(IBaseFactory<I, DT, F> baseFactory, IResponseFactory responseFactory)
    {
        _baseFactory = baseFactory;
        _responseFactory = responseFactory;
    }

    protected async Task<IActionResult> create(DT DT)
    {
        try
        {
            return Ok(_responseFactory.successModel(await _baseFactory.create(DT)));
        }
        catch (Exception e)
        {
            return Ok(_responseFactory.error(e.Message));
        }
    }

    protected async Task<IActionResult> deleteById(I ID)
    {
        try
        {
            return Ok(_responseFactory.delete(await _baseFactory.deleteById(ID)));
        }
        catch (Exception e)
        {
            return Ok(_responseFactory.error(e.Message));
        }
    }

    protected async Task<IActionResult> update(DT DT)
    {
        try
        {
            return Ok(_responseFactory.successModel(await _baseFactory.update(DT)));
        }
        catch (Exception e)
        {
            return Ok(_responseFactory.error(e.Message));
        }
    }


    protected async Task<IActionResult> getDetailById(I ID)
    {
        try
        {
            return Ok(_responseFactory.successModel(await _baseFactory.getDetailById(ID)));
        }
        catch (Exception e)
        {
            return Ok(_responseFactory.error(e.Message));
        }
    }


    protected async Task<IActionResult> getList()
    {
        try
        {
            return Ok(_responseFactory.successList(await _baseFactory.getList()));
        }
        catch (Exception e)
        {
            return Ok(_responseFactory.error(e.Message));
        }
    }

    protected async Task<IActionResult> getPage(F Filter)
    {
        try
        {
            return Ok(_responseFactory.successList(await _baseFactory.getPage(Filter)));
        }
        catch (Exception e)
        {
            return Ok(_responseFactory.error(e.Message));
        }
    }
}