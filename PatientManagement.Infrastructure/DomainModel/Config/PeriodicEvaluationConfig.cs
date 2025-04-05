using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagement.Domain.Evaluations;
using PatientManagement.Domain.Shared;

namespace PatientManagement.Infrastructure.DomainModel.Config
{
    internal class PeriodicEvaluationConfig: IEntityTypeConfiguration<PeriodicEvaluation>
    {
        public void Configure(EntityTypeBuilder<PeriodicEvaluation> builder)
        {
            builder.ToTable("periodicEvaluation");

            builder.HasKey(pe => pe.Id);

            builder.Property(pe => pe.Id)
                .HasColumnName("periodicEvaluationId")
                .IsRequired();

            builder.Property(pe => pe.PatientId)
                .HasColumnName("patientId")
                .IsRequired();

            builder.Property(pe => pe.Date)
                .HasColumnName("date")
                .IsRequired();

            builder.Property(pe => pe.EvaluationNotes)
                .HasColumnName("evaluationNotes")
                .HasMaxLength(2000)
                .IsRequired();

            // Mapeo de WeightValue
            builder.Property(pe => pe.Weight)
                .HasConversion(
                    weight => weight.Value, // De objeto de valor a columna
                    value => new WeightValue(value) // De columna a objeto de valor
                )
                .HasColumnName("weight")
                .IsRequired();

            // Mapeo de HeightValue
            builder.Property(pe => pe.Height)
                .HasConversion(
                    height => height.Value, // De objeto de valor a columna
                    value => new HeightValue(value) // De columna a objeto de valor
                )
                .HasColumnName("height")
                .IsRequired();

            // Mapeo de BloodPressureValue
            builder.OwnsOne(pe => pe.BloodPressure, bp =>
            {
                bp.Property(b => b.Systolic)
                    .HasColumnName("systolic")
                    .IsRequired();

                bp.Property(b => b.Diastolic)
                    .HasColumnName("diastolic")
                    .IsRequired();
            });

            // Mapeo de HeartRateValue
            builder.Property(pe => pe.HeartRate)
                .HasConversion(
                    heartRate => heartRate.Value, // De objeto de valor a columna
                    value => new HeartRateValue(value) // De columna a objeto de valor
                )
                .HasColumnName("heartRate")
                .IsRequired();
        }

    }
}
