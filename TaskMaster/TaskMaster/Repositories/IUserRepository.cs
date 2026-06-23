using TaskMaster.Models;
using TaskMaster.Models.Requests;

namespace TaskMaster.Repositories;
public interface IUserRepository
{
    public Task<User> Register(User request);
    public Task<User> GetUserByUsername(String username);
}