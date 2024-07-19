using Backend.Helpers;
using Backend.Services.Auth;
using Backend.Transfer.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Auth;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly LoginService loginService;

    public AuthController(LoginService loginService)
    {
        this.loginService = loginService;
    }

    [HttpPost("login/")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginData data)
    {
        LoginResponse content = await this.loginService.RunAsync(data);
        return Ok(content);
    }

    [HttpPost("register/user/")]
    [AllowAnonymous]
    public IActionResult RegisterCustomer([FromBody] RegisterData data)
    {
        return Ok();
    }

    [HttpPost("register/restaurant/")]
    [AllowAnonymous]
    public IActionResult RegisterRestaurant([FromBody] RegisterData data)
    {

        return Ok(); 
    }

    [HttpPost("logout/")]
    public IActionResult Logout()
    {

        return Ok(); 
    }
}