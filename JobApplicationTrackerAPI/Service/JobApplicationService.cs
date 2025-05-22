using JobApplicationTrackerApi.Models;
using JobApplicationTrackerApi.Repositories;

namespace JobApplicationTrackerApi.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobApplicationRepository _repository;

        public JobApplicationService(IJobApplicationRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<JobApplication> GetAll() => _repository.GetAll();

        public JobApplication? GetById(int id) => _repository.GetById(id);

        public void Add(JobApplication application) => _repository.Add(application);

        public void Update(JobApplication application) => _repository.Update(application);

        public void Delete(int id) => _repository.Delete(id);
    }
}
