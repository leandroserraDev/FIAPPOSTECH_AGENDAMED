using AGENDAMED.Domain.Entities.appointment;
using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Entities.user.doctor;
using AGENDAMED.Domain.Entities.user.doctor.schedule;
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
          

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

        }



    }
}
