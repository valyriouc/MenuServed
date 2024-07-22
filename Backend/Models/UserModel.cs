using Backend.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public enum UserRole
{
    Customer,
    Restaurent
}

/// <summary>
/// QUESTION: Is this the right method to make money with it???
/// - Prcing per click 
/// - Pricing per order 
/// - Pricing with different features 
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
}
