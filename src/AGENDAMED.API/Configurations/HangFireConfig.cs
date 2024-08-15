using Hangfire;
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

            });


            return services;
    }
    }
}
