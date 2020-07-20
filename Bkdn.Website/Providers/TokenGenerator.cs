using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Bkdn.Website.Configs;
using BusinessLogic.Contract;
using BusinessLogic.Models;
using BusinessLogic.Models.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Bkdn.Website.Providers
{
    public interface ITokenGenerator
    {
        Task<string> GenerateToken(UserLogin userLogin);
    }

    public class TokenGenerator : ITokenGenerator
    {
        private readonly AppSettings options;
        private readonly IAuthBusiness authBusiness;
        
        public readonly SigningCredentials SigningCredentials;
        
        public TokenGenerator(
            IOptions<AppSettings> options,
            IAuthBusiness authBusiness)
        {
            this.options = options.Value;
            this.authBusiness = authBusiness;
            
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.options.Secret));
            SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        }

        private static Claim CreateClaim(string type, string value)
        {
            return new Claim(type, value, null, ClaimsIdentity.DefaultIssuer, "Provider");
        }
        
        private async Task<ClaimsIdentity> GetIdentity(UserLogin userLogin)
        {
            var user = await authBusiness.Login(userLogin);

            var claims = new List<Claim>
            {
                CreateClaim(ClaimTypes.NameIdentifier, user.Username),
                CreateClaim(ClaimTypes.Name, user.Username),
                CreateClaim(ClaimTypes.GivenName, user.Fullname),
            };

            return new ClaimsIdentity(claims, "Bearer");
        }
        
        public async Task<string> GenerateToken(UserLogin userLogin)
        {
            var identity = await GetIdentity(userLogin);

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                claims: identity.Claims,
                notBefore: now,
                expires: now.AddSeconds(options.Expiration),
                signingCredentials: SigningCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}