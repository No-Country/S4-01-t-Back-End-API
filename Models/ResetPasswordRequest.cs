using System.ComponentModel.DataAnnotations;

namespace S4_Back_End_API.Models
{
    public class ResetPasswordRequest
    {
        [Required]
        public string Token { get; set; } = string.Empty;

        [Required, MinLength(6, ErrorMessage = "Ingrese al menos 6 Caracteres")]
        public string Password { get; set; } = string.Empty;

        [Required, Compare("Password")]
        [MaxLength(50)]
        public string ConfirmPasword { get; set; } = string.Empty;
    }
}
