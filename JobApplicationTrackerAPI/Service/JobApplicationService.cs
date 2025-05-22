using JobApplicationTrackerApi.Models;
using JobApplicationTrackerApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationTrackerApi.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobApplicationRepository _repository;

        public JobApplicationService(IJobApplicationRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<JobApplication>> GetAllAsync() => _repository.GetAllAsync();

        public Task<JobApplication?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task AddAsync(JobApplication application) => _repository.AddAsync(application);

        public Task UpdateAsync(JobApplication application) => _repository.UpdateAsync(application);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
