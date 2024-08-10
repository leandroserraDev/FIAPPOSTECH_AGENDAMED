using AGENDAMED.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace AGENDAMED.API.Configurations
{
    public static class EntityFrameworkConfig
    {
        public static IServiceCollection ConfigureEntityFramework(this IServiceCollection _services)
        {
            var builder = new ConfigurationBuilder()
                              .AddJsonFile("appsettings.json")
                              .Build();

            _services.AddDbContext<ApplicationContext>(options=> {
                options.UseNpgsql(builder.GetConnectionString("Connection"));
            });

            return _services;

        }
    }
}
