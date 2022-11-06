using UitStoreBackEnd.db_context;
using UitStoreBackEnd.entity;

namespace UitStoreBackEnd.factory;

public interface IProductFactory
{
    Task<Product> create(Product Product);

    Task<bool> deleteById(Guid id);

    Task<Product> update(Product Product);

    Task<Product> getDetail(Guid id);

    List<Product> getList();
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
            var Product = getDetail(id).Result;
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

    public async Task<Product> getDetail(Guid id)
    {
        return await _dbcontext.Products.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public List<Product> getList()
    {
        return _dbcontext.Products.ToList();
    }
}