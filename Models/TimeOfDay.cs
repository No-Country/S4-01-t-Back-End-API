using System.ComponentModel.DataAnnotations;

namespace S4_Back_End_API.Models
{
    public class TimeOfDay
    {
        [Key]
        public int TimeOfDayId { get; set; }

        [MaxLength(50)]
        public string TimeOfDayDescription { get; set; } = string.Empty;
    }
}
