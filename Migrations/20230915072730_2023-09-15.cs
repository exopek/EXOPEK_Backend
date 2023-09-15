using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class _20230915 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68ba2a4b-f97a-48a8-8e5b-0b0253a5718d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b378e8f9-529f-4863-b5b1-f574f66a203d");

            migrationBuilder.AddColumn<int>(
                name: "Comments",
                table: "Workouts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Workouts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorkoutUserComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId1 = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutUserComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutUserComments_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutUserComments_Workouts_WorkoutId",
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
                    { "2cba142e-ebae-4631-9be7-064a999c778a", "68d2b4d6-36a2-4586-adce-dcdd4f2ebed2", "User", "USER" },
                    { "630a322e-c4f4-4a27-a685-904bea6e2e8d", "4d9c4049-23fa-45fa-b1fb-f9b024917add", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutUserComments_UserId1",
                table: "WorkoutUserComments",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutUserComments_WorkoutId",
                table: "WorkoutUserComments",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutUserComments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cba142e-ebae-4631-9be7-064a999c778a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "630a322e-c4f4-4a27-a685-904bea6e2e8d");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Workouts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68ba2a4b-f97a-48a8-8e5b-0b0253a5718d", "ca04fcec-6d2a-4810-81e3-c1c5eb954dce", "User", "USER" },
                    { "b378e8f9-529f-4863-b5b1-f574f66a203d", "bf6fe9d8-a9f1-41fa-aeb5-aeda11c8204c", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
