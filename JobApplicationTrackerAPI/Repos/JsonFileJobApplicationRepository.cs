using System.Text.Json;
using JobApplicationTrackerApi.Models;

namespace JobApplicationTrackerApi.Repositories
{
    public class JsonFileJobApplicationRepository : IJobApplicationRepository
    {
        private readonly string _filePath = "jobApplications.json";
        private List<JobApplication> _applications;
        private int _nextId;

        public JsonFileJobApplicationRepository()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _applications = JsonSerializer.Deserialize<List<JobApplication>>(json) ?? new List<JobApplication>();
                _nextId = _applications.Any() ? _applications.Max(a => a.Id) + 1 : 1;
            }
            else
            {
                _applications = new List<JobApplication>();
                _nextId = 1;
                SaveChanges();
            }
        }

        public IEnumerable<JobApplication> GetAll() => _applications;

        public JobApplication? GetById(int id) =>
            _applications.FirstOrDefault(a => a.Id == id);

        public void Add(JobApplication application)
        {
            application.Id = _nextId++;
            _applications.Add(application);
            SaveChanges();
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
                SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var app = GetById(id);
            if (app != null)
            {
                _applications.Remove(app);
                SaveChanges();
            }
        }

        private void SaveChanges()
        {
            var json = JsonSerializer.Serialize(_applications, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
