using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class _20231023js : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09432400-db8d-4923-9cda-47f5f2cdfd93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a870a30-f3d5-44f9-9e7a-68d2a9a12847");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "PlanWorkout");

            migrationBuilder.AddColumn<string>(
                name: "WorkoutIds",
                table: "PlanUserStatus",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f229b72-05a3-4571-8242-5bffbe20ff58", "31f429f1-ac60-4e6d-83a3-f539bc87feff", "Administrator", "ADMINISTRATOR" },
                    { "a1ab4215-3553-4b63-b8c8-9e31fc9c3739", "2d010015-0cca-4307-991d-e35abc76fc8a", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f229b72-05a3-4571-8242-5bffbe20ff58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1ab4215-3553-4b63-b8c8-9e31fc9c3739");

            migrationBuilder.DropColumn(
                name: "WorkoutIds",
                table: "PlanUserStatus");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "PlanWorkout",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09432400-db8d-4923-9cda-47f5f2cdfd93", "e38bfbb1-5b56-43c6-bb1d-7d3dcec44ddf", "Administrator", "ADMINISTRATOR" },
                    { "3a870a30-f3d5-44f9-9e7a-68d2a9a12847", "1d218900-ff90-4f0e-8b5b-87757372b240", "User", "USER" }
                });
        }
    }
}
