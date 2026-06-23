using Microsoft.EntityFrameworkCore;
using TaskMaster.DbContexts;
using TaskMaster.Models;

namespace TaskMaster.Repositories;

public class UserRepositorySqlProc : IUserRepository
{
    private readonly AppDbContext _dbContext;
    public UserRepositorySqlProc(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User?> GetUserByUsername(String username)
    {
        var user = await _dbContext.Users
                .FromSqlInterpolated($"CALL GetUserByUsername({username})")
                .ToListAsync();
        return user.FirstOrDefault();
    }

    public async Task<User> Register(User request)
    {
        await _dbContext.Database
            .ExecuteSqlInterpolatedAsync($@"CALL RegisterUser({request.Username}, {request.Password}, {request.AuthenticationMethod}, {request.GoogleId})");
        return await GetUserByUsername(request.Username);
    }
}