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

        [Required]
        [MaxLength(300)]
        public string FullName { get; set; } = string.Empty;

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

        // Navigation Props
        public List<Recipe>? Recipes { get; set; }
        public List<Recipe_User_Like>? Recipe_User_Likes { get; set; }
        public List<Recipe_User_Match>? Recipe_User_Matches { get; set; }

        [Required]
        [DefaultValue(1)]
        public int UserRoleId { get; set; }
        public AppUserRole AppUserRole { get; set; }

        //*******************//
        //     TOKEN ???     //
        //*******************//
    }
}
