using Microsoft.AspNetCore.Identity;

namespace FormulaOneApp.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public ICollection<UserQuestion> UserQuestions { get; set; } = new List<UserQuestion>();
    }
}
