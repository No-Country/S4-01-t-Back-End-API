using System.ComponentModel.DataAnnotations;

namespace S4_Back_End_API.Models
{
    public class AppUserRegister //: AppUser
    {
        //[Required]
        //public string Name { get; set; } = string.Empty;

        //[Required]
        //public string Password { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string ConfirmPasword { get; set; } = string.Empty;
    }
}
