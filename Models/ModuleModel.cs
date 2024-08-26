using System.ComponentModel.DataAnnotations;

namespace DEPI_E_Learning.Models
{
    public class ModuleModel
    {
        [Key]
        public int ModuleId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string ContentUrl { get; set; }

        public int CourseId { get; set; }
        public virtual CourseModel Course { get; set; }

        public virtual List<QuizModel> Quizzes { get; set; }
        public virtual List<AssignmentModel> Assignments { get; set; }
    }
}
