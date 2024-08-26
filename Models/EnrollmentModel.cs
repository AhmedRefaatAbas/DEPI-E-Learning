using System.ComponentModel.DataAnnotations;

namespace DEPI_E_Learning.Models
{
    public class EnrollmentModel
    {
        [Key]
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }
        public virtual StudentModel Student { get; set; }

        public int CourseId { get; set; }
        public virtual CourseModel Course { get; set; }

        public DateTime EnrolledOn { get; set; }
        public DateTime? CompletionDate { get; set; }
    }
}
