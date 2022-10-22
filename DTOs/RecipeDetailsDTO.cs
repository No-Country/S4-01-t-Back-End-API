using S4_Back_End_API.Models;

namespace S4_Back_End_API.DTOs
{
    public class RecipeDetailsDTO : RecipeDTO
    {
        public List<DifficultyLevel> DifficultyLevels { get; set; } = new List<DifficultyLevel>();
        public List<TimeOfDay> TimesOfDay { get; set; } = new List<TimeOfDay>();
        public List<Flavor> Flavors { get; set;} = new List<Flavor>();
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<RecipeStep> RecipeSteps { get; set; } = new List<RecipeStep>();
        public string UserName { get; set; } = string.Empty;
        public string UserPicturePath { get; set; } = string.Empty;
    }
}
