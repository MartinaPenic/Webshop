using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Webshop.App.Helpers
{
	public class JwtValidation
	{
		private readonly IConfiguration _config;

		public JwtValidation(IConfiguration configuration)
		{
			_config = configuration;
		}

		public bool ValidateToken(string token)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var validationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = "WebApi",
				ValidAudience = "AuthenticatedUsers",
				IssuerSigningKey = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(_config.GetSection("TokenValidation").GetValue<string>("SecretKey")!))
			};

			var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

			var roles = principal.FindAll(ClaimTypes.Role);

			return roles.Any(r => r.Value == "Admin" || r.Value == "ProductManager");
		}
	}
}