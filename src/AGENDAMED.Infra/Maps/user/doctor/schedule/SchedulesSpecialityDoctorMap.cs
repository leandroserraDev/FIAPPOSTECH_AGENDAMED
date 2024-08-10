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
    public class SchedulesSpecialityDoctorMap : IEntityTypeConfiguration<ScheduleSpecialityDoctor>
    {
        public void Configure(EntityTypeBuilder<ScheduleSpecialityDoctor> builder)
        {
            builder.ToTable("ScheduleSpecialityDoctor");

            builder.Ignore(obj => obj.ID);
            builder.HasKey(obj => new { obj.DoctorID, obj.SpecialityID });



            builder.HasMany(obj => obj.Schedule)
                .WithOne()
                .HasForeignKey(obj => new { obj.DoctorID, obj.Speciality });

        }
    }
}
