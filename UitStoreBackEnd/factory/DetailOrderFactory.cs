using Microsoft.EntityFrameworkCore;
using UitStoreBackEnd.base_factory;
using UitStoreBackEnd.db_context;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.filter;

namespace UitStoreBackEnd.factory;

public interface IDetailOrderFactory : IBaseFactory<Guid, DetailOrder, DetailOrderFilter>
{
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

    public async Task<DetailOrder> getDetailById(Guid ID)
    {
        return await _dbcontext.DetailOrders.FindAsync(ID) ?? throw new InvalidOperationException();
    }

    public async Task<List<DetailOrder>> getList()
    {
        return await _dbcontext.DetailOrders.ToListAsync();
    }

    public async Task<List<DetailOrder>> getPage(DetailOrderFilter detailOrderFilter, string sort, int page, int size)
    {
        var result = from item in _dbcontext.DetailOrders
            where detailOrderFilter.productId == null || (item.productId == detailOrderFilter.productId
                                                          && detailOrderFilter.orderId == null) ||
                  (item.orderId == detailOrderFilter.orderId
                   && detailOrderFilter.name == null) || (item.name == detailOrderFilter.name
                                                          && detailOrderFilter.price == null) ||
                  (item.price == detailOrderFilter.price
                   && detailOrderFilter.size == null) || (item.size == detailOrderFilter.size
                                                          && detailOrderFilter.quantity == null) ||
                  item.quantity == detailOrderFilter.quantity
            select item;
        if (sort.Equals("ASC"))
            return await result.OrderBy(x => x.Equals(detailOrderFilter)).Skip((page - 1) * size).Take(size)
                .ToListAsync();
        return await result.OrderByDescending(x => x.Equals(detailOrderFilter)).Skip((page - 1) * size).Take(size)
            .ToListAsync();
    }

    public async Task<DetailOrder> getDetail(Guid id)
    {
        return await _dbcontext.DetailOrders.FindAsync(id) ?? throw new InvalidOperationException();
    }
}