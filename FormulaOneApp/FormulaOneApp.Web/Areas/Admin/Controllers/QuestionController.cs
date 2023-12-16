using Microsoft.AspNetCore.Mvc;

using FormulaOneApp.Services.Data.Helpers;
using FormulaOneApp.Web.ViewModels;
using FormulaOneApp.Services.Data.Interfaces;

namespace FormulaOneApp.Web.Areas.Admin.Controllers
{
    public class QuestionController : BaseAdminControoler
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public IActionResult CreateQuestion()
        {
            CreateQuestionViewModel model = new CreateQuestionViewModel()
            {
                Categories = QuestionHelper.GetCategories(),
                Difficulties = QuestionHelper.GetDifficulties()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(IFormFile? file, CreateQuestionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _questionService.CraeteQuestionAsync(file, model);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
