using FormulaOneApp.Data.Models.Enums;

namespace FormulaOneApp.Web.ViewModels
{
    public class QuestionViewModel
    {
        public string Id { get; set; }
        public string Text { get; set; } = null!;
        public Category Category { get; set; }
        public Difficulty Difficulty { get; set; }
        public string CorrectAnswer { get; set; } = null!;
        public string[] AllAnswers { get; set; } = null!;
        public string? Explanation { get; set; }
        public byte[]? Media { get; set; }
    }
}
