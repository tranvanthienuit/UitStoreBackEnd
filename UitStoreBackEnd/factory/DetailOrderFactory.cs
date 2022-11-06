using UitStoreBackEnd.db_context;
using UitStoreBackEnd.entity;

namespace UitStoreBackEnd.factory;

public interface IDetailOrderFactory
{
    Task<DetailOrder> create(DetailOrder DetailOrder);

    Task<bool> deleteById(Guid id);

    Task<DetailOrder> update(DetailOrder DetailOrder);

    Task<DetailOrder> getDetail(Guid id);

    List<DetailOrder> getList();
}

public class DetailOrderFactory : IDetailOrderFactory
{
    private readonly dbcontext _dbcontext;

    public DetailOrderFactory(dbcontext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<DetailOrder> create(DetailOrder DetailOrder)
    {
        var result = await _dbcontext.DetailOrders.AddAsync(DetailOrder);
        await _dbcontext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> deleteById(Guid id)
    {
        try
        {
            var DetailOrder = getDetail(id).Result;
            _dbcontext.DetailOrders.Remove(DetailOrder);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<DetailOrder> update(DetailOrder DetailOrder)
    {
        var detailOrder = _dbcontext.DetailOrders.Update(DetailOrder).Entity;
        await _dbcontext.SaveChangesAsync();
        return detailOrder;
    }

    public async Task<DetailOrder> getDetail(Guid id)
    {
        return await _dbcontext.DetailOrders.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public List<DetailOrder> getList()
    {
        return _dbcontext.DetailOrders.ToList();
    }
}