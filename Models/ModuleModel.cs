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

        public int SessionId { get; set; } // Foreign Key to Session
        public virtual SessionModel Session { get; set; } // Updated to reference session

        public virtual List<QuizModel> Quizzes { get; set; }
        public virtual List<AssignmentModel> Assignments { get; set; }
    }
    
}
