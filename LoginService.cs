using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Ajuda;
using Domain;
using Interface;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model;
using Repository;

namespace Novo_Dev
{

    public sealed class LoginService : ILoginService
    {
        private readonly Context Context;
        public LoginService(Context Context)
        {
            this.Context = Context;
        }

        public (User user, string token) Authenticate(Login login)
        {
            var user = Context.Users.SingleOrDefault(u => u.Nome == login.Username && u.Senha == AuthenticationHelper.ComputeHash(login.Password));
            
            // return null if user not found
            if (user == null)
                return (null, null);

            // discard password 
            user.Senha = string.Empty;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret.secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.Regra.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return (user, tokenHandler.WriteToken(token));
        }
    }
}