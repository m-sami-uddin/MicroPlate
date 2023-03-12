using MicroPlate.JwtAuthenticationManager.Models;
using MicroPlate.JwtAuthenticationManager.Models.Login;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
//using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace MicroPlate.JwtAuthenticationManager
{
    public interface IJwtTokenHandler
    {
        public LoginResponseDto? GenerateJwtToken(UserAccount userAccount);
    }
    public class JwtTokenHandler : IJwtTokenHandler
    {
        private readonly IConfiguration _configuration;

        public JwtTokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public LoginResponseDto? GenerateJwtToken(UserAccount userAccount)
        {
            var CurrentDateTime = DateTime.Now;
            var tokenExpiryTimeStamp = CurrentDateTime.AddMinutes(_configuration.GetValue<int>("Jwt:Validity"));
            var tokenKey = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Jwt:SigningKey") ?? "");
            var claimsIdentity = new ClaimsIdentity(new List<Claim> {
            new Claim(JwtRegisteredClaimNames.Name, userAccount.UserName),
            new Claim(ClaimTypes.Role,userAccount.Role.ToString())
            });
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);
            return new LoginResponseDto
            {
                UserName = userAccount.UserName,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(CurrentDateTime).TotalSeconds,
                AccessToken = token,
            };

        }
    }
}
