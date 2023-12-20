namespace FormulaOneApp.Web.ViewModels
{
    public class AnswerdDailyQuestionViewModel
    {
        public QuestionViewModel DailyQuestion { get; set; }
        public string UserAnswer { get; set; } = null!;
        public bool IsCorrect { get; set; }
    }
}
