using FormulaOneApp.Services.Data.Interfaces;
using FormulaOneApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> PickQuestion()
        {
            QuestionViewModel pickedQuestion = await _questionService.PickQuestionAsync();

            return View(pickedQuestion);
        }
    }
}
