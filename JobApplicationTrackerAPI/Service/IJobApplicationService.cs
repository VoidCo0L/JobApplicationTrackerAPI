using JobApplicationTrackerApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationTrackerApi.Services
{
    public interface IJobApplicationService
    {
        Task<IEnumerable<JobApplication>> GetAllAsync();
        Task<JobApplication?> GetByIdAsync(int id);
        Task AddAsync(JobApplication application);
        Task UpdateAsync(JobApplication application);
        Task DeleteAsync(int id);
    }
}
