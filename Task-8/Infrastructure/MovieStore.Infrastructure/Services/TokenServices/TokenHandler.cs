using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieStore.Application.DTOs.TokenDTOs;
using MovieStore.Application.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MovieStore.Infrastructure.Services.TokenServices
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDto CreateAccessToken(int minute)
        {
            TokenDto token = new();
            
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SigninKey"]));
           
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            
            token.Expiration = DateTime.Now.AddMinutes(minute);

            JwtSecurityToken jwtSecurityToken = new(
                audience: _configuration["Token:SigninKey"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials
                );

            
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
