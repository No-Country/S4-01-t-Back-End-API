using System.ComponentModel.DataAnnotations;

namespace S4_Back_End_API
{
    public class UserRegisterDTO
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(6, ErrorMessage = "Ingrese al menos 6 Caracteres")]
        public string Password { get; set; } = string.Empty;

        [Required, Compare("Password")]
        [MaxLength(50)]
        public string ConfirmPasword { get; set; } = string.Empty;
    }
}
