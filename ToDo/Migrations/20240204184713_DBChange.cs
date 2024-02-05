using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoDemo.Migrations
{
    /// <inheritdoc />
    public partial class DBChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 2,
                column: "Name",
                value: "Active");

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusID", "Name" },
                values: new object[] { 3, "Completed" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 2,
                column: "Name",
                value: "Completed");
        }
    }
}
