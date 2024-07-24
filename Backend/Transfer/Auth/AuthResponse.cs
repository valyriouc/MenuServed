namespace Backend.Transfer.Auth;

public struct AuthResponse
{
    public string Token { get; }

    public AuthResponse(string token)
    {
        Token = token;
    }
}
