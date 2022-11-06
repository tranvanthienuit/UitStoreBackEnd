using UitStoreBackEnd.db_context;
using UitStoreBackEnd.entity;

namespace UitStoreBackEnd.factory;

public interface ICommentFactory
{
    Task<Comment> create(Comment Comment);

    Task<bool> deleteById(Guid id);

    Task<Comment> update(Comment Comment);

    Task<Comment> getDetail(Guid id);

    List<Comment> getList();
}

public class CommentFactory : ICommentFactory
{
    private readonly dbcontext _dbcontext;

    public CommentFactory(dbcontext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<Comment> create(Comment Comment)
    {
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

    public List<Comment> getList()
    {
        return _dbcontext.Comments.ToList();
    }
}