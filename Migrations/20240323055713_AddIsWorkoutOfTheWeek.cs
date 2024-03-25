using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddIsWorkoutOfTheWeek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d7f67e9-90ee-40cc-9dce-89bd0cf06a95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41c9c3b1-e49e-4b66-b562-fa61cf5a6a16");

            migrationBuilder.AddColumn<bool>(
                name: "IsWorkoutOfTheWeek",
                table: "Workouts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "216919dd-3a81-4c24-ae7b-f15cc9b2dd6c", null, "User", "USER" },
                    { "88288dd1-b0a3-497b-b258-988fc5d064ea", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "216919dd-3a81-4c24-ae7b-f15cc9b2dd6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88288dd1-b0a3-497b-b258-988fc5d064ea");

            migrationBuilder.DropColumn(
                name: "IsWorkoutOfTheWeek",
                table: "Workouts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d7f67e9-90ee-40cc-9dce-89bd0cf06a95", null, "User", "USER" },
                    { "41c9c3b1-e49e-4b66-b562-fa61cf5a6a16", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
