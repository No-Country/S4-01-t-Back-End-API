using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S4_Back_End_API.Models
{
    public class RecipeStep
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DefaultValue(1)]
        public int StepNumber { get; set; }
        [Required]
        [MaxLength(400)]
        public string StepDescription { get; set; } = string.Empty;

        // Navigation props
        public int RecipeId { get; set; }

        // # # #   CHECK!   # # # //
        public Recipe Recipe { get; set; } = new Recipe();
        // - - - - - - - - - - - //
    }
}
