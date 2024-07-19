namespace Backend.Transfer.Auth;

public struct LoginResponse
{
    public string Token { get; }

    public LoginResponse(string token)
    {
        Token = token;
    }
}
