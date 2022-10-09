using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S4_Back_End_API.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }

        [MaxLength(50)]
        public string IngredientDescription { get; set; } = string.Empty;

        [MaxLength(50)]
        public string IngredientAmount { get; set; } = string.Empty;

        // Navigation Props
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
