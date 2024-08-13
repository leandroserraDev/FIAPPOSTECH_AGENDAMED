using AGENDAMED.Application.AppServices.serviceBase;
using AGENDAMED.Application.AppServices.user.auth;
using AGENDAMED.Application.AppServices.user.doctor;
using AGENDAMED.Application.AppServices.user.doctor.schedule;
using AGENDAMED.Application.AppServices.user.doctor.specialy;
using AGENDAMED.Application.Interface.AppServices;
using AGENDAMED.Application.Interface.AppServices.speciality;
using AGENDAMED.Application.Interface.AppServices.user.auth;
using AGENDAMED.Application.Interface.AppServices.user.doctor;
using AGENDAMED.Application.Interface.AppServices.user.doctor.schedule;
using AGENDAMED.Domain.Interface.Repositories;
using AGENDAMED.Domain.Interface.Repositories.appointment;
using AGENDAMED.Domain.Interface.Repositories.speciality;
using AGENDAMED.Domain.Interface.Repositories.user;
using AGENDAMED.Domain.Interface.Repositories.user.doctor.schedule;
using AGENDAMED.Domain.Interface.Services;
using AGENDAMED.Domain.Interface.Services.appointment;
using AGENDAMED.Domain.Interface.Services.calendar;
using AGENDAMED.Domain.Interface.Services.notification;
using AGENDAMED.Domain.Interface.Services.speciality;
using AGENDAMED.Domain.Interface.Services.user;
using AGENDAMED.Domain.Interface.Services.user.auth;
using AGENDAMED.Domain.Interface.Services.user.doctor.schedule;
using AGENDAMED.Infra.Repositories;
using AGENDAMED.Infra.Repositories.appointment;
using AGENDAMED.Infra.Repositories.speciality;
using AGENDAMED.Infra.Repositories.user;
using AGENDAMED.Infra.Repositories.user.schedule;
using AGENDAMED.Services.Services;
using AGENDAMED.Services.Services.appointment;
using AGENDAMED.Services.Services.calendar;
using AGENDAMED.Services.Services.notification;
using AGENDAMED.Services.Services.speciality;
using AGENDAMED.Services.Services.user;
using AGENDAMED.Services.Services.user.auth;
using AGENDAMED.Services.Services.user.doctor.schedule;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AGENDAMED.API.Configurations
{
    public static class DepencyInjectionConfig
    {
        public static IServiceCollection DepencyInjectionConfigure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IScheduleSpecialityDoctorRepository, ScheduleSpecialityDoctorRepository>();
            services.AddScoped<IDoctorSpecialityRepository,DoctorSpecialityRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();

            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<ICalendarService, CalendarService>();
            services.AddScoped<INotificationErrorService, NotificationErrorService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IScheduleSpecialityDoctorService, ScheduleSpecialityDoctorService>();
            services.AddScoped<IDoctorSpecialityService, DoctorSpecialityService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            services.AddScoped<IUserDoctorAppService, UserDoctorAppService>();
            services.AddScoped<IDoctorSpecialityAppService, DoctorSpecialityAppService>();
            services.AddScoped<IScheduleSpecialityDoctorAppService, ScheduleSpecialityDoctorAppService>();
            services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();

            return services;
        }
    }
}
