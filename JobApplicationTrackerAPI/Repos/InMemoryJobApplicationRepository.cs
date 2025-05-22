using JobApplicationTrackerApi.Models;

namespace JobApplicationTrackerApi.Repositories
{
    public class InMemoryJobApplicationRepository : IJobApplicationRepository
    {
        private readonly List<JobApplication> _applications = new();
        private int _nextId = 1;

        public IEnumerable<JobApplication> GetAll() => _applications;

        public JobApplication? GetById(int id) =>
            _applications.FirstOrDefault(a => a.Id == id);

        public void Add(JobApplication application)
        {
            application.Id = _nextId++;
            _applications.Add(application);
        }

        public void Update(JobApplication application)
        {
            var existing = GetById(application.Id);
            if (existing != null)
            {
                existing.CompanyName = application.CompanyName;
                existing.Position = application.Position;
                existing.DateApplied = application.DateApplied;
                existing.Status = application.Status;
                existing.Feedback = application.Feedback;
            }
        }

        public void Delete(int id)
        {
            var app = GetById(id);
            if (app != null)
            {
                _applications.Remove(app);
            }
        }
    }
}
