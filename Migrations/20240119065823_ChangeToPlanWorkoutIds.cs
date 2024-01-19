using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToPlanWorkoutIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0414525-426f-4a09-a0db-b7ee4c521710");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a070bb90-b213-4f78-98a1-d0c047636ea9");

            migrationBuilder.RenameColumn(
                name: "WorkoutIds",
                table: "PlanUserStatus",
                newName: "PlanWorkoutIds");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9db5f8c9-71a1-45ed-8ead-9d47e72fb685", "b0984cf0-cf7c-42f6-9776-4c080873c44f", "Administrator", "ADMINISTRATOR" },
                    { "c048b41e-3b86-4b07-9f04-bc9f0e8d7308", "a6bfdce2-52bb-4ba9-af5a-d50c1b1395ab", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9db5f8c9-71a1-45ed-8ead-9d47e72fb685");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c048b41e-3b86-4b07-9f04-bc9f0e8d7308");

            migrationBuilder.RenameColumn(
                name: "PlanWorkoutIds",
                table: "PlanUserStatus",
                newName: "WorkoutIds");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a0414525-426f-4a09-a0db-b7ee4c521710", "621a90c7-749d-4bcb-9e3f-6caf277c3735", "User", "USER" },
                    { "a070bb90-b213-4f78-98a1-d0c047636ea9", "b22d29fa-b590-4a84-ba01-d0df1b5c493b", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
