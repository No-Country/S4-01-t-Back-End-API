using Microsoft.EntityFrameworkCore.Metadata.Internal;
using S4_Back_End_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace S4_Back_End_API.DTOs
{
    public class AppUserDTO
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        // ¿¿¿  E x p o n e r  ???  //
        public string Password { get; set; } = string.Empty;
        public string? UserPicturePath { get; set; } = string.Empty;

        // Navigation Props

        // needs to be DTO
        public List<Recipe>? Recipes { get; set; } = new List<Recipe>();

        // needs to be DTO
        public List<Recipe_User_Like>? Recipe_User_Likes { get; set; } = new List<Recipe_User_Like>();

        // needs to be DTO
        public List<Recipe_User_Match>? Recipe_User_Matches { get; set; } = new List<Recipe_User_Match>();

        //*******************//
        //     TOKEN ???     //
        //*******************//
    }
}
