using AGENDAMED.Domain.Entities.user.doctor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Infra.Maps.user.doctor
{
    public class DoctorMap : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Ignore(obj => obj.ID);
            builder.HasKey(obj => obj.UserID);


            builder.HasMany(obj => obj.Specialities)
                .WithOne()
                .HasForeignKey(obj => obj.DoctorID);


        }
    }
}
