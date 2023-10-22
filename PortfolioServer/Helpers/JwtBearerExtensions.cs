using Microsoft.IdentityModel.Tokens;
using PortfolioShared.Models.Service;
using System.ComponentModel;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PortfolioShared.Helpers
{
	public static class JwtBearerExtension
	{
		public static List<Claim> CreateClaims(this User user, List<Role> roles)
		{
			List<Claim> claims = new List<Claim>
			{
				new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToString(CultureInfo.InvariantCulture)),
				new(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new(ClaimTypes.Name, user.Id.ToString()),
				new(ClaimTypes.Email, user.Email!),
				new(ClaimTypes.Role, string.Join(" ", roles.Select(role => role.Name))),
			};
			return claims;
		}

		public static SigningCredentials CreateSigningCredentials(this IConfiguration configuration)
		{
			return new SigningCredentials(AuthOptions.GetSymmetricSecurityKey, SecurityAlgorithms.HmacSha256);
		}

		public static JwtSecurityToken CreateJwtToken(this IEnumerable<Claim> claims, IConfiguration configuration)
		{
			return new JwtSecurityToken(AuthOptions.Issuer, AuthOptions.Audience, claims, expires: DateTimeOffset.Now.AddMinutes(AuthOptions.AccessTokenLifeTime).DateTime, notBefore: DateTime.Now, signingCredentials: CreateSigningCredentials(configuration));
		}

		public static JwtSecurityToken CreateToken(this IConfiguration configuration, List<Claim> authClaims)
		{
			var token = new JwtSecurityToken(issuer: AuthOptions.Issuer, audience: AuthOptions.Audience, expires: DateTimeOffset.Now.AddMinutes(AuthOptions.AccessTokenLifeTime).DateTime, claims: authClaims, signingCredentials: CreateSigningCredentials(configuration));
			return token;
		}

		public static string GenerateRefreshToken(this IConfiguration configuration)
		{
			var randomNumber = new byte[64];
			using var rng = RandomNumberGenerator.Create();
			rng.GetBytes(randomNumber);
			return Convert.ToBase64String(randomNumber);
		}

		public static ClaimsPrincipal? GetPrincipalFromExpiredToken(this IConfiguration configuration, string? token)
		{
			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateAudience = false,
				ValidateIssuer = false,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey,
				ValidateLifetime = false
			};
			
			var tokenHandler = new JwtSecurityTokenHandler();
			var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
			if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
				throw new SecurityTokenException("Invalid token");

			return principal;
		}
	}
}
