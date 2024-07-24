using Backend.Transfer.Auth;

namespace Backend.Services.Auth;

public class RegisterService : IServiceBase<RegisterData, AuthResponse>
{
    public ILogger Logger { get; set; }

    public bool IsCustomerRegistration { get; set; } = true;

    public RegisterService(ILogger logger)
    {
        Logger = logger;
    }

    public Task<AuthResponse> RunAsync(RegisterData data)
    {
        throw new NotImplementedException();
    }
}
