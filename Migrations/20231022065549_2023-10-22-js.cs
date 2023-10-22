using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class _20231022js : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "424f26d9-c65a-462f-a2ca-4eaf9d69e415");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0972fb5-37b9-45e7-8fa6-8bbc17f2db71");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "PlanWorkout",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "PlanWorkout",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09432400-db8d-4923-9cda-47f5f2cdfd93", "e38bfbb1-5b56-43c6-bb1d-7d3dcec44ddf", "Administrator", "ADMINISTRATOR" },
                    { "3a870a30-f3d5-44f9-9e7a-68d2a9a12847", "1d218900-ff90-4f0e-8b5b-87757372b240", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Order",
                table: "PlanWorkout");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "424f26d9-c65a-462f-a2ca-4eaf9d69e415", "261dfded-9e6c-4aa2-907b-4cf3cf7c9036", "User", "USER" },
                    { "b0972fb5-37b9-45e7-8fa6-8bbc17f2db71", "61a5c606-5d67-4b94-94b4-81ef2c5bf900", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
