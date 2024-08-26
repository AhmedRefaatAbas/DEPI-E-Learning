using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DEPI_E_Learning.Models
{
    public class QuizModel
    {
        [Key]
        public int QuizId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public int ModuleId { get; set; }
        public virtual ModuleModel Module { get; set; }

        public virtual ICollection<QuestionModel> Questions { get; set; }
    }
}
