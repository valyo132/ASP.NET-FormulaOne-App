using Microsoft.AspNetCore.Http;

using FormulaOneApp.Data.Models;
using FormulaOneApp.Services.Data.Interfaces;
using FormulaOneApp.Web.Data;
using FormulaOneApp.Web.ViewModels;

using AutoMapper;

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
    }
}
