using Microsoft.EntityFrameworkCore;
using PatientManagement.Infrastructure.DomainModel;
using PatientManagement.Domain.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Infrastructure.Repositories
{
   
    internal class InitialConsultationRepository : IInitialConsultationRepository
    {
        private readonly DomainDbContext _dbContext;

        public InitialConsultationRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(InitialConsultation entity)
        {
            await _dbContext.InitialConsultation.AddAsync(entity);

        }

        public async Task DeleteAsync(InitialConsultation initialConsultation)
        {
            var obj = await GetByIdAsync(initialConsultation.Id);
            _dbContext.InitialConsultation.Remove(obj);
        }

        public async Task DeleteAsync(Guid Id)
        {
            var obj = await GetByIdAsync(Id);
            _dbContext.InitialConsultation.Remove(obj);
        }

        public async Task<InitialConsultation?> GetByIdAsync(Guid id)
        {
             return await _dbContext.InitialConsultation.FindAsync(id);
        }


        public Task UpdateAsync(InitialConsultation initialConsultation)
        {
            _dbContext.InitialConsultation.Update(initialConsultation);

            return Task.CompletedTask;

        }
        public async Task<InitialConsultation?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            if (readOnly)
            {
                return await _dbContext.InitialConsultation.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            }
            else
            {
                return await _dbContext.InitialConsultation.FindAsync(id);
            }
        }
    }
}
