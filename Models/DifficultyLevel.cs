using System.ComponentModel.DataAnnotations;

namespace S4_Back_End_API.Models
{
    public class DifficultyLevel
    {
        [Key]
        public int DifficultyLevelId { get; set; }

        [MaxLength(50)]
        public string DifficultyLevelDescription { get; set; } = string.Empty;
    }
}
