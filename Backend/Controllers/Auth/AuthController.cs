using Backend.Helpers;
using Backend.Transfer.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Auth;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtTokenGenerator _tokenGenerator;

    public AuthController(JwtTokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult Login([FromBody] LoginData data)
    {
        
        return Ok();
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult RegisterCustomer([FromBody] RegisterData data)
    {
        return Ok();
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult RegisterRestaurant([FromBody] RegisterData data)
    {

        return Ok(); 
    }

    [HttpPost]
    public IActionResult Logout()
    {

        return Ok(); 
    }
}