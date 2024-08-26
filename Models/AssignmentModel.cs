using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DEPI_E_Learning.Models
{
    public class AssignmentModel
    {
        [Key]
        public int AssignmentId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public int ModuleId { get; set; }
        public virtual ModuleModel Module { get; set; }

        public virtual ICollection<SubmissionModel> Submissions { get; set; }
    }
}
