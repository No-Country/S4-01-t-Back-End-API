using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using S4_Back_End_API.Models;
using System.Security.Policy;


namespace S4_Back_End_API.Data
{
    public class ApplicationDbContext : DbContext //IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Diet Types
            modelBuilder.Entity<Recipe_DietType>()
                        .HasOne(r => r.Recipe)
                        .WithMany(rdt => rdt.Recipe_DietTypes)
                        .HasForeignKey(r => r.RecipeId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Recipe_DietType>()
                        .HasOne(dt => dt.DietType)
                        .WithMany(rdt => rdt.Recipe_DietTypes)
                        .HasForeignKey(dt => dt.DietTypeId)
                        .OnDelete(DeleteBehavior.Cascade);

            // Likes
            // # CHECK Delete Behaviors # //
            modelBuilder.Entity<Recipe_User_Like>()
                        .HasOne(r => r.Recipe)
                        .WithMany(rul => rul.Recipe_User_Likes)
                        .HasForeignKey(r => r.RecipeId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Recipe_User_Like>()
                        .HasOne(u => u.AppUser)
                        .WithMany(rul => rul.Recipe_User_Likes)
                        .HasForeignKey(u => u.AppUserId)
                        .OnDelete(DeleteBehavior.Cascade);

            // Matches   
            // # CHECK Delete Behaviors # //
            modelBuilder.Entity<Recipe_User_Match>()
                        .HasOne(r => r.Recipe)
                        .WithMany(rum => rum.Recipe_User_Matches)
                        .HasForeignKey(r => r.RecipeId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Recipe_User_Match>()
                        .HasOne(u => u.AppUser)
                        .WithMany(rum => rum.Recipe_User_Matches)
                        .HasForeignKey(u => u.AppUserId)
                        .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<AppUser>? AppUsers { get; set; }
        public DbSet<AppUserRole>? AppUserRoles { get; set; }

        //public DbSet<AppUserRegister>? AppUsersRegisters { get; set; }
        public DbSet<DietType>? DietTypes { get; set; }
        public DbSet<DifficultyLevel>? DifficultyLevels { get; set; }
        public DbSet<Flavor>? Flavors { get; set; }
        public DbSet<Ingredient>? Ingredients { get; set; }
        public DbSet<Recipe>? Recipes { get; set; }
        public DbSet<Recipe_DietType>? Recipe_DietTypes { get; set; }
        public DbSet<Recipe_User_Like>? Recipe_User_Likes { get; set; }
        public DbSet<Recipe_User_Match>? Recipe_User_Matches { get; set; }
        public DbSet<TimeOfDay>? TimeOfDays { get; set; }
    }
}
