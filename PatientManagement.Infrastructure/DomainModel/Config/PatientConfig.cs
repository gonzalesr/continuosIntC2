using PatientManagement.Domain.Patients;
using PatientManagement.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PatientManagement.Infrastructure.DomainModel.Config
{
    internal class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("patient");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("patientId");

            builder.Property(x => x.Name)
                .HasColumnName("name");

            builder.Property(x => x.BirthDate)
                .HasColumnName("birthDate");

            builder.Property(x => x.Gender)
               .HasColumnName("gender");

           var converter = new ValueConverter<EmailValue, string>(
                emailValue => emailValue.Value, 
                email => new EmailValue(email) 
            );

            builder.Property(x => x.Email)
                .HasConversion(converter)
                .HasColumnName("email")
                .IsRequired();

            builder.HasMany(p => p.Phones)
                .WithOne()
                .HasForeignKey(phone => phone.PatientId) // Clave foránea explícita
                .IsRequired();

            builder.HasMany(p => p.Consultations)
                .WithOne()
                .HasForeignKey(c => c.PatientId) // Clave foránea explícita
                .IsRequired();

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
