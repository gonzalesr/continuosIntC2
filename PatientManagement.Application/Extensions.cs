
using PatientManagement.Domain.Patients;
using PatientManagement.Domain.Consultations;
using PatientManagement.Domain.Evaluations;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Application
{
     public static class Extensions
     {
          public static IServiceCollection AddAplication(this IServiceCollection services) {
               services.AddMediatR(config =>
                   config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
               );


               services.AddSingleton<IPatientFactory, PatientFactory>();
               services.AddSingleton<IInitialConsultationFactory, InitialConsultationFactory>();
               services.AddSingleton<IPeriodicEvaluationFactory, PeriodicEvaluationFactory>();

               return services;
          }

     }
}
