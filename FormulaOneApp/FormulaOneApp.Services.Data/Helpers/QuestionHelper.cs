using Microsoft.AspNetCore.Mvc.Rendering;

using FormulaOneApp.Data.Models.Enums;

namespace FormulaOneApp.Services.Data.Helpers
{
    public static class QuestionHelper
    {
        public static string[] Shuffle(List<string> list)
        {
            Random rng = new Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list.ToArray();
        }

        public static IEnumerable<SelectListItem> GetCategories()
            => Enum.GetValues(typeof(Category))
                .Cast<Category>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString()
                })
                .ToList();

        public static IEnumerable<SelectListItem> GetDifficulties()
            => Enum.GetValues(typeof(Difficulty))
                .Cast<Difficulty>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString()
                })
                .ToList();
    }
}
