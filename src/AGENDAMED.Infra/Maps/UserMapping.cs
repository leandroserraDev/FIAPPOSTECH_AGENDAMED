using AGENDAMED.Domain.Entities.user;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Infra.Maps
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(usr => usr.ID);

            builder.Property(usr => usr.Name)
                .HasColumnType("varchar(12)")
                .IsRequired();

            builder.Property(usr => usr.LastName)
                .HasColumnType("varchar(25)")
                .IsRequired();

            builder.Property(usr => usr.BirthDate)
             .IsRequired();
           
            builder.Property(usr => usr.TypePerson)
             .IsRequired();

            builder.Property(usr => usr.Document)
            .IsRequired();


            builder.Property(usr => usr.AddressImagePhoto)
            .IsRequired();

        }
    }
}
