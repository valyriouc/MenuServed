using Backend.Helpers;
using Backend.Services.Auth;
using Backend.Transfer.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers.Auth;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly LoginService loginService;
    private readonly RegisterService registerService;

    public AuthController(
        LoginService loginService, 
        RegisterService registerService)
    {
        this.loginService = loginService;
        this.registerService = registerService;
    }

    [HttpPost("login/")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginData data)
    {
        ClaimsPrincipal content = await this.loginService.RunAsync(data);
        return SignIn(content);
    }

    [HttpPost("register/user/")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterCustomer([FromBody] RegisterData data)
    {
        registerService.Init(true);
        ClaimsPrincipal principle = await registerService.RunAsync(data);
        return SignIn(principle);
    }

    [HttpPost("register/restaurant/")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterRestaurant([FromBody] RegisterData data)
    {
        registerService.Init(false);
        ClaimsPrincipal principle = await registerService.RunAsync(data);
        return SignIn(principle);
    }

    [HttpPost("logout/")]
    public async Task<IActionResult> Logout()
    {

        return Ok(); 
    }
}