
using Backend.Transfer.Auth;

namespace Backend.Services.Auth;

public class LoginService : IServiceBase<LoginData, LoginResponse>
{
    public ILogger Logger { get; } 

    public LoginService(
        ILogger<LoginService> logger)
    {
        Logger = logger;
    }

    public Task<LoginResponse> RunAsync(LoginData data)
    {
        // Query database for specified user 

        // Check if user exists 

        // Check that password is correct 

        // Authenticate user 

        // Generate token 

        // Return token in response 
    }
}
