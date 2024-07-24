
using Backend.Database;
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

    public async Task<AuthResponse> RunAsync(LoginData data)
    {
        // Query database for specified user 
        UserModel? user = await DbContext.Users.FirstOrDefaultAsync(employee => employee.Email == data.Email);
        
        if (user is null)
        {
            throw ApiException.NotFound(
                "User does not exist!");
        }

        throw new NotImplementedException();

        // Check if user exists 

        // Check that password is correct 

        // Authenticate user 

        // Generate token 

        // Return token in response 
    }
}
