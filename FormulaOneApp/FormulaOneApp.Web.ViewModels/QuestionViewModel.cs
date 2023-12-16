using FormulaOneApp.Data.Models;
using FormulaOneApp.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FormulaOneApp.Web.ViewModels
{
    public class QuestionViewModel
    {
        public Guid Id { get; set; }

        public string Text { get; set; } = null!;

        public Category Category { get; set; }

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

        public string? Explanation { get; set; }

        public byte[]? Media { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
