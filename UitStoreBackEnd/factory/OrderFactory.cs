using Microsoft.EntityFrameworkCore;
using UitStoreBackEnd.db_context;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.filter;

namespace UitStoreBackEnd.factory;

public interface IOrderFactory
{
    Task<Order> create(Order Order);

    Task<bool> deleteById(Guid id);

    Task<Order> update(Order Order);

    Task<Order> getDetail(Guid id);

    Task<List<Order>> getList();

    Task<List<Order>> getPage(OrderFilter orderFilter);
}

public class OrderFactory : IOrderFactory
{
    private readonly dbcontext _dbcontext;

    public OrderFactory(dbcontext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<Order> create(Order Order)
    {
        var result = await _dbcontext.Orders.AddAsync(Order);
        await _dbcontext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> deleteById(Guid id)
    {
        try
        {
            var Order = getDetail(id).Result;
            _dbcontext.Orders.Remove(Order);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<Order> update(Order Order)
    {
        var newOrder = _dbcontext.Orders.Update(Order).Entity;
        await _dbcontext.SaveChangesAsync();
        return newOrder;
    }

    public async Task<Order> getDetail(Guid id)
    {
        return await _dbcontext.Orders.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task<List<Order>> getList()
    {
        return await _dbcontext.Orders.ToListAsync();
    }

    public async Task<List<Order>> getPage(OrderFilter orderFilter)
    {
        var result = from item in _dbcontext.Orders
            where orderFilter.userId == null || item.userId == new Guid(orderFilter.userId)
            select item;
        return await result.ToListAsync();
    }
}