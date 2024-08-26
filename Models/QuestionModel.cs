using System.ComponentModel.DataAnnotations;

namespace DEPI_E_Learning.Models
{
    public class QuestionModel
    {
        [Key]
        public int QuestionId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Text { get; set; }

        public int QuizId { get; set; }
        public virtual QuizModel Quiz { get; set; }

        public virtual ICollection<AnswerModel> Answers { get; set; }
    }
}
