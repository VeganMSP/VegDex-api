using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using VegDex.Core.Configuration;

namespace VegDex.Core.Utilities;

public class JwtTokenManager
{
    private readonly string? _secretKey;
    public JwtTokenManager(IConfigManager configManager)
    {
        _secretKey = configManager.App.SecretKey;
    }
    public string Generate(User user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(_secretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        { Subject = new ClaimsIdentity(new[]
          { new Claim("id", user.Id.ToString()) }),
          Expires = DateTime.UtcNow.AddDays(7),
          SigningCredentials =
              new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    public JwtSecurityToken Validate(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(_secretKey);
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        { ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false,
          // Set ClockSkew to zero so tokens expire exactly at token expiration time
          ClockSkew = TimeSpan.Zero }, out var validatedToken);
        return (JwtSecurityToken)validatedToken;
    }
}
