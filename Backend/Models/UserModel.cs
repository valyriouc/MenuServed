using Backend.Helpers;
using Backend.Transfer.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Security.Claims;

namespace Backend.Models;

/// <summary>
/// Complete quota, ticket system
/// </summary>
public enum UserRole
{
    Customer,
    Restaurent,
    Developer,
    Admin
}

/// <summary>
/// QUESTION: Is this the right method to make money with it???
/// - Prcing per click 
/// - Pricing per order 
/// - Pricing with different features
/// - Monetize the components (Menu cards, items, ...)
/// </summary>
public enum Pricing
{
    FreeTrial,
    Customer,
    Restaurent,
}

/// <summary>
/// The filters which the user has set, to find his restaurents
/// </summary>
public class Filter
{

}

/// <summary>
/// QUESTION: What needs to be done here?
/// </summary>
public class PaymentMethod
{
    public uint Id { get; set; }

}

/// <summary>
/// The basic user model
/// How do we make sure that we get paid 
/// </summary>
[Table("users")]
public class UserModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [MinLength(ApiConfig.UsernameMinLength)]
    [MaxLength(ApiConfig.UsernameMaxLength)]    
    public string UserName { get; set; } = null!;

    [Required]
    public UserRole Role { get; set; }

    // It's a SHA512 hash
    [Required]
    public string Password { get; set; } = null!;

    /// <summary>
    /// Pricing section 
    /// </summary>
    public Pricing PricingPlan { get; set; }

    public DateTime? FreeTrialStarted { get; set; } 

    public ClaimsPrincipal CreatePrinciple()
    {
        ClaimsPrincipal principle = new ClaimsPrincipal();

        principle.AddIdentity(
            new ClaimsIdentity(
                new[] 
                { 
                    new Claim(ClaimTypes.Name, UserName), 
                    new Claim(ClaimTypes.Role, Role.ToString()), 
                    new Claim(ClaimTypes.Email, Email) 
                }
            )
        );

        return principle;
    }

    public static UserModel CreateCustomer(RegisterData data)
    {
        UserModel model = new UserModel()
        {
            Email = data.Email,
            FreeTrialStarted = DateTime.UtcNow.Date,
            Role = UserRole.Customer,
            Password = HashHelper.ComputeSha512(data.Password),
            UserName = data.UserName,
            PricingPlan = Pricing.FreeTrial
        };

        return model;
    }

    public static UserModel CreateRestaurent(RegisterData data)
    {
        UserModel model = new UserModel()
        {
            Email = data.Email,
            FreeTrialStarted = DateTime.UtcNow.Date,
            Role = UserRole.Restaurent,
            Password = HashHelper.ComputeSha512(data.Password),
            UserName = data.UserName,
            PricingPlan = Pricing.FreeTrial
        };

        return model;
    }
}
