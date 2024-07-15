using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Helpers;

public class JwtTokenGenerator
{
    private readonly SymmetricSecurityKey _key;

    public JwtTokenGenerator(string secretKey)
    {
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secrets.Instance.Secret));
    }

    public string GenerateToken(string username, string role)
    {
        JwtSecurityToken token = new JwtSecurityToken(
            issuer: Secrets.Instance.Issuer,
            audience: Secrets.Instance.Audience,
            claims: new[] { new Claim(ClaimTypes.Name, username), new Claim(ClaimTypes.Role, role) },
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: new SigningCredentials(_key, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}