using Microsoft.EntityFrameworkCore;
using UitStoreBackEnd.db_context;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.filter;

namespace UitStoreBackEnd.factory;

public interface ICommentFactory
{
    Task<Comment> create(Comment Comment);

    Task<bool> deleteById(Guid id);

    Task<Comment> update(Comment Comment);

    Task<Comment> getDetail(Guid id);

    Task<List<Comment>> getList();

    Task<List<Comment>> getPage(CommentFilter commentFilter);
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
        var product = await _productFactory.getDetail(Comment.productId);
        product.rating = (product.rating + Comment.rating) / 2;
        await _productFactory.update(product);
        var result = await _dbcontext.Comments.AddAsync(Comment);
        await _dbcontext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> deleteById(Guid id)
    {
        try
        {
            var Comment = getDetail(id).Result;
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

    public async Task<Comment> getDetail(Guid id)
    {
        return await _dbcontext.Comments.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task<List<Comment>> getList()
    {
        return await _dbcontext.Comments.ToListAsync();
    }

    public async Task<List<Comment>> getPage(CommentFilter commentFilter)
    {
        var result = from item in _dbcontext.Comments
            where commentFilter.userId == null || (item.userId == new Guid(commentFilter.userId)
                                                   && commentFilter.productId == null) ||
                  item.productId == new Guid(commentFilter.productId)
            select item;
        return await result.ToListAsync();
    }
}