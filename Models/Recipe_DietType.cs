using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S4_Back_End_API.Models
{
    public class Recipe_DietType
    {
        [Key]
        public int RecipeDietTypeId { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int DietTypeId { get; set; }
        public DietType DietType { get; set; }
    }
}
