
using Backend.Database;
using Backend.Helpers;
using Backend.Information;
using Backend.Models;
using Backend.Transfer.Auth;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Auth;

public class LoginService : IServiceBase<LoginData, AuthResponse>
{
    private AppDbContext DbContext { get; }

    public ILogger Logger { get; }

    public LoginService(
        AppDbContext dbContext,
        ILogger<LoginService> logger)
    {
        DbContext = dbContext;
        Logger = logger;
    }

    private const string messageForWrongInput = "Email or password are incorrect";

    public async Task<AuthResponse> RunAsync(LoginData data)
    {
        // Query database for specified user 
        UserModel? user = await DbContext.Users.FirstOrDefaultAsync(employee => employee.Email == data.Email);
        
        if (user is null)
        {
            throw ApiException.Unauthorized(
                messageForWrongInput);
        }

        string hash = HashHelper.ComputeSha512(data.Password);
        if (user.Password != hash)
        {
            throw ApiException.Unauthorized(
                messageForWrongInput);
        }

        JwtTokenGenerator gen = new JwtTokenGenerator("blablabla");
        string token = gen.GenerateToken(user.UserName, user.Email, user.Role.ToString());

        return new AuthResponse(token);
    }
}
