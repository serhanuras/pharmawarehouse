using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using PharmaWarehouse.Api.Modules.Extensions;

namespace PharmaWarehouse.Api.Modules.JwtToken
{
    public class TokenProvider
    {
        private static readonly string MySecret = "asdv234234^&%&^%&^hjsdfb2%%%";
        private static readonly string MyIssuer = "http://xinerji.com";
        private static readonly string MyAudience = "http://xinerji.com";

        public static Claim[] GenerateClaims(string userId, string firstName, string lastname, string role, string roleId, DateTime tokenExpireDate)
        {
            Claim[] claims = new Claim[5];
            claims[0] = new Claim(Enum.GetName(typeof(ClaimType), ClaimType.UserId), userId);
            claims[1] = new Claim(Enum.GetName(typeof(ClaimType), ClaimType.FirstName), firstName);
            claims[2] = new Claim(Enum.GetName(typeof(ClaimType), ClaimType.LastName), lastname);
            claims[3] = new Claim(Enum.GetName(typeof(ClaimType), ClaimType.Role), role);
            claims[4] = new Claim(Enum.GetName(typeof(ClaimType), ClaimType.RoleId), roleId);
            claims[5] = new Claim(Enum.GetName(typeof(ClaimType), ClaimType.TokenExpireDate), tokenExpireDate.ToUnixDate().ToString());

            return claims;
        }

        public static string GenerateToken(Claim[] claims)
        {
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(MySecret));

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = MyIssuer,
                Audience = MyAudience,
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature),
            };

            return string.Empty;
        }

        public static bool ValidateToken(string token)
        {
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(MySecret));

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = MyIssuer,
                    ValidAudience = MyAudience,
                    IssuerSigningKey = mySecurityKey,
                };

                _ = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static string GetClaimValue(string token, ClaimType claimType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            var stringClaimValue = securityToken.Claims.First(claim => claim.Type == Enum.GetName(typeof(ClaimType), claimType)).Value;
            return stringClaimValue;
        }
    }
}
