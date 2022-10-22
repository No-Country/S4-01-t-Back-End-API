using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime? LastEditDate { get; set; }

        [MaxLength(300)]
        public string? RecipePicturePath { get; set; }

        [DefaultValue(0)]
        public int? TotalLikes { get; set; }

        // Navigation Props
        [Required]
        public List<Recipe_DietType> Recipe_DietTypes { get; set; } = new List<Recipe_DietType>();

        [Required]
        public List<Recipe_TimeOfDay> Recipe_TimesOfDay { get; set; } = new List<Recipe_TimeOfDay>();

        public List<Recipe_User_Like> Recipe_User_Likes { get; set; } = new List<Recipe_User_Like>();
        
        public List<Recipe_User_Match> Recipe_User_Matches { get; set; } = new List<Recipe_User_Match>();

        [Required, MaxLength(400)]
        public List<RecipeStep> RecipeSteps { get; set; } = new List<RecipeStep>();

        // # # #   CHECK!   # # # //
        [Required]
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        // - - - - - - - - - - - //

        [Required]
        [ForeignKey(nameof(DifficultyLevel))]
        public int DifficultyLevelId { get; set; }

        [Required]
        [ForeignKey(nameof(Flavor))]
        public int FlavorId { get; set; }

        // Usuario que creó la receta
        [Required]
        [ForeignKey(nameof(AppUser))]
        public int AppUserIds { get; set; }
    }
}
