using System.ComponentModel.DataAnnotations;

namespace DEPI_E_Learning.Models
{
    public class AnswerModel
    {
        [Key]
        public int AnswerId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Text { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public virtual QuestionModel Question { get; set; }

    }
}
