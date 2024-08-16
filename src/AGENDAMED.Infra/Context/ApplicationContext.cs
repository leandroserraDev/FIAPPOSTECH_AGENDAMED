using AGENDAMED.Domain.Entities.appointment;
using AGENDAMED.Domain.Entities.speciality;
using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Entities.user.doctor;
using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Infra.Maps.user.doctor.schedule;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Infra.Context
{
    public class ApplicationContext : IdentityDbContext<User>
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> dbContext)
            :base(dbContext)
        {


            
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DoctorSpecialities> DoctorSpecialities{ get; set; }
        public DbSet<ScheduleSpecialityDoctor> ScheduleSpecialityDoctors { get; set; }

        public DbSet<Schedule> Schedules{ get; set; }
        public DbSet<ScheduleTime> ScheduleTimes{ get; set; }



        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var changeTrack = ChangeTracker.Entries();

            var entities = ChangeTracker.Entries();
            foreach (var entityEntry in entities)
            {

                if (entityEntry.State == EntityState.Modified)
                {


                    if (entityEntry.OriginalValues.Properties.Any(obj => obj.Name == "DtModified"))
                    {
                        entityEntry.Property("DtModified").CurrentValue = DateTime.UtcNow;
                    }
                }
                else if (entityEntry.State == EntityState.Added)
                {


                    if (entityEntry.OriginalValues.Properties.Any(obj => obj.Name == "DtCreated"))
                    {
                        entityEntry.Property("DtCreated").CurrentValue = DateTime.UtcNow;
                    }


                    if (entityEntry.OriginalValues.Properties.Any(obj => obj.Name == "DtModified"))
                    {
                        entityEntry.Property("DtModified").CurrentValue = DateTime.UtcNow;
                    }

                }

            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ADMIN_ID = Guid.NewGuid();


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var appUser = new User
            {
                Id = ADMIN_ID.ToString(),
                Email = "administrador@administrador.com",
                EmailConfirmed = true,
                UserName = "administrador@administrador.com",
                Name = "administrador@administrador.com",
                LastName = "administrador@administrador.com",
                NormalizedEmail = "ADMINISTRADOR@ADMINISTRADOR.COM",
                NormalizedUserName = "ADMINISTRADOR@ADMINISTRADOR.COM"
            };


            

            //set user password
            PasswordHasher<User> ph = new PasswordHasher<User>();
            appUser.PasswordHash = ph.HashPassword(appUser, "Admin123*#");

            //seed user
            modelBuilder.Entity<User>().HasData(appUser);


            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = ADMIN_ID.ToString(),
            });

            var speciality = new List<Speciality>();

            speciality.Add(new() { ID = 1, Name = "Clínico Geral", Description = "CLÍNICO GERAL" });
            speciality.Add(new() { ID = 2, Name = "Ortopedista", Description = "ORTOPEDISTA" });
            speciality.Add(new() { ID = 3, Name = "Pediatra", Description = "PEDIATRA" });

            modelBuilder.Entity<Speciality>().HasData(speciality);


            base.OnModelCreating(modelBuilder);

        }



    }
}
