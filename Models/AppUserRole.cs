using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S4_Back_End_API.Models
{
    public class AppUserRole
    {
        [Key]
        public int UserRoleId { get; set; }

        [MaxLength(30)]
        public string UserRoleDescription { get; set; } = string.Empty;
    }
}
