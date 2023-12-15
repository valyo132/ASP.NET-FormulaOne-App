using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

using FormulaOneApp.Data.Models;
using FormulaOneApp.Data.Models.Enums;

namespace FormulaOneApp.Web.ViewModels
{
    public class CreateQuestionViewModel
    {
        [Required]
        [MinLength(1)]
        public string Text { get; set; } = null!;

        public Category Category { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> Categories { get; set; }

        public Difficulty Difficulty { get; set; }

        [Required]
        public IEnumerable<SelectListItem> Difficulties { get; set; }

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

        [MinLength(1)]
        public string? Explanation { get; set; }
    }
}
