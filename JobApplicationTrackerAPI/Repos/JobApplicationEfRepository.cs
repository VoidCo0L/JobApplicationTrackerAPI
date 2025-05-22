using JobApplicationTrackerApi.Data;
using JobApplicationTrackerApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationTrackerApi.Repositories
{
    public class JobApplicationEfRepository : IJobApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public JobApplicationEfRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobApplication>> GetAllAsync()
        {
            return await _context.JobApplications.ToListAsync();
        }

        public async Task<JobApplication?> GetByIdAsync(int id)
        {
            return await _context.JobApplications.FindAsync(id);
        }

        public async Task AddAsync(JobApplication application)
        {
            _context.JobApplications.Add(application);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(JobApplication application)
        {
            _context.Entry(application).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var application = await _context.JobApplications.FindAsync(id);
            if (application != null)
            {
                _context.JobApplications.Remove(application);
                await _context.SaveChangesAsync();
            }
        }
    }
}
