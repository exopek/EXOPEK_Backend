using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class _20231115js : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57e4aca9-6087-4c73-b322-bee70fdf4d61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ac1b9ba-1dc3-43af-8a68-1d4eebb3c80a");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "24262287-86aa-41d0-ab54-ce32a1ffadc9", "5de61442-abed-464e-ad4f-ec83683f5204", "User", "USER" },
                    { "61ec44ee-7add-4ad1-82e7-fc4d3e67197a", "77b1b54e-6505-41af-ae08-4353de9bac5d", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24262287-86aa-41d0-ab54-ce32a1ffadc9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61ec44ee-7add-4ad1-82e7-fc4d3e67197a");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57e4aca9-6087-4c73-b322-bee70fdf4d61", "7a2d9d9c-5974-4cb8-a11e-99d9b3e25747", "User", "USER" },
                    { "8ac1b9ba-1dc3-43af-8a68-1d4eebb3c80a", "795747c1-d4e7-4ab7-88ec-40cf7fba9736", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
