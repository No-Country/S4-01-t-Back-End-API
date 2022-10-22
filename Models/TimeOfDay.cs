using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S4_Back_End_API.Models
{
    public class TimeOfDay
    {
        [Key]
        public int TimeOfDayId { get; set; }

        [MaxLength(50)]
        public string TimeOfDayDescription { get; set; } = string.Empty;

        // Navigation props
        [Required]
        public List<Recipe_TimeOfDay>? Recipe_TimesOfDay { get; set; } = new List<Recipe_TimeOfDay>();
    }
}
