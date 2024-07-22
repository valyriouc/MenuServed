namespace Backend.Models;

public enum UserRole
{
    Customer,
    Restaurent
}

/// <summary>
/// The filters which the user has set, to find his restaurents
/// </summary>
public class Filter
{

}

/// <summary>
/// The basic user model
/// </summary>
public class UserModel
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public UserRole Role { get; set; }

    public string Password { get; set; } = null!;
}
