namespace JobApplicationTrackerApi.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime DateApplied { get; set; }
        public string Status { get; set; }
        public string? Feedback { get; set; }
    }
}
