using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Trello_board.Migrations
{
    /// <inheritdoc />
    public partial class AddiotionSeedDataUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "TaskId", "TasksGroupId", "UserId", "WorkspaceId" },
                values: new object[,]
                {
                    { 1, "jagoda.bieniek1234@gmail.com", "Jagoda Bieniek", null, null, null, null },
                    { 2, "jan@gmail.com", "John Doe", null, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
