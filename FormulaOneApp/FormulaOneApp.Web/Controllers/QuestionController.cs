using Microsoft.AspNetCore.Mvc;

using FormulaOneApp.Services.Data.Interfaces;
using FormulaOneApp.Web.ViewModels;

namespace FormulaOneApp.Web.Controllers
{
    public class QuestionController : BaseController
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            this._questionService = questionService;
        }

        [HttpGet]
        public async Task<IActionResult> AllCategories()
        {
            var allQuestions = await _questionService.AllAsync();

            return View(allQuestions);
        }

        [HttpGet]
        public async Task<IActionResult> PickQuestion(string category)
        {
            QuestionViewModel pickedQuestion = await _questionService.PickQuestionAsync(category);

            return View(pickedQuestion);
        }
    }
}
