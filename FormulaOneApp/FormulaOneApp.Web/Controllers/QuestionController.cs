using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> DailyQuestion()
        {
            QuestionViewModel dailyQuestion = await _questionService.PickDailyQuestionAsync();

            string userId = GetUserId();
            if (!await _questionService.IsAnswerd(dailyQuestion.Id, userId))
            {
                try
                {
                    return View(dailyQuestion);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return View("AnswerdQuestion");
        }

        public async Task<IActionResult> Answer(string answer, string questionId)
        {
            string userId = GetUserId();
            bool isCorrect = await _questionService.IsCorrect(answer, userId, questionId);

            return View("AnswerdQuestion");
        }

        [HttpGet]
        public async Task<IActionResult> PickQuestion(string category)
        {
            QuestionViewModel pickedQuestion = await _questionService.PickQuestionAsync(category);

            return View(pickedQuestion);
        }
    }
}
