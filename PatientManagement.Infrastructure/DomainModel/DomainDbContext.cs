using Microsoft.EntityFrameworkCore;
using PatientManagement.Domain.Abstractions;
using PatientManagement.Domain.Users;
using PatientManagement.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagement.Domain.Consultations;
using PatientManagement.Domain.Evaluations;

namespace PatientManagement.Infrastructure.DomainModel
{
    public class DomainDbContext : DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<InitialConsultation> InitialConsultation { get; set; }
        public DbSet<PeriodicEvaluation> PeriodicEvaluation { get; set; }

        public DomainDbContext(DbContextOptions<DomainDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DomainDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<DomainEvent>();
        }
    }
}
