using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S4_Back_End_API.Migrations
{
    public partial class ModifiedAppUsserRoleFKinAppUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppUserRoles_AppUserRoleUserRoleId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_AppUserRoleUserRoleId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "AppUserRoleUserRoleId",
                table: "AppUsers");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppUserRoles_UserRoleId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_UserRoleId",
                table: "AppUsers");

            migrationBuilder.AddColumn<int>(
                name: "AppUserRoleUserRoleId",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_AppUserRoleUserRoleId",
                table: "AppUsers",
                column: "AppUserRoleUserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppUserRoles_AppUserRoleUserRoleId",
                table: "AppUsers",
                column: "AppUserRoleUserRoleId",
                principalTable: "AppUserRoles",
                principalColumn: "UserRoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
