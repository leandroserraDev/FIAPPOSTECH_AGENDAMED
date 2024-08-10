using AGENDAMED.Domain.Entities.user.doctor.schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Infra.Maps.user.doctor.schedule
{
    public class ScheduleMap : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedule");

            builder.HasKey(obj => new {obj.DoctorID, obj.DayOfWeek, obj.Speciality});

            builder.HasMany(obj => obj.ScheduleTime)
                .WithOne()
                .HasForeignKey(obj => new { obj.DoctorID, obj.DayOfWeek, obj.Speciality });


        }
    }
}
