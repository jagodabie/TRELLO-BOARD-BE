using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trello_board.Migrations
{
    /// <inheritdoc />
    public partial class initremovedlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TasksGroups_Users_UserId",
                table: "TasksGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Workspaces_Users_UserId",
                table: "Workspaces");

            migrationBuilder.DropIndex(
                name: "IX_Workspaces_UserId",
                table: "Workspaces");

            migrationBuilder.DropIndex(
                name: "IX_TasksGroups_UserId",
                table: "TasksGroups");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Workspaces");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TasksGroups");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Workspaces",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TasksGroups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workspaces_UserId",
                table: "Workspaces",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksGroups_UserId",
                table: "TasksGroups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TasksGroups_Users_UserId",
                table: "TasksGroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workspaces_Users_UserId",
                table: "Workspaces",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
