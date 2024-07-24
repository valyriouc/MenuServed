using Backend.Helpers;

using System.ComponentModel.DataAnnotations;

namespace Backend.Transfer.Auth;

public struct LoginData
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [RegularExpression(ApiConfig.PasswordPattern)]
    [MinLength(ApiConfig.MinPasswordLength)]
    public string Password { get; set; }
}

public struct RegisterData
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(ApiConfig.UsernameMinLength)]
    [MaxLength(ApiConfig.UsernameMaxLength)]
    public string UserName { get; set; }

    [Required]
    [RegularExpression(ApiConfig.PasswordPattern)]
    [MinLength(ApiConfig.MinPasswordLength)]
    public string Password { get; set; }

}