using Microsoft.EntityFrameworkCore;
using UitStoreBackEnd.base_factory;
using UitStoreBackEnd.db_context;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.filter;
using UitStoreBackEnd.model.order;

namespace UitStoreBackEnd.factory;

public interface IOrderFactory : IBaseFactory<Guid, Order, OrderFilter>
{
    Task<Order> createOrder(OrderDetail orderDetail);
}

public class OrderFactory : IOrderFactory
{
    private readonly dbcontext _dbcontext;
    private readonly IDetailOrderFactory _detailOrderFactory;

    public OrderFactory(dbcontext dbcontext, IDetailOrderFactory detailOrderFactory)
    {
        _dbcontext = dbcontext;
        _detailOrderFactory = detailOrderFactory;
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
            var Order = getDetailById(id).Result;
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

    public async Task<Order> getDetailById(Guid ID)
    {
        return await _dbcontext.Orders.FindAsync(ID) ?? throw new InvalidOperationException();
    }

    public async Task<List<Order>> getList()
    {
        return await _dbcontext.Orders.ToListAsync();
    }

    public async Task<List<Order>> getPage(OrderFilter orderFilter, string sort, int page, int size)
    {
        var result = from item in _dbcontext.Orders
            where orderFilter.userId == null || item.userId == new Guid(orderFilter.userId)
            select item;
        List<Order> orders = await result.ToListAsync();
        return orders.Skip((page - 1) * size).Take(size).ToList();
    }

    public async Task<Order> createOrder(OrderDetail orderDetail)
    {
        try
        {
            var order = new Order
            {
                userId = orderDetail.userId,
                fullName = orderDetail.fullName,
                telephone = orderDetail.telephone,
                address = orderDetail.address,
                total = orderDetail.total,
                status = orderDetail.status
            };
            var result = await _dbcontext.Orders.AddAsync(order);
            await _dbcontext.SaveChangesAsync();
            var newOrder = result.Entity;
            foreach (var item in orderDetail.DetailOrders)
            {
                var detailOrder = new DetailOrder
                {
                    orderId = newOrder.id,
                    productId = item.productId,
                    image = item.image,
                    name = item.name,
                    price = item.price,
                    size = item.size,
                    quantity = item.quantity
                };
                await _detailOrderFactory.create(detailOrder);
            }

            return newOrder;
        }
        catch (Exception e)
        {
            throw new Exception();
        }
    }
}