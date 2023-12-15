using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormulaOneApp.Data.Models
{
    public class Option
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(1)]
        public string OptionText { get; set; } = null!;

        public bool IsCorrectOption { get; set; }

        [ForeignKey(nameof(Question))]
        public Guid QuestionId { get; set; }
        public Question Question { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;
    }
}
