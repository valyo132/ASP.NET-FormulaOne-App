using FormulaOneApp.Web.ViewModels;
using Microsoft.AspNetCore.Http;

namespace FormulaOneApp.Services.Data.Interfaces
{
    public interface IQuestionService
    {
        Task CraeteQuestionAsync(IFormFile? file, CreateQuestionViewModel model);

        Task<AllQuestionsViewModel> AllAsync();

        Task<QuestionViewModel> PickQuestionAsync();
    }
}
