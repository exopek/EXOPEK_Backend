using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddProgressPercentageToPlanStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24262287-86aa-41d0-ab54-ce32a1ffadc9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61ec44ee-7add-4ad1-82e7-fc4d3e67197a");

            migrationBuilder.AddColumn<int>(
                name: "ProgressPercentage",
                table: "PlanUserStatus",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a0414525-426f-4a09-a0db-b7ee4c521710", "621a90c7-749d-4bcb-9e3f-6caf277c3735", "User", "USER" },
                    { "a070bb90-b213-4f78-98a1-d0c047636ea9", "b22d29fa-b590-4a84-ba01-d0df1b5c493b", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0414525-426f-4a09-a0db-b7ee4c521710");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a070bb90-b213-4f78-98a1-d0c047636ea9");

            migrationBuilder.DropColumn(
                name: "ProgressPercentage",
                table: "PlanUserStatus");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "24262287-86aa-41d0-ab54-ce32a1ffadc9", "5de61442-abed-464e-ad4f-ec83683f5204", "User", "USER" },
                    { "61ec44ee-7add-4ad1-82e7-fc4d3e67197a", "77b1b54e-6505-41af-ae08-4353de9bac5d", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
