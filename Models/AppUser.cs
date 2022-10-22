using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S4_Back_End_API.Models
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }

        /*[Required]
        [MaxLength(300)]
        public string FullName { get; set; } = string.Empty;*/

        [Required]
        [MaxLength(200)]
        [Column(TypeName = "varchar(200)")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;

        [MaxLength(400)]
        public string? UserPicturePath { get; set; } = string.Empty;

        // # # #   CHECK   # # # //
        [Required]
        public DateTime SignUpDate { get; set; } = DateTime.Now;

        public byte[]? PasswordHash { get; set; } = new byte[32];
        public byte[]? PasswordSalt { get; set; } = new byte[32];

        public string? VerificationToken { get; set; } = string.Empty;      //Verificacion del Token
        public DateTime? VerifiedAt { get; set; } = DateTime.Now;           //Duracion del Token Verificado
        public string? PasswordResetToken { get; set; } = string.Empty;     //Recuperar contraseña
        public DateTime? ResetTokenExpires { get; set; } = DateTime.Now.AddDays(30);    //Reseteo de la verificacion del Token

        // Navigation Props
        public List<Recipe>? Recipes { get; set; } = new();
        public List<Recipe_User_Like>? Recipe_User_Likes { get; set; } = new();
        public List<Recipe_User_Match>? Recipe_User_Matches { get; set; } = new();

        [Required]
        //[DefaultValue(1)]
        [ForeignKey(nameof(AppUserRole))]
        public int UserRoleId { get; set; } = 1;
        //public AppUserRole AppUserRole { get; set; } = new ();

        //*******************//
        //     TOKEN ???     //
        //*******************//


    }
}
