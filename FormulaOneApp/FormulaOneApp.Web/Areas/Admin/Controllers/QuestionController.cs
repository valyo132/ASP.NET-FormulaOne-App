using Microsoft.AspNetCore.Mvc;

using FormulaOneApp.Services.Data.Helpers;
using FormulaOneApp.Web.ViewModels;

namespace FormulaOneApp.Web.Areas.Admin.Controllers
{
    public class QuestionController : BaseAdminControoler
    {
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
        public IActionResult CreateQuestion(IFormFile? file, CreateQuestionViewModel model)
        {
            return View();
        }
    }
}
