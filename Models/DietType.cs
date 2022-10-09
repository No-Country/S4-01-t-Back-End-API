using System.ComponentModel.DataAnnotations;

namespace S4_Back_End_API.Models
{
    public class DietType
    {
        [Key]
        public int DietTypeId { get; set; }

        [MaxLength(50)]
        public string DietTypeDescription { get; set; } = string.Empty;

        // Navigation Props
        public List<Recipe_DietType>? Recipe_DietTypes { get; set; } = new();
    }
}
