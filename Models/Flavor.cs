using System.ComponentModel.DataAnnotations;

namespace S4_Back_End_API.Models
{
    public class Flavor
    {
        [Key]
        public int FlavorId { get; set; }

        [MaxLength(50)]
        public string FlavorDescription { get; set; } = string.Empty;
    }
}
