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
    public class ScheduleHourMap : IEntityTypeConfiguration<ScheduleTime>
    {
        public void Configure(EntityTypeBuilder<ScheduleTime> builder)
        {
            builder.ToTable("ScheduleHour");
            builder.HasKey(obj => new {obj.DoctorID, obj.DayOfWeek, obj.Speciality, obj.Time });




        }
    }
}
