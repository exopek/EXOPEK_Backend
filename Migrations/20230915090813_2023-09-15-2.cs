using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class _202309152 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1368b63f-9a1e-489b-803e-9dddca49c599");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "237b64f1-0ccd-486b-ae8c-c2c17e801847");

            migrationBuilder.CreateTable(
                name: "WorkoutUserLikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    IsLiked = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutUserLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutUserLikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutUserLikes_Workouts_WorkoutId",
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
                    { "82e66898-617f-435c-8d4e-80cc7564754c", "83f99081-4953-43f7-85e6-6fab5a687b72", "User", "USER" },
                    { "86c36f83-a02c-4f2c-849f-58d6fcc2ce9d", "9d4a9ddf-346e-4be7-95b8-340dbc1e1c2e", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutUserLikes_UserId",
                table: "WorkoutUserLikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutUserLikes_WorkoutId",
                table: "WorkoutUserLikes",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutUserLikes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82e66898-617f-435c-8d4e-80cc7564754c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86c36f83-a02c-4f2c-849f-58d6fcc2ce9d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1368b63f-9a1e-489b-803e-9dddca49c599", "1e60d535-2518-4228-aea1-b07a82a4e1c7", "Administrator", "ADMINISTRATOR" },
                    { "237b64f1-0ccd-486b-ae8c-c2c17e801847", "fdca2e3e-8737-4a75-9c62-c0734747edc8", "User", "USER" }
                });
        }
    }
}
