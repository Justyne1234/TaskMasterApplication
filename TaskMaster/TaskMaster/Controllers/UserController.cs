using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskMaster.Exceptions;
using TaskMaster.Models;
using TaskMaster.Models.Requests;
using TaskMaster.Services;

namespace TaskMaster.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly GoogleApiService _googleApiService;
    public UserController(IUserService userService, GoogleApiService googleApiService)
    {
        _userService = userService;
        _googleApiService = googleApiService;
    }
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegistrationRequest request)
    {
        try
        {
            var user = await _userService.Register(request);
            return Ok(user);
        }
        catch (UserAlreadyExistsException ex)
        {
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Unexpected error occurred" });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            var token = await _userService.Login(request);
            return Ok(new { message = "success", token });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch(Exception ex)
        {
            return StatusCode(500, new { message = "Unexpected error occurred" });
        }
    }
    [HttpPost("google-login")]
    public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequest request)
    {
        var payload = await _googleApiService.VerifyGoogleToken(request.googleToken);

        var user = await _userService.GetUserByUsername(payload.Email);

        if(user is null)
        {
            return NotFound(new { message = "Unregistered user" });
        }

        var token = _userService.GenerateJwtToken(user);
        return Ok(new { message = "success", token });
    }
}