using Microsoft.EntityFrameworkCore;
using UitStoreBackEnd.base_factory;
using UitStoreBackEnd.db_context;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.filter;

namespace UitStoreBackEnd.factory;

public interface IFavorite_ProductFactory : IBaseFactory<Guid, Favorite_Product, FavoriteProductFilter>
{
}

public class Favorite_ProductFactory : IFavorite_ProductFactory
{
    private readonly dbcontext _dbcontext;

    public Favorite_ProductFactory(dbcontext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<Favorite_Product> create(Favorite_Product Favorite_Product)
    {
        var result = await _dbcontext.FavoriteProducts.AddAsync(Favorite_Product);
        await _dbcontext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> deleteById(Guid id)
    {
        try
        {
            var Favorite_Product = getDetailById(id).Result;
            _dbcontext.FavoriteProducts.Remove(Favorite_Product);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<Favorite_Product> update(Favorite_Product Favorite_Product)
    {
        var favoriteProduct = _dbcontext.FavoriteProducts.Update(Favorite_Product).Entity;
        await _dbcontext.SaveChangesAsync();
        return favoriteProduct;
    }

    public async Task<Favorite_Product> getDetailById(Guid ID)
    {
        return await _dbcontext.FavoriteProducts.FindAsync(ID) ?? throw new InvalidOperationException();
    }

    public async Task<List<Favorite_Product>> getList()
    {
        return await _dbcontext.FavoriteProducts.ToListAsync();
    }

    public async Task<List<Favorite_Product>> getPage(FavoriteProductFilter filter)
    {
        var result = from item in _dbcontext.FavoriteProducts
            where filter.userId == null || item.userId == new Guid(filter.userId)
            select item;
        return await result.ToListAsync();
    }
}