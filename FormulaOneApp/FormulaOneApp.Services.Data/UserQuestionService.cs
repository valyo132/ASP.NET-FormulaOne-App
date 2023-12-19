using AutoMapper;
using FormulaOneApp.Data.Models;
using FormulaOneApp.Services.Data.Interfaces;
using FormulaOneApp.Web.Data;

namespace FormulaOneApp.Services.Data
{
    public class UserQuestionService : IUserQuestionService
    {
        private readonly ApplicationDbContext _context;

        public UserQuestionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserQuestion> Create(string questionId, string userId)
        {
            UserQuestion newUserQuestion = new UserQuestion()
            {
                UserId = userId,
                QuestionId = Guid.Parse(questionId)
            };

            await _context.UsersQuestions.AddAsync(newUserQuestion);
            await _context.SaveChangesAsync();

            return newUserQuestion;
        }
    }
}
