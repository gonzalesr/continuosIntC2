using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientManagement.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Infrastructure.DomainModel.Config
{
    internal class PhoneConfig : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.ToTable("phone");

            builder.HasKey(ph => ph.Id);

            builder.Property(ph => ph.Id)
                .HasColumnName("phoneId")
                .IsRequired();

            builder.Property(ph => ph.PatientId)
                .HasColumnName("patientId")
                .IsRequired();

            builder.Property(ph => ph.Number)
                .HasColumnName("number")
                .HasMaxLength(50)
                .IsRequired();

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
}
}
