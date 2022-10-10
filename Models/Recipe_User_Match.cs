using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using S4_Back_End_API.Models;

namespace S4_Back_End_API.Models
{
    public class Recipe_User_Match
    {
        [Key]
        public int MatchId { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
