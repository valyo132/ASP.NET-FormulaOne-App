using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using FormulaOneApp.Data.Models.Enums;

namespace FormulaOneApp.Data.Models
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Text { get; set; } = null!;

        [Required]
        public Category Category { get; set; }

        [Required]
        public Difficulty Difficulty { get; set; }

        public ICollection<Option> Options { get; set; } = new List<Option>();

        public string? Explanation { get; set; }

        public byte[]? Media { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
