using TaskMaster.Models;
using TaskMaster.Models.Requests;

namespace TaskMaster.Services;
public interface IUserService
{
    public Task<User> Register(RegistrationRequest request);
    public Task<string> Login(LoginRequest request);
    public Task<User> GetUserByUsername(string username);
    public string GenerateJwtToken(User user);
}
