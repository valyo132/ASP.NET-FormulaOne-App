using FormulaOneApp.Data.Models;

namespace FormulaOneApp.Services.Data.Interfaces
{
    public interface IUserQuestionService
    {
        Task<UserQuestion> Create(string questionId, string userId);
    }
}
