using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using FormulaOneApp.Services.Data.Helpers;
using FormulaOneApp.Data.Models;
using FormulaOneApp.Services.Data.Interfaces;
using FormulaOneApp.Web.Data;
using FormulaOneApp.Web.ViewModels;

using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace FormulaOneApp.Services.Data
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public QuestionService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task<QuestionViewModel> PickQuestionAsync()
        {
            int size = _context.Questions.Count();

            Random random = new Random();
            int randomNumber = random.Next(1, size);

            Question pickedQuestion = await _context.Questions
                .Skip(randomNumber)
                .FirstOrDefaultAsync();

            return _mapper.Map<QuestionViewModel>(pickedQuestion);
        }
    }
}
