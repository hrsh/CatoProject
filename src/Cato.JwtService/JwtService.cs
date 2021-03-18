using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cato.JwtService
{
    public class JwtService : IJwtService
    {
        private readonly string _secretKey = "this_is_not_a_$secre@_key";

        public string Token
        {
            get
            {
                var descriptor = new SecurityTokenDescriptor
                {
                    Issuer = "jigsaw",
                    Audience = "jigsaw",
                    IssuedAt = DateTime.Now,
                    NotBefore = DateTime.Now,
                    Expires = DateTime.Now.AddDays(7),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_secretKey)),
                            SecurityAlgorithms.HmacSha256),
                    Subject = new ClaimsIdentity(SetIdentityClaims),
                    Claims = SetClaims
                };

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(descriptor);
                var jwt = handler.WriteToken(securityToken);

                return jwt;
            }
        }

        private static IEnumerable<Claim> SetIdentityClaims =>
            new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, "1081"),
                new Claim(JwtRegisteredClaimNames.Gender, "male"),
                new Claim(ClaimTypes.Role, "writer"),
                new Claim(ClaimTypes.Role, "admin")
            };

        private static Dictionary<string, object> SetClaims =>
            new Dictionary<string, object>
            {

            };
    }
}
