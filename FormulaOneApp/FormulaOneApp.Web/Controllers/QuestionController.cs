using Microsoft.AspNetCore.Mvc;

using FormulaOneApp.Services.Data.Interfaces;
using FormulaOneApp.Web.ViewModels;
using FormulaOneApp.Services.Data.Helpers;
using Microsoft.AspNetCore.Authorization;
using FormulaOneApp.Data.Models;

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
        public async Task<IActionResult> DailyQuestion(string? answer)
        {
            QuestionViewModel dailyQuestion = await _questionService.PickDailyQuestionAsync();

            string userId = GetUserId();
            if (!await _questionService.IsAnswerd(dailyQuestion.Id, userId))
            {
                try
                {
                    if (answer == null)
                    {
                        return View(dailyQuestion);
                    }
                    else
                    {
                        bool isCorrect = await _questionService.IsCorrect(answer, userId, dailyQuestion.Id);
                        return View("AnswerdQuestion");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

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
