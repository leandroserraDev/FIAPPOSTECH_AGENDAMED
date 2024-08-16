using Hangfire;
using Hangfire.Dashboard;
using Hangfire.PostgreSql;
using System.Runtime.CompilerServices;

namespace AGENDAMED.API.Configurations
{
    public static class HangFireConfig
    {
        public static IServiceCollection HangFireConfiguration(this IServiceCollection services)
        {

            services.AddHangfire(x =>
            {

                var builder = new ConfigurationBuilder()
                             .AddJsonFile("appsettings.json")
                             .Build();
                x.UsePostgreSqlStorage(builder.GetConnectionString("Connection"));

            }
            );


            return services;
    }
     

    }
    public class AllowAllConnectionsFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            // Allow outside. You need an authentication scenario for this part.
            // DON'T GO PRODUCTION WITH THIS LINES.
            return true;
        }
    };
}
