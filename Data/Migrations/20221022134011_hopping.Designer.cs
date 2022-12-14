// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using S4_Back_End_API.Data;

#nullable disable

namespace S4_Back_End_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221022134011_hopping")]
    partial class hopping
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("S4_Back_End_API.Models.AppUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SignUpDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserPicturePath")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("VerifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.AppUserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserRoleId"), 1L, 1);

                    b.Property<string>("UserRoleDescription")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("UserRoleId");

                    b.ToTable("AppUserRoles");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.DietType", b =>
                {
                    b.Property<int>("DietTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DietTypeId"), 1L, 1);

                    b.Property<string>("DietTypeDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DietTypeId");

                    b.ToTable("DietTypes");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.DifficultyLevel", b =>
                {
                    b.Property<int>("DifficultyLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DifficultyLevelId"), 1L, 1);

                    b.Property<string>("DifficultyLevelDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DifficultyLevelId");

                    b.ToTable("DifficultyLevels");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.Flavor", b =>
                {
                    b.Property<int>("FlavorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlavorId"), 1L, 1);

                    b.Property<string>("FlavorDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FlavorId");

                    b.ToTable("Flavors");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientId"), 1L, 1);

                    b.Property<string>("IngredientAmount")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IngredientDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeId"), 1L, 1);

                    b.Property<int>("AppUserIds")
                        .HasColumnType("int");

                    b.Property<int?>("AppUserUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DifficultyLevelId")
                        .HasColumnType("int");

                    b.Property<int>("FlavorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastEditDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PreparationTime")
                        .HasColumnType("int");

                    b.Property<string>("RecipePicturePath")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("RecipeTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("TotalLikes")
                        .HasColumnType("int");

                    b.HasKey("RecipeId");

                    b.HasIndex("AppUserUserId");

                    b.ToTable("Recipe_DietType");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.Recipe_DietType", b =>
                {
                    b.Property<int>("RecipeDietTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeDietTypeId"), 1L, 1);

                    b.Property<int>("DietTypeId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("RecipeDietTypeId");

                    b.HasIndex("DietTypeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Recipe_DietTypes");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.Recipe_TimeOfDay", b =>
                {
                    b.Property<int>("RecipeTimeOfDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeTimeOfDayId"), 1L, 1);

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("TimeOfDayId")
                        .HasColumnType("int");

                    b.HasKey("RecipeTimeOfDayId");

                    b.HasIndex("RecipeId");

                    b.HasIndex("TimeOfDayId");

                    b.ToTable("Recipe_TimesOfDay");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.Recipe_User_Like", b =>
                {
                    b.Property<int>("LikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LikeId"), 1L, 1);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("LikeId");

                    b.HasIndex("AppUserId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Recipe_User_Likes");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.Recipe_User_Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatchId"), 1L, 1);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("AppUserId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Recipe_User_Matches");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.RecipeStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<string>("StepDescription")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int>("StepNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeSteps");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.TimeOfDay", b =>
                {
                    b.Property<int>("TimeOfDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeOfDayId"), 1L, 1);

                    b.Property<string>("TimeOfDayDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TimeOfDayId");

                    b.ToTable("TimesOfDay");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.Ingredient", b =>
                {
                    b.HasOne("S4_Back_End_API.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.Recipe", b =>
                {
                    b.HasOne("S4_Back_End_API.Models.AppUser", null)
                        .WithMany("Recipes")
                        .HasForeignKey("AppUserUserId");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.Recipe_DietType", b =>
                {
                    b.HasOne("S4_Back_End_API.Models.DietType", "DietType")
                        .WithMany("Recipe_DietTypes")
                        .HasForeignKey("DietTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("S4_Back_End_API.Models.Recipe", "Recipe")
                        .WithMany("Recipe_DietTypes")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DietType");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.Recipe_TimeOfDay", b =>
                {
                    b.HasOne("S4_Back_End_API.Models.Recipe", "Recipe")
                        .WithMany("Recipe_TimesOfDay")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("S4_Back_End_API.Models.TimeOfDay", "TimeOfDay")
                        .WithMany("Recipe_TimesOfDay")
                        .HasForeignKey("TimeOfDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("TimeOfDay");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.Recipe_User_Like", b =>
                {
                    b.HasOne("S4_Back_End_API.Models.AppUser", "AppUser")
                        .WithMany("Recipe_User_Likes")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("S4_Back_End_API.Models.Recipe", "Recipe")
                        .WithMany("Recipe_User_Likes")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.Recipe_User_Match", b =>
                {
                    b.HasOne("S4_Back_End_API.Models.AppUser", "AppUser")
                        .WithMany("Recipe_User_Matches")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("S4_Back_End_API.Models.Recipe", "Recipe")
                        .WithMany("Recipe_User_Matches")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.RecipeStep", b =>
                {
                    b.HasOne("S4_Back_End_API.Models.Recipe", "Recipe")
                        .WithMany("RecipeSteps")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.AppUser", b =>
                {
                    b.Navigation("Recipe_User_Likes");

                    b.Navigation("Recipe_User_Matches");

                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.DietType", b =>
                {
                    b.Navigation("Recipe_DietTypes");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("RecipeSteps");

                    b.Navigation("Recipe_DietTypes");

                    b.Navigation("Recipe_TimesOfDay");

                    b.Navigation("Recipe_User_Likes");

                    b.Navigation("Recipe_User_Matches");
                });

            modelBuilder.Entity("S4_Back_End_API.Models.TimeOfDay", b =>
                {
                    b.Navigation("Recipe_TimesOfDay");
                });
#pragma warning restore 612, 618
        }
    }
}
