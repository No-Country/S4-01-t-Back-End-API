using Microsoft.EntityFrameworkCore;
using S4_Back_End_API.Models;


namespace S4_Back_End_API.Data
{
    public class ApplicationDbContext : DbContext //IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Times of Day   
            modelBuilder.Entity<Recipe_TimeOfDay>()
                .HasOne(r => r.Recipe)
                .WithMany(rtd => rtd.Recipe_TimesOfDay)
                .HasForeignKey(r => r.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Recipe_TimeOfDay>()
                .HasOne(td => td.TimeOfDay)
                .WithMany(rtd => rtd.Recipe_TimesOfDay)
                .HasForeignKey(r => r.TimeOfDayId)
                .OnDelete(DeleteBehavior.Cascade);

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
            modelBuilder.Entity<Recipe_User_Like>()
                        .HasOne(r => r.Recipe)
                        .WithMany(rul => rul.Recipe_User_Likes)
                        .HasForeignKey(r => r.RecipeId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Recipe_User_Like>()
                        .HasOne(u => u.AppUser)
                        .WithMany(rul => rul.Recipe_User_Likes)
                        .HasForeignKey(u => u.AppUserId)
                        .OnDelete(DeleteBehavior.Cascade);

            // Matches   
            modelBuilder.Entity<Recipe_User_Match>()
                        .HasOne(r => r.Recipe)
                        .WithMany(rum => rum.Recipe_User_Matches)
                        .HasForeignKey(r => r.RecipeId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Recipe_User_Match>()
                        .HasOne(u => u.AppUser)
                        .WithMany(rum => rum.Recipe_User_Matches)
                        .HasForeignKey(u => u.AppUserId)
                        .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<AppUser> AppUsers { get; set; } = null!;

        //public DbSet<AppUserRegister>? AppUsersRegisters { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; } = null!;
        public DbSet<DietType> DietTypes { get; set; } = null!;
        public DbSet<DifficultyLevel> DifficultyLevels { get; set; } = null!;
        public DbSet<Flavor> Flavors { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<Recipe> Recipe_DietType { get; set; } = null!;
        public DbSet<RecipeStep> RecipeSteps { get; set; } = null!;
        public DbSet<TimeOfDay> TimesOfDay { get; set; } = null!;
        public DbSet<Recipe_DietType> Recipe_DietTypes { get; set; } = null!;
        public DbSet<Recipe_User_Like> Recipe_User_Likes { get; set; } = null!;
        public DbSet<Recipe_User_Match> Recipe_User_Matches { get; set; } = null!;
        public DbSet<Recipe_TimeOfDay> Recipe_TimesOfDay { get; set; } = null!;
    }
}
