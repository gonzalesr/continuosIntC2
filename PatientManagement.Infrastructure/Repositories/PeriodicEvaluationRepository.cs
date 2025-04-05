using Microsoft.EntityFrameworkCore;
using PatientManagement.Domain.Consultations;
using PatientManagement.Domain.Evaluations;
using PatientManagement.Infrastructure.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PatientManagement.Infrastructure.Repositories
{
    internal class PeriodicEvaluationRepository:IPeriodicEvaluationRepository
    {
        private readonly DomainDbContext _dbContext;

        public PeriodicEvaluationRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(PeriodicEvaluation entity)
        {
            await _dbContext.PeriodicEvaluation.AddAsync(entity);

        }

        public async Task DeleteAsync(PeriodicEvaluation periodicEvaluation)
        {
            var obj = await GetByIdAsync(periodicEvaluation.Id);
            _dbContext.PeriodicEvaluation.Remove(obj);
        }

        public async Task DeleteAsync(Guid Id)
        {
            var obj = await GetByIdAsync(Id);
            _dbContext.PeriodicEvaluation.Remove(obj);
        }

        public async Task<PeriodicEvaluation?> GetByIdAsync(Guid id)
        {
            return await _dbContext.PeriodicEvaluation.FindAsync(id);
        }


        public Task UpdateAsync(PeriodicEvaluation periodicEvaluation)
        {
            _dbContext.PeriodicEvaluation.Update(periodicEvaluation);

            return Task.CompletedTask;

        }
        public async Task<PeriodicEvaluation?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            if (readOnly)
            {
                return await _dbContext.PeriodicEvaluation.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            }
            else
            {
                return await _dbContext.PeriodicEvaluation.FindAsync(id);
            }
        }
    }
}
