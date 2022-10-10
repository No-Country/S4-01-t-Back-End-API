using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S4_Back_End_API.Migrations
{
    public partial class CorrectedUserRelatedNavPropsInIntermediateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_User_Likes_AppUsers_UserId",
                table: "Recipe_User_Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_User_Matches_AppUsers_UserId",
                table: "Recipe_User_Matches");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Recipe_User_Matches",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipe_User_Matches_UserId",
                table: "Recipe_User_Matches",
                newName: "IX_Recipe_User_Matches_AppUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Recipe_User_Likes",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipe_User_Likes_UserId",
                table: "Recipe_User_Likes",
                newName: "IX_Recipe_User_Likes_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_User_Likes_AppUsers_AppUserId",
                table: "Recipe_User_Likes",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_User_Matches_AppUsers_AppUserId",
                table: "Recipe_User_Matches",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_User_Likes_AppUsers_AppUserId",
                table: "Recipe_User_Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_User_Matches_AppUsers_AppUserId",
                table: "Recipe_User_Matches");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Recipe_User_Matches",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipe_User_Matches_AppUserId",
                table: "Recipe_User_Matches",
                newName: "IX_Recipe_User_Matches_UserId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Recipe_User_Likes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipe_User_Likes_AppUserId",
                table: "Recipe_User_Likes",
                newName: "IX_Recipe_User_Likes_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_User_Likes_AppUsers_UserId",
                table: "Recipe_User_Likes",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_User_Matches_AppUsers_UserId",
                table: "Recipe_User_Matches",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
