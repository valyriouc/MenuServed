namespace Backend.Helpers;

public static class ApiConfig
{
    public const int MinPasswordLength = 12;

    public const string PasswordPattern = 
        "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{12,}$";

    public const int UsernameMinLength = 4;

    public const int UsernameMaxLength = 50;
}
