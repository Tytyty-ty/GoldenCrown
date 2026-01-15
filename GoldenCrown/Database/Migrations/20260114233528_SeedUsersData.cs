using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoldenCrown.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "login", "name", "password" },
                values: new object[,]
                {
                    { 1L, "Alex123", "Alex", "123123" },
                    { 2L, "Blober123", "Bulk", "123123" },
                    { 3L, "Civic123123", "Civilla", "123123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 3L);
        }
    }
}
