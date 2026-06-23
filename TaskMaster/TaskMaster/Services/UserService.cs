using Microsoft.AspNetCore.Identity;
using TaskMaster.Exceptions;
using TaskMaster.Models;
using TaskMaster.Models.Requests;
using TaskMaster.Repositories;

namespace TaskMaster.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly PasswordHasher<User> _passwordHasher;
    private readonly JwtService _jwtService;
    public UserService(IUserRepository userRepository,
        PasswordHasher<User> passwordHasher,
        JwtService jwtService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }
    public async Task<string> Login(LoginRequest request)
    {
        var user = await GetUserByUsername(request.Username);

        if (user is null)
        {
            throw new UnauthorizedAccessException("Unregistered User");
        }

        var result = _passwordHasher.VerifyHashedPassword(
            user,
            user.Password,
            request.Password);

        if (result != PasswordVerificationResult.Success)
        {
            throw new UnauthorizedAccessException("Incorrect password");
        }
        return GenerateJwtToken(user);
    }

    public async Task<User> Register(RegistrationRequest request)
    {
        var existingUser = await GetUserByUsername(request.Username);
        if (existingUser is not null)
        {
            throw new UserAlreadyExistsException(existingUser.Username);
        }

        //New User. Register

        var user = new User
        {
            Username = request.Username,
            AuthenticationMethod = request.AuthenticationMethod,
            GoogleId = request.GoogleId ?? string.Empty,
        };

        if (request.AuthenticationMethod.Equals("Traditional"))
        {
            user.Password = _passwordHasher.HashPassword(user, request.Password);
        }

        var registeredUser = await _userRepository.Register(user);
        
        if (registeredUser is null)
        {
            throw new RegistrationFailedException();
        }
        return registeredUser;
    }

    public async Task<User> GetUserByUsername(string username)
    {
        return await _userRepository.GetUserByUsername(username);
    }

    public string GenerateJwtToken(User user)
    {
        return _jwtService.GenerateJwtToken(user);
    }
}