using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Entities.user.patient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Infra.Maps.user.patient
{
    public class PatientMap : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patient");

            builder.Ignore(obj => obj.ID);
            builder.HasKey(obj => obj.UserID);
        }
    }
}
