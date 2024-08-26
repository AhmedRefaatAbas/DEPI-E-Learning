using System.ComponentModel.DataAnnotations;

namespace DEPI_E_Learning.Models
{
    public class AdminModel
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
