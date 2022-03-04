using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManage.Migrations
{
    public partial class KeyModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_AspNetUsers_AssignedUserId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_AssignedUserId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_AssignedUserId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_AssignedUserId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "AssignedUserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AssignedUserId",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_JobId",
                table: "AspNetUsers",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProjectId",
                table: "AspNetUsers",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Jobs_JobId",
                table: "AspNetUsers",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Projects_ProjectId",
                table: "AspNetUsers",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Jobs_JobId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Projects_ProjectId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_JobId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProjectId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AssignedUserId",
                table: "Projects",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AssignedUserId",
                table: "Jobs",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AssignedUserId",
                table: "Projects",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_AssignedUserId",
                table: "Jobs",
                column: "AssignedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_AspNetUsers_AssignedUserId",
                table: "Jobs",
                column: "AssignedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_AssignedUserId",
                table: "Projects",
                column: "AssignedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
