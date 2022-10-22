using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S4_Back_End_API.Migrations
{
    public partial class hopping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_DietTypes_Recipes_RecipeId",
                table: "Recipe_DietTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_TimesOfDay_Recipes_RecipeId",
                table: "Recipe_TimesOfDay");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_User_Likes_Recipes_RecipeId",
                table: "Recipe_User_Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_User_Matches_Recipes_RecipeId",
                table: "Recipe_User_Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_AppUsers_AppUserId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeSteps_Recipes_RecipeId",
                table: "RecipeSteps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_AppUserId",
                table: "Recipes");

            migrationBuilder.RenameTable(
                name: "Recipes",
                newName: "Recipe_DietType");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Recipe_DietType",
                newName: "AppUserIds");

            migrationBuilder.AddColumn<int>(
                name: "AppUserUserId",
                table: "Recipe_DietType",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe_DietType",
                table: "Recipe_DietType",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_DietType_AppUserUserId",
                table: "Recipe_DietType",
                column: "AppUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipe_DietType_RecipeId",
                table: "Ingredients",
                column: "RecipeId",
                principalTable: "Recipe_DietType",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_DietType_AppUsers_AppUserUserId",
                table: "Recipe_DietType",
                column: "AppUserUserId",
                principalTable: "AppUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_DietTypes_Recipe_DietType_RecipeId",
                table: "Recipe_DietTypes",
                column: "RecipeId",
                principalTable: "Recipe_DietType",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_TimesOfDay_Recipe_DietType_RecipeId",
                table: "Recipe_TimesOfDay",
                column: "RecipeId",
                principalTable: "Recipe_DietType",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_User_Likes_Recipe_DietType_RecipeId",
                table: "Recipe_User_Likes",
                column: "RecipeId",
                principalTable: "Recipe_DietType",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_User_Matches_Recipe_DietType_RecipeId",
                table: "Recipe_User_Matches",
                column: "RecipeId",
                principalTable: "Recipe_DietType",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeSteps_Recipe_DietType_RecipeId",
                table: "RecipeSteps",
                column: "RecipeId",
                principalTable: "Recipe_DietType",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipe_DietType_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_DietType_AppUsers_AppUserUserId",
                table: "Recipe_DietType");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_DietTypes_Recipe_DietType_RecipeId",
                table: "Recipe_DietTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_TimesOfDay_Recipe_DietType_RecipeId",
                table: "Recipe_TimesOfDay");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_User_Likes_Recipe_DietType_RecipeId",
                table: "Recipe_User_Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_User_Matches_Recipe_DietType_RecipeId",
                table: "Recipe_User_Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeSteps_Recipe_DietType_RecipeId",
                table: "RecipeSteps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe_DietType",
                table: "Recipe_DietType");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_DietType_AppUserUserId",
                table: "Recipe_DietType");

            migrationBuilder.DropColumn(
                name: "AppUserUserId",
                table: "Recipe_DietType");

            migrationBuilder.RenameTable(
                name: "Recipe_DietType",
                newName: "Recipes");

            migrationBuilder.RenameColumn(
                name: "AppUserIds",
                table: "Recipes",
                newName: "AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_AppUserId",
                table: "Recipes",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_DietTypes_Recipes_RecipeId",
                table: "Recipe_DietTypes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_TimesOfDay_Recipes_RecipeId",
                table: "Recipe_TimesOfDay",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_User_Likes_Recipes_RecipeId",
                table: "Recipe_User_Likes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_User_Matches_Recipes_RecipeId",
                table: "Recipe_User_Matches",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_AppUsers_AppUserId",
                table: "Recipes",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeSteps_Recipes_RecipeId",
                table: "RecipeSteps",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
