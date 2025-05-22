using System.Text.Json;
using JobApplicationTrackerApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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

        public Task<IEnumerable<JobApplication>> GetAllAsync()
        {
            return Task.FromResult(_applications.AsEnumerable());
        }

        public Task<JobApplication?> GetByIdAsync(int id)
        {
            var app = _applications.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(app);
        }

        public async Task AddAsync(JobApplication application)
        {
            application.Id = _nextId++;
            _applications.Add(application);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(JobApplication application)
        {
            var existing = _applications.FirstOrDefault(a => a.Id == application.Id);
            if (existing != null)
            {
                existing.CompanyName = application.CompanyName;
                existing.Position = application.Position;
                existing.DateApplied = application.DateApplied;
                existing.Status = application.Status;
                existing.Feedback = application.Feedback;
                await SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var app = _applications.FirstOrDefault(a => a.Id == id);
            if (app != null)
            {
                _applications.Remove(app);
                await SaveChangesAsync();
            }
        }

        private void SaveChanges()
        {
            var json = JsonSerializer.Serialize(_applications, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        private async Task SaveChangesAsync()
        {
            var json = JsonSerializer.Serialize(_applications, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}
