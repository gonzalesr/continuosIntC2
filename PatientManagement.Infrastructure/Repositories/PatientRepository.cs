using Microsoft.EntityFrameworkCore;
using PatientManagement.Domain.Patients;
using PatientManagement.Infrastructure.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Infrastructure.Repositories
{
   
    internal class PatientRepository : IPatientRepository
    {
        private readonly DomainDbContext _dbContext;

        public PatientRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Patient entity)
        {
            await _dbContext.Patient.AddAsync(entity);

        }

        public async Task DeleteAsync(Patient patient)
        {
            var obj = await GetByIdAsync(patient.Id);
            _dbContext.Patient.Remove(obj);
        }

        public async Task DeleteAsync(Guid Id)
        {
            var obj = await GetByIdAsync(Id);
            _dbContext.Patient.Remove(obj);
        }

        public async Task<Patient?> GetByIdAsync(Guid id)
        {
             return await _dbContext.Patient.FindAsync(id);
        }


        public Task UpdateAsync(Patient item)
        {
            _dbContext.Patient.Update(item);

            return Task.CompletedTask;

        }
        public async Task<Patient?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            if (readOnly)
            {
                return await _dbContext.Patient.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            }
            else
            {
                return await _dbContext.Patient.FindAsync(id);
            }
        }
    }
}
