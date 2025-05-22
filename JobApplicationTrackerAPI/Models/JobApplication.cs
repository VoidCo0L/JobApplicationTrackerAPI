using System.ComponentModel.DataAnnotations;

namespace JobApplicationTrackerApi.Models
{
    public class JobApplication
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Position { get; set; } = string.Empty;

        [Required]
        public DateTime DateApplied { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Applied";

        [StringLength(500)]
        public string? Feedback { get; set; }
    }
}
