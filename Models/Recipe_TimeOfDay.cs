using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S4_Back_End_API.Models
{
    public class Recipe_TimeOfDay
    {

        [Key]
        public int RecipeTimeOfDayId { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; } = new Recipe();
        public int TimeOfDayId { get; set; }
        public TimeOfDay TimeOfDay { get; set; } = new TimeOfDay();
    }
}
