using AGENDAMED.API.Configurations;
using AGENDAMED.Application.DTOs.user.auth;
using AGENDAMED.Domain.Entities.user;
using LinqKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AGENDAMED.API.JWT
{
    public class GerarJWT
    {
        private readonly UserManager<User> _userManager;

        public GerarJWT(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public  async Task<string> GerarToken(UserAuthViewModel user, IConfiguration _configuration)
        {
            var appSettings = _configuration.GetSection("AppSetting").Get<AppSettings>();


            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sid, user.Id)) ;
            claims.Add(new Claim(JwtRegisteredClaimNames.Name, user.Nome)) ;
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email)) ;
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.Now).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.Now).ToString()));


            var roles = await _userManager.GetRolesAsync(user.ToDomain());

            roles.ForEach(obj =>
            {
                var newClaim = new Claim("role", obj, obj) ;
                claims.Add(newClaim);
            });


            var identityClaims = new ClaimsIdentity();

            identityClaims.AddClaims(claims);



            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Segredo);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = appSettings.Emissor,
                Audience = appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);


            return await Task.FromResult(encodedToken);
        }

        private static long ToUnixEpochDate(DateTime date) => new DateTimeOffset(date).ToUniversalTime().ToUnixTimeSeconds();

    }
}
