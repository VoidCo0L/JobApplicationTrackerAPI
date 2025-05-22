using JobApplicationTrackerApi.Models;

namespace JobApplicationTrackerApi.Services
{
    public interface IJobApplicationService
    {
        IEnumerable<JobApplication> GetAll();
        JobApplication? GetById(int id);
        void Add(JobApplication application);
        void Update(JobApplication application);
        void Delete(int id);
    }
}
