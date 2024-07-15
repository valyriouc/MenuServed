namespace Backend.Transfer.Auth;

public record LoginData(string Email, string Password);

public record RegisterData(string Email, string UserName, string Password);