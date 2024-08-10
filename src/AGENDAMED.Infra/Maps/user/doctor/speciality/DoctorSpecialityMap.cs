using AGENDAMED.Domain.Entities;
using AGENDAMED.Domain.Entities.user.doctor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Infra.Maps.user.doctor.speciality
{
    public class DoctorSpecialityMap : IEntityTypeConfiguration<DoctorSpecialities>
    {
        public void Configure(EntityTypeBuilder<DoctorSpecialities> builder)
        {
            builder.ToTable("DoctorSpecialities");

            builder.Ignore(obj => obj.ID);

            builder.HasKey(obj => new {obj.DoctorID, obj.SpecialtyID});

            builder.HasOne(obj => obj.Speciality)
                .WithMany()
                .HasForeignKey(obj => obj.SpecialtyID);

            builder.HasMany(obj => obj.SchedulesSpecialityDoctor)
                .WithOne()
                .HasForeignKey(obj => new { obj.DoctorID, obj.SpecialityID });
         }
    }
}
