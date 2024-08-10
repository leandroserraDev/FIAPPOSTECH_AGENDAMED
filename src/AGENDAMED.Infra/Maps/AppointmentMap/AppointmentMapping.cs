using AGENDAMED.Domain.Entities.appointment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Infra.Maps.AppointmentMap
{
    public class AppointmentMapping : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointment");

            builder.HasKey(obj => obj.ID);

            builder.HasOne(obj => obj.Patient)
                .WithMany()
                .HasForeignKey(obj => obj.PatientID)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(obj => obj.Doctor)
                .WithMany()
                .HasForeignKey(obj => obj.DoctorID)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(obj => obj.Speciality)
                .WithMany()
                .HasForeignKey(obj => obj.SpecialityID)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
