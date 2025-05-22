using JobApplicationTrackerApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationTrackerApi.Repositories
{
    public interface IJobApplicationRepository
    {
        Task<IEnumerable<JobApplication>> GetAllAsync();
        Task<JobApplication?> GetByIdAsync(int id);
        Task AddAsync(JobApplication application);
        Task UpdateAsync(JobApplication application);
        Task DeleteAsync(int id);
    }
}
