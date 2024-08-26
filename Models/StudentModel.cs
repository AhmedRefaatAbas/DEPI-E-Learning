using System.ComponentModel.DataAnnotations;

namespace DEPI_E_Learning.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<EnrollmentModel> Enrollments { get; set; }
        public virtual ICollection<SubmissionModel> Submissions { get; set; }
    }
}
