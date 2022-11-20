using Microsoft.EntityFrameworkCore;
using UitStoreBackEnd.base_factory;
using UitStoreBackEnd.db_context;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.filter;

namespace UitStoreBackEnd.factory;

public interface IProductFactory : IBaseFactory<Guid, Product, ProductFilter>
{
}

public class ProductFactory : IProductFactory
{
    private readonly dbcontext _dbcontext;

    public ProductFactory(dbcontext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<Product> create(Product Product)
    {
        var result = await _dbcontext.Products.AddAsync(Product);
        await _dbcontext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> deleteById(Guid id)
    {
        try
        {
            var Product = getDetailById(id).Result;
            _dbcontext.Products.Remove(Product);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<Product> update(Product Product)
    {
        var product = _dbcontext.Products.Update(Product).Entity;
        await _dbcontext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> getDetailById(Guid ID)
    {
        return await _dbcontext.Products.FindAsync(ID) ?? throw new InvalidOperationException();
    }

    public async Task<List<Product>> getList()
    {
        return await _dbcontext.Products.ToListAsync();
    }

    public async Task<List<Product>> getPage(ProductFilter productFilter, string sort, int page, int size)
    {
        var result = from item in _dbcontext.Products
            where productFilter.name == null || (item.name == productFilter.name
                                                 && productFilter.price == null) || (item.price == productFilter.price
                && productFilter.size == null) || (item.size == productFilter.size
                                                   && productFilter.stock == null) || (item.stock == productFilter.stock
                && productFilter.salePrice == null) || item.salePrice == productFilter.salePrice
            select item;
        if (sort.Equals("ASC"))
            return await result.OrderBy(
                x =>
                    x.name == productFilter.name ||
                    x.size == productFilter.size ||
                    x.stock == productFilter.stock ||
                    x.price == productFilter.stock ||
                    x.salePrice == productFilter.salePrice).Skip((page - 1) * size).Take(size).ToListAsync();
        return await result.OrderByDescending(x => x.Equals(productFilter)).Skip((page - 1) * size).Take(size)
            .ToListAsync();
    }
}