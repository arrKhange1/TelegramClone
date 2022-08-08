using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;
using TelegramClone.Models.DTO;

namespace TelegramClone.Services
{
    public class JWTService
    {
		private readonly IConfiguration _config;
		private readonly IRoleRepository _roleRepository;
		private readonly IUserRepository _userRepository;

		public JWTService(IConfiguration configuration,
			IRoleRepository roleRepository,
			IUserRepository userRepository)
		{
			_config = configuration;
			_roleRepository = roleRepository;
			_userRepository = userRepository;

		}

		public void AddAccessTokenInCookie(HttpContext httpContext, string token)
		{
			httpContext.Response.Cookies.Append("access", token);
			
		}

		public string GetAccessTokenFromCookie(HttpContext httpContext)
		{
			return httpContext.Request.Cookies["access"];
		}

		public string GenerateAccessToken(User user)
		{
			try
			{
				Role userRole = _roleRepository.GetRoleById(user);
				var tokenHandler = new JwtSecurityTokenHandler();
				var tokenKey = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = new ClaimsIdentity(new Claim[]
				  {
						new Claim(ClaimTypes.NameIdentifier, user.UserName),
						new Claim(ClaimTypes.Role, userRole.RoleName)

				  }),
					Expires = DateTime.Now.AddSeconds(10),
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
				};
				var token = tokenHandler.CreateToken(tokenDescriptor);
				return tokenHandler.WriteToken(token);
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
		{
			var Key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = false,
				ValidateAudience = false,
				ValidateLifetime = false,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Key),
				ClockSkew = TimeSpan.Zero
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
			JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
			if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
			{
				throw new SecurityTokenException("Invalid token");
			}


			return principal;
		}

		public User GetUserFromToken(string token)
        {
			var principal = GetPrincipalFromExpiredToken(token);
			var userName = principal.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
			var user = _userRepository.GetUserByUsername(userName);
			return user;
		}
	}
}
