using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DEPI_E_Learning.Models
{
    public class CourseModel
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public int InstructorId { get; set; }
        public virtual InstructorModel Instructor { get; set; }

        public virtual List<ModuleModel> Modules { get; set; }
        public virtual ICollection<SessionModel> Sessions { get; set; } // Updated to include sessions
    }
}
    

    
