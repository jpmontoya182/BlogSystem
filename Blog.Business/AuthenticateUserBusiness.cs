using Blog.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Blog.Business
{
    public class AuthenticateUserBusiness
    {
        private string _key;
        private string _issuer;
        public AuthenticateUserBusiness(SetUpModel setup)
        {
            _key = setup.JwtKey;
            _issuer = setup.JwtIssuer;
        }
        public string Login(UserModel login)
        {
            string tokenString = string.Empty;

            var user = AuthenticateUser(login);

            if (user)
            {
                tokenString = GenerateJSONWebToken();
            }

            return tokenString;

        }

        private bool AuthenticateUser(UserModel login)
        {
            //Validate the User Credentials    
            if (login.username == "jpmontoya")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_issuer,
              _issuer,
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
