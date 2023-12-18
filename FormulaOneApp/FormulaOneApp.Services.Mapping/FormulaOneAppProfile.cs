using FormulaOneApp.Data.Models;
using FormulaOneApp.Services.Data.Helpers;
using FormulaOneApp.Web.ViewModels;

using AutoMapper;

namespace FormulaOneApp.Services.Mapping
{
    public class FormulaOneAppProfile : Profile
    {
        public FormulaOneAppProfile()
        {
            CreateMap<CreateQuestionViewModel, Question>();

            // Maps AllAnswers like taking all possible options and uses QuestionHelper to shuffle the answers.
            CreateMap<Question, QuestionViewModel>()
                .ForMember(x => x.AllAnswers, y => y.MapFrom(q => QuestionHelper.Shuffle(new List<string>() { q.CorrectAnswer, q.WrongAnswerOne, q.WrongAnswerTwo, q.WrongAnswerThree })));
        }
    }
}
