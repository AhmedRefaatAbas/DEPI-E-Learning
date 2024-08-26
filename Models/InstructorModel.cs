using System.ComponentModel.DataAnnotations;

namespace DEPI_E_Learning.Models
{
    public class InstructorModel
    {
        [Key]
        public int InstructorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<CourseModel> Courses { get; set; }
    }

}
