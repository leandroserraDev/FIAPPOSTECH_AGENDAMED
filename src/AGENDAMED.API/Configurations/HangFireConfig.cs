using AGENDAMED.Infra.Context;
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
            var builder = new ConfigurationBuilder()
                         .AddJsonFile("appsettings.json")
                         .Build();
            services.AddHangfire(x =>


                x.UsePostgreSqlStorage(builder.GetConnectionString("Connection"))

            );



            return services;
    }
     

    }

}
