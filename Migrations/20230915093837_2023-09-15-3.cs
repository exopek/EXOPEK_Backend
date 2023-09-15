using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class _202309153 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82e66898-617f-435c-8d4e-80cc7564754c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86c36f83-a02c-4f2c-849f-58d6fcc2ce9d");

            migrationBuilder.CreateTable(
                name: "WorkoutUserCompletes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutUserCompletes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutUserCompletes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutUserCompletes_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b97f80e-c096-4368-93b7-6ce3f68030e4", "5c7d4e4e-059b-4ed2-9d27-a9d4e6acf512", "User", "USER" },
                    { "b2c9cae7-5948-4d89-a21e-8421595d8065", "703a76c8-5087-4826-baf5-fe91a255ba61", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutUserCompletes_UserId",
                table: "WorkoutUserCompletes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutUserCompletes_WorkoutId",
                table: "WorkoutUserCompletes",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutUserCompletes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b97f80e-c096-4368-93b7-6ce3f68030e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2c9cae7-5948-4d89-a21e-8421595d8065");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "82e66898-617f-435c-8d4e-80cc7564754c", "83f99081-4953-43f7-85e6-6fab5a687b72", "User", "USER" },
                    { "86c36f83-a02c-4f2c-849f-58d6fcc2ce9d", "9d4a9ddf-346e-4be7-95b8-340dbc1e1c2e", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
