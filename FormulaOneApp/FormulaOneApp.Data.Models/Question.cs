using System.ComponentModel.DataAnnotations;

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

        [Required]
        [MinLength(1)]
        public string CorrectAnswer { get; set; } = null!;

        [Required]
        [MinLength(1)]
        public string WrongAnswerOne { get; set; } = null!;

        [Required]
        [MinLength(1)]
        public string WrongAnswerTwo { get; set; } = null!;

        [Required]
        [MinLength(1)]
        public string WrongAnswerThree { get; set; } = null!;

        public DateTime? UploadDate { get; set; } = null;

        public string? Explanation { get; set; }

        public byte[]? Media { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
