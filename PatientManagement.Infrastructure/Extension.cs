using PatientManagement.Application;
using PatientManagement.Domain.Abstractions;
using PatientManagement.Domain.Patients;
using PatientManagement.Domain.Users;
using PatientManagement.Domain.Consultations;
using PatientManagement.Infrastructure.DomainModel;
using PatientManagement.Infrastructure.Repositories;
using PatientManagement.Infrastructure.StoredModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using PatientManagement.Domain.Evaluations;

namespace PatientManagement.Infrastructure;
public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<StoredDbContext>(context =>
                context.UseMySql(connectionString,
                    ServerVersion.AutoDetect(connectionString)));
        services.AddDbContext<DomainDbContext>(context =>
                context.UseMySql(connectionString,
                    ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IInitialConsultationRepository, InitialConsultationRepository>();
        services.AddScoped<IPeriodicEvaluationRepository, PeriodicEvaluationRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddAplication();

        return services;
    }
}
