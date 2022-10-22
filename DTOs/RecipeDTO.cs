using S4_Back_End_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace S4_Back_End_API.DTOs
{
    public class RecipeDTO
    {
        public int RecipeId { get; set; }
        public string? RecipePicturePath { get; set; }
        public int PreparationTime { get; set; }
        public string RecipeTitle { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int? TotalLikes { get; set; }
        //public List<string> Diet_Type { get; set; } = new List<string>();
        public List<int> DietTypeId { get; set; } = new List<int>();
        public List<DietType> DietTypes { get; set; } = new List<DietType>();

        public int AppUserId { get; set; }


        // PARA RECIPE DETAILS
        // # # #   CHECK DATA TYPE!   # # # //
        // needs to be DTO
        //public List<TimeOfDay> TimesOfDay { get; set; } = new List<TimeOfDay>();
        // - - - - - - - - - - - //
        //public string UserName { get; set; } = string.Empty;
        //public string UserPicturePath { get; set; } = string.Empty;
    }
}
