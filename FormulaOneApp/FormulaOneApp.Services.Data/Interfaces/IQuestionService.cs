using FormulaOneApp.Web.ViewModels;
using Microsoft.AspNetCore.Http;

namespace FormulaOneApp.Services.Data.Interfaces
{
    public interface IQuestionService
    {
        Task CraeteQuestionAsync(IFormFile? file, CreateQuestionViewModel model);
        Task<AllQuestionsViewModel> AllAsync();
        Task<QuestionViewModel> PickQuestionAsync(string item);
        Task<QuestionViewModel> PickDailyQuestionAsync();
        Task<bool> IsCorrect(string answer, string userId, string questionId);
        Task<bool> IsAnswerd(string questionId, string userId);
    }
}
