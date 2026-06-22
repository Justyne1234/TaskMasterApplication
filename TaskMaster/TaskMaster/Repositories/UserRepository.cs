using Microsoft.EntityFrameworkCore;
using TaskMaster.DbContexts;
using TaskMaster.Models;
using TaskMaster.Models.Requests;

namespace TaskMaster.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;
    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User?> GetUserByUsername(String username)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Username == username);
        return user;
    }

    public async Task<User?> GetUserByCredentials(LoginRequest request)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(x =>
            x.Username == request.Username
            && x.Password == request.Password);
        return user;
    }

    public async Task<User> Register(User request)
    {
       _dbContext.Add(request);
        await _dbContext.SaveChangesAsync();
        return request;
    }
}