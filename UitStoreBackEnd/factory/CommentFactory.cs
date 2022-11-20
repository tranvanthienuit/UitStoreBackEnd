using Microsoft.EntityFrameworkCore;
using UitStoreBackEnd.base_factory;
using UitStoreBackEnd.db_context;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.filter;

namespace UitStoreBackEnd.factory;

public interface ICommentFactory : IBaseFactory<Guid, Comment, CommentFilter>
{
}

public class CommentFactory : ICommentFactory
{
    private readonly dbcontext _dbcontext;

    private readonly IProductFactory _productFactory;

    public CommentFactory(dbcontext dbcontext, IProductFactory productFactory)
    {
        _dbcontext = dbcontext;
        _productFactory = productFactory;
    }

    public async Task<Comment> create(Comment Comment)
    {
        var product = await _productFactory.getDetailById(Comment.productId);
        var result = await _dbcontext.Comments.AddAsync(Comment);
        await _dbcontext.SaveChangesAsync();

        product.rating = getList().Result.Where(x => x.productId == Comment.productId).ToList().Average(x => x.rating);
        await _productFactory.update(product);
        return result.Entity;
    }

    public async Task<bool> deleteById(Guid id)
    {
        try
        {
            var Comment = getDetailById(id).Result;
            _dbcontext.Comments.Remove(Comment);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<Comment> update(Comment Comment)
    {
        var newComment = _dbcontext.Comments.Update(Comment).Entity;
        await _dbcontext.SaveChangesAsync();
        return newComment;
    }

    public async Task<Comment> getDetailById(Guid ID)
    {
        return await _dbcontext.Comments.FindAsync(ID) ?? throw new InvalidOperationException();
    }

    public async Task<List<Comment>> getList()
    {
        return await _dbcontext.Comments.ToListAsync();
    }

    public async Task<List<Comment>> getPage(CommentFilter commentFilter, string sort, int page, int size)
    {
        var result = from item in _dbcontext.Comments
            where commentFilter.userId == null || (item.userId == new Guid(commentFilter.userId)
                                                   && commentFilter.productId == null) ||
                  item.productId == new Guid(commentFilter.productId)
            select item;
        return await result.Skip((page - 1) * size).Take(size).ToListAsync();
    }
}