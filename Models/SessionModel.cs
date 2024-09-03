using System.ComponentModel.DataAnnotations;

namespace DEPI_E_Learning.Models
{
    public class SessionModel
    {
        [Key]
        public int SessionId { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime ScheduledDate { get; set; }

        // Foreign Key to Course
        public int CourseId { get; set; }
        public virtual CourseModel Course { get; set; }

        // Collection of Modules
        public virtual ICollection<ModuleModel> Modules { get; set; } // Updated to include modules
    }
}
