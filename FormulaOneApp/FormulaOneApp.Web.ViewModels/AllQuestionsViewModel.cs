using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormulaOneApp.Web.ViewModels
{
    public class AllQuestionsViewModel
    {
        public List<QuestionViewModel> AllQuestions { get; set; }

        public IEnumerable<SelectListItem>? Categories { get; set; }
    }
}
