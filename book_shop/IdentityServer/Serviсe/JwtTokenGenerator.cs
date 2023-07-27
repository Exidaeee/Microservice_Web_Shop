using IdentityServer.Model;
using IdentityServer.Serviсe.IService;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace IdentityServer.Serviсe
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public readonly JwtOptions _options;
        public JwtTokenGenerator(IOptions<JwtOptions> options)
        {

            _options = options.Value;

        }
        public string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // Генерация ключа размером 256 бит (32 байта) с использованием RNGCryptoServiceProvider
            byte[] key;
            using (var rng = new RNGCryptoServiceProvider())
            {
                key = new byte[32];
                rng.GetBytes(key);
            }

            var caimList = new List<Claim>
            { 
                new Claim(JwtRegisteredClaimNames.Name, applicationUser.UserName),
                new Claim(JwtRegisteredClaimNames.Email, applicationUser.Email),          
                new Claim(JwtRegisteredClaimNames.Sub, applicationUser.Id)
            };

            caimList.AddRange(roles.Select(roles => new Claim(ClaimTypes.Role, roles)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _options.Audience,
                Issuer = _options.Issuer,
                Subject = new ClaimsIdentity(caimList),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
