using ApiCompras.Domain.Authentication;
using ApiCompras.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiCompras.Infra.Data.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        // Your secret key as a string
        private const string SecretKey = "mpcurso_api_AKLSJ/ksldja/uashd==";

        public dynamic Generator(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim("Id", user.Id.ToString())
            };

            var expires = DateTime.Now.AddDays(1);

            // Convert the secret key to a byte array
            var keyBytes = Encoding.UTF8.GetBytes(SecretKey);

            var tokenData = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature),
                expires: expires,
                claims: claims
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenData);
            return new
            {
                access_token = token,
                expiration = expires
            };
        }
    }
}
