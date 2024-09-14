using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class SeedCompanyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Companies",
                newName: "name");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "city", "name", "phoneNumber", "postalCode", "state", "streetAddress" },
                values: new object[,]
                {
                    { 1, "pune", "JustBooks", "1234567890", null, "MH", "Paud Road, Pune" },
                    { 2, "pune", "Wild Reader", "9876543210", null, "GJ", "SB Road, Pune" },
                    { 3, "pune", "Reader's Club", "12234675768", null, "MP", "JM, Pune" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Companies",
                newName: "Name");
        }
    }
}
