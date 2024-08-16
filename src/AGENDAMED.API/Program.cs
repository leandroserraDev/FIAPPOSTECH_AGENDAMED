using AGENDAMED.API.Configurations;
using AGENDAMED.API.Controllers;
using AGENDAMED.Domain.Interface.Services.notification;
using AGENDAMED.Domain.Interface.Services.notificationAppointHangFire;
using AGENDAMED.Services.Services.appointment;
using Hangfire;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Hosting;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureEntityFramework();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT();
builder.Services.DepencyInjectionConfigure();
builder.Services.ConfigureSwagger();
builder.Services.HangFireConfiguration();
builder.Services.AddCors(); 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var app = builder.Build();


app.UseHangfireDashboard("/dashboard");
app.UseHangfireServer();


RecurringJob.AddOrUpdate<INotificationAppointmentHangFireService>(obj  => obj.SendEmailDayBeforeAppointment(), Cron.Minutely);


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(options => options.WithOrigins().AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.MapControllers();

app.Run();
