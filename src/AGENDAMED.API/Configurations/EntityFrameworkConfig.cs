using AGENDAMED.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace AGENDAMED.API.Configurations
{
    public static class EntityFrameworkConfig
    {
        public static IServiceCollection Configuration(this IServiceCollection _services, WebApplicationBuilder builder)
        {

            _services.AddDbContext<ApplicationContext>(options=> {
                options.UseNpgsql(builder.Configuration.GetConnectionString("Connection"));
            });

            return _services;

        }
    }
}
