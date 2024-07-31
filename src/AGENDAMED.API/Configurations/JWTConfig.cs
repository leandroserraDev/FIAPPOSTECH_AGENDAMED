using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AGENDAMED.API.Configurations
{
    public static class JWTConfig
    {
        public static IServiceCollection ConfigureJWT(this IServiceCollection services)
        {

        var _configurationBuilder = new ConfigurationBuilder();

            var appSettings = _configurationBuilder
                              .AddJsonFile("appsettings.json")
                              .Build()
                              .GetSection("AppSetting")
                              .Get<AppSettings>();

            var key = Encoding.ASCII.GetBytes(appSettings.Segredo);

            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;


            }).AddJwtBearer(j =>
            {
                j.RequireHttpsMetadata = true;
                j.SaveToken = true;
                j.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidAudience = appSettings.ValidoEm,
                    ValidIssuer = appSettings.Emissor
                };
            });


            return services;

        }
    }
}
