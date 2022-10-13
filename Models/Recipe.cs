using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S4_Back_End_API.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        [Required]
        public int PreparationTime { get; set; }

        [Required]
        [MaxLength(100)]
        public string RecipeTitle { get; set; } = string.Empty;

        [Required]
        [MaxLength(4000)]
        public string RecipeSteps { get; set; } = string.Empty;

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime? LastEditDate { get; set; }

        [MaxLength(300)]
        public string? RecipePicturePath { get; set; }

        [DefaultValue(0)]
        public int? TotalLikes { get; set; }

        // Navigation Props
        public List<Recipe_DietType>? Recipe_DietTypes { get; set; }
        public List<Recipe_User_Like>? Recipe_User_Likes { get; set; }
        public List<Recipe_User_Match>? Recipe_User_Matches { get; set; }

        // # # #   CHECK!   # # # //
        public List<Ingredient> Ingredients { get; set; }
        // - - - - - - - - - - - //

        public int DifficultyLevelId { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }

        public int TimeOfDayId { get; set; }
        public TimeOfDay TimeOfDay { get; set; }

        public int FlavorId { get; set; }
        public Flavor Flavor { get; set; }

        // Usuario que creó la receta
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
