using System.ComponentModel.DataAnnotations.Schema;

namespace FormulaOneApp.Data.Models
{
    public class UserQuestion
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(Question))]
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
