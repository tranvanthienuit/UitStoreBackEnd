using System.Net;
using Microsoft.EntityFrameworkCore;
using Sane.Http.HttpResponseExceptions;
using UitStoreBackEnd.db_context;
using UitStoreBackEnd.entity;

namespace UitStoreBackEnd.factory;

public interface IUserFactory
{
    Task<User> create(User user);

    Task<bool> deleteById(Guid id);

    Task<User> update(User user);

    Task<User> getDetail(Guid id);

    List<User> getList();

    Task<User> changePassword(Guid id, string password);
}

public class UserFactory : IUserFactory
{
    private readonly dbcontext _dbcontext;

    public UserFactory(dbcontext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<User> create(User user)
    {
        if (existUser(user.username, user.telephone, user.email).Result)
        {
            var message = new HttpResponseMessage
            {
                Content = new StringContent("user exist")
            };

            throw new HttpResponseException(HttpStatusCode.Conflict, message);
        }

        var result = await _dbcontext.Users.AddAsync(user);
        await _dbcontext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> deleteById(Guid id)
    {
        try
        {
            var user = getDetail(id).Result;
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

    public async Task<User> getDetail(Guid id)
    {
        return await _dbcontext.Users.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public List<User> getList()
    {
        return _dbcontext.Users.ToList();
    }

    public async Task<User> changePassword(Guid id, string password)
    {
        var user = await _dbcontext.Users.FindAsync(id);
        if (user == null)
        {
            var message = new HttpResponseMessage
            {
                Content = new StringContent("user not found")
            };
            throw new HttpResponseException(HttpStatusCode.NotFound, message);
        }

        user.password = password;
        var newuser = _dbcontext.Users.Update(user).Entity;
        await _dbcontext.SaveChangesAsync();
        return newuser;
    }

    public async Task<bool> existUser(string username, string telephone, string email)
    {
        var users = await _dbcontext
            .Users
            .Where(
                item =>
                    item.username.Equals(username) ||
                    item.telephone.Equals(telephone) ||
                    item.email.Equals(email)).ToListAsync();
        return users.Count != 0;
    }
}