using Backend.Helpers;
using Backend.Services.Auth;
using Backend.Transfer.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers.Auth;

// https://docs.duendesoftware.com/identityserver/v7/overview/

[ApiController]
[Authorize(Roles = "Customer, Restaurent, Developer, Admin")]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly LoginService loginService;
    private readonly RegisterCustomerService registerCustomerService;
    private readonly RegisterRestaurentService registerRestaurentService;
    public AuthController(
        LoginService loginService, 
        RegisterCustomerService registerService,
        RegisterRestaurentService registerRestaurent)
    {
        this.loginService = loginService;
        this.registerCustomerService = registerService;
        this.registerRestaurentService = registerRestaurent;
    }

    [AllowAnonymous]
    [HttpPost("login/")]
    public async Task<IActionResult> Login([FromBody] LoginData data)
    {
        ClaimsPrincipal content = await this.loginService.RunAsync(data);
        return SignIn(content);
    }

    [AllowAnonymous]
    [HttpPost("register/user/")]
    public async Task<IActionResult> RegisterCustomer([FromBody] RegisterData data)
    {
        ClaimsPrincipal principle = await registerCustomerService.RunAsync(data);
        return SignIn(principle);
    }

    [AllowAnonymous]
    [HttpPost("register/restaurant/")]
    public async Task<IActionResult> RegisterRestaurant([FromBody] RegisterData data)
    {
        ClaimsPrincipal principle = await registerRestaurentService.RunAsync(data);
        return SignIn(principle);
    }

    [HttpPost("logout/")]
    public async Task<IActionResult> Logout()
    {
        return SignOut();
    }
}