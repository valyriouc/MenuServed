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
    public IActionResult RegisterCustomer([FromBody] RegisterData data)
    {
        registerService.IsCustomerRegistration = true; 

        return Ok();
    }

    [HttpPost("register/restaurant/")]
    [AllowAnonymous]
    public IActionResult RegisterRestaurant([FromBody] RegisterData data)
    {
        registerService.IsCustomerRegistration = false;

        return Ok(); 
    }

    [HttpPost("logout/")]
    public IActionResult Logout()
    {

        return Ok(); 
    }
}