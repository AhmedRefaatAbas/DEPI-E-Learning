using System.ComponentModel.DataAnnotations;

namespace DEPI_E_Learning.Models
{
    public class SubmissionModel
    {
        [Key]
        public int SubmissionId { get; set; }

        public int StudentId { get; set; }
        public virtual StudentModel Student { get; set; }

        public int AssignmentId { get; set; }
        public virtual AssignmentModel Assignment { get; set; }

        public DateTime SubmittedOn { get; set; }
    }
}
