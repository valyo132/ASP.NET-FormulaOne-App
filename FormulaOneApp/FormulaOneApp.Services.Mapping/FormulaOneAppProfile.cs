using AutoMapper;
using FormulaOneApp.Data.Models;
using FormulaOneApp.Web.ViewModels;

namespace FormulaOneApp.Services.Mapping
{
    public class FormulaOneAppProfile : Profile
    {
        public FormulaOneAppProfile()
        {
            CreateMap<CreateQuestionViewModel, Question>();

            CreateMap<Question, QuestionViewModel>();
        }
    }
}
