using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S4_Back_End_API.Migrations
{
    public partial class ModifiedAppUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppUserRoles_UserRoleId",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_DifficultyLevels_DifficultyLevelId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Flavors_FlavorId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_DifficultyLevelId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_FlavorId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_UserRoleId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AppUsers");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "AppUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordResetToken",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "AppUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetTokenExpires",
                table: "AppUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerificationToken",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VerifiedAt",
                table: "AppUsers",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "PasswordResetToken",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "ResetTokenExpires",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "VerificationToken",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "VerifiedAt",
                table: "AppUsers");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AppUsers",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_DifficultyLevelId",
                table: "Recipes",
                column: "DifficultyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_FlavorId",
                table: "Recipes",
                column: "FlavorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_UserRoleId",
                table: "AppUsers",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppUserRoles_UserRoleId",
                table: "AppUsers",
                column: "UserRoleId",
                principalTable: "AppUserRoles",
                principalColumn: "UserRoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_DifficultyLevels_DifficultyLevelId",
                table: "Recipes",
                column: "DifficultyLevelId",
                principalTable: "DifficultyLevels",
                principalColumn: "DifficultyLevelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Flavors_FlavorId",
                table: "Recipes",
                column: "FlavorId",
                principalTable: "Flavors",
                principalColumn: "FlavorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
