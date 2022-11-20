using Microsoft.EntityFrameworkCore;
using UitStoreBackEnd.base_factory;
using UitStoreBackEnd.db_context;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.exception;
using UitStoreBackEnd.filter;
using UitStoreBackEnd.model.login;

namespace UitStoreBackEnd.factory;

public interface IUserFactory : IBaseFactory<Guid, User, UserFilter>
{
    Task<User> changePassword(Guid id, string password);

    Task<User> login(LoginRequest loginRequest);
}

public class UserFactory : IUserFactory
{
    private readonly dbcontext _dbcontext;
    private readonly IResponseFactory _responseFactory;

    public UserFactory(dbcontext dbcontext, IResponseFactory responseFactory)
    {
        _dbcontext = dbcontext;
        _responseFactory = responseFactory;
    }

    public async Task<User> create(User user)
    {
        var resultCheck = existUser(user.username, user.telephone, user.email).Result;
        if (resultCheck) throw new InvalidException("user exist", _responseFactory);

        var result = await _dbcontext.Users.AddAsync(user);
        await _dbcontext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> deleteById(Guid id)
    {
        try
        {
            var user = getDetailById(id).Result;
            _dbcontext.Users.Remove(user);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<User> update(User user)
    {
        var newuser = _dbcontext.Users.Update(user).Entity;
        await _dbcontext.SaveChangesAsync();
        return newuser;
    }

    public async Task<User> getDetailById(Guid ID)
    {
        return await _dbcontext.Users.FindAsync(ID) ?? throw new InvalidOperationException();
    }

    public async Task<List<User>> getList()
    {
        return await _dbcontext.Users.ToListAsync();
    }

    public Task<List<User>> getPage(UserFilter Filter)
    {
        return null!;
    }

    public async Task<User> changePassword(Guid id, string password)
    {
        var user = await _dbcontext.Users.FindAsync(id);
        if (user == null) return null;

        user.password = password;
        var newuser = _dbcontext.Users.Update(user).Entity;
        await _dbcontext.SaveChangesAsync();
        return newuser;
    }

    public async Task<User> login(LoginRequest loginRequest)
    {
        var user = _dbcontext
            .Users
            .Where(item => item.username == loginRequest.username
                           && item.password == loginRequest.password);
        if (!user.Any()) throw new InvalidException("user not found", _responseFactory);
        return user.First();
    }

    public async Task<bool> existUser(string username, string telephone, string email)
    {
        var users = _dbcontext
            .Users
            .Where(
                item =>
                    item.username.Equals(username) ||
                    item.telephone.Equals(telephone) ||
                    item.email.Equals(email)).ToListAsync().Result.First();
        return users.username == null ? false : true;
    }
}