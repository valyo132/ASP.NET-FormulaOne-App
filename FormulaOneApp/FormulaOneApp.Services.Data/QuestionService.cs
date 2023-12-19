using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using FormulaOneApp.Services.Data.Helpers;
using FormulaOneApp.Data.Models;
using FormulaOneApp.Data.Models.Enums;
using FormulaOneApp.Services.Data.Interfaces;
using FormulaOneApp.Web.Data;
using FormulaOneApp.Web.ViewModels;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using FormulaOneApp.Web.Data.Migrations;

namespace FormulaOneApp.Services.Data
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserQuestionService _userQuestionService;
        private readonly IMapper _mapper;

        public QuestionService(ApplicationDbContext context, IMapper mapper, IUserQuestionService userQuestionService)
        {
            _context = context;
            _mapper = mapper;
            _userQuestionService = userQuestionService;
        }

        public async Task<AllQuestionsViewModel> AllAsync()
        {
            List<QuestionViewModel> allQuestions = await _context.Questions
                .Where(x => x.IsDeleted == false)
                .ProjectTo<QuestionViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new AllQuestionsViewModel()
            {
                AllQuestions = allQuestions,
                Categories = QuestionHelper.GetCategories()
            };
        }

        public async Task CraeteQuestionAsync(IFormFile? file, CreateQuestionViewModel model)
        {
            Question question = _mapper.Map<Question>(model);

            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    question.Media = memoryStream.ToArray();
                }
            }

            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task<QuestionViewModel> PickDailyQuestionAsync()
        {
            DateTime dateToday = DateTime.UtcNow;

            bool isAvalable = _context.Questions
                .Any(x => x.UploadDate.Value.Date == dateToday.Date);

            if (isAvalable)
            {
                var question = await _context.Questions
                    .FirstOrDefaultAsync(x => x.UploadDate.Value.Date == dateToday.Date);

                return _mapper.Map<QuestionViewModel>(question);
            }
            else
            {
                int size = _context.Questions
                .Where(x => x.IsDeleted == false)
                .Count();

                Random random = new Random();
                int randomNumber = random.Next(1, size + 1);

                Question pickedQuestion = await _context.Questions
                    .Where(x => x.IsDeleted == false)
                    .Skip(randomNumber - 1)
                    .FirstOrDefaultAsync();

                pickedQuestion.UploadDate = dateToday;
                await _context.SaveChangesAsync();

                return _mapper.Map<QuestionViewModel>(pickedQuestion);
            }
        }

        public async Task<bool> IsAnswerd(string questionId, string userId)
        {
            Question questionObj = await _context.Questions.FirstAsync(x => x.Id.ToString() == questionId);
            ApplicationUser user = await _context.ApplicationUsers
                .Include(u => u.UserQuestions)
                .FirstAsync(x => x.Id == userId);

            if (user.UserQuestions.FirstOrDefault(x => x.QuestionId == questionObj.Id) == null)
                return false;
            else
                return true;
        }

        public async Task<bool> IsCorrect(string answer, string userId, string questionId)
        {
            Question questionObj = await _context.Questions.FirstAsync(x => x.Id.ToString() == questionId);

            await _userQuestionService.Create(questionObj.Id.ToString(), userId);

            if (questionObj.CorrectAnswer == answer)
                return true;
            else
                return false;
        }

        public async Task<QuestionViewModel> PickQuestionAsync(string category)
        {
            int size = _context.Questions
                .Where(x => x.Category == Enum.Parse<Category>(category) && x.IsDeleted == false)
                .Count();

            Random random = new Random();
            int randomNumber = random.Next(1, size + 1);

            Question pickedQuestion = await _context.Questions
                .Where(x => x.Category == Enum.Parse<Category>(category) && x.IsDeleted == false)
                .Skip(randomNumber - 1)
                .FirstOrDefaultAsync();

            return _mapper.Map<QuestionViewModel>(pickedQuestion);
        }
    }
}
