using PatientManagement.Domain.Consultations;
using PatientManagement.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientManagement.Domain.Patients;

namespace PatientManagement.Infrastructure.DomainModel.Config
{
    internal class InitialConstultationConfig : IEntityTypeConfiguration<InitialConsultation>
    {
        public void Configure(EntityTypeBuilder<InitialConsultation> builder)
        {
            builder.ToTable("initialConsultation");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("initialConsultationId")
                .IsRequired();

            builder.Property(x => x.PatientId)
                .HasColumnName("patientId")
                .IsRequired(); ;

            builder.Property(x => x.Date)
                .HasColumnName("date");

            builder.Property(x => x.Reason)
               .HasColumnName("reason");

            builder.Property(x => x.Observations)
                .HasColumnName("observations");

            // Relación muchos a uno con Patient
            builder.HasOne<Patient>()
                .WithMany(p => p.Consultations)
                .HasForeignKey(ic => ic.PatientId)
                .IsRequired();

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
