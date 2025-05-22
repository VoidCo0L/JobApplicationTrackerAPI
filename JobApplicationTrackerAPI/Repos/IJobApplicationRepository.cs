using JobApplicationTrackerApi.Models;

namespace JobApplicationTrackerApi.Repositories
{
    public interface IJobApplicationRepository
    {
        IEnumerable<JobApplication> GetAll();
        JobApplication? GetById(int id);
        void Add(JobApplication application);
        void Update(JobApplication application);
        void Delete(int id);
    }
}
