using Microsoft.EntityFrameworkCore;
using JobApplicationTrackerApi.Models;

namespace JobApplicationTrackerApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<JobApplication> JobApplications => Set<JobApplication>();
    }
}
