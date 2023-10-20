using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class _20231020js : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cacdbdb-fd69-46fa-9683-69be99589487");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f721173-9dfa-4264-b1db-8c3326f01e7b");

            migrationBuilder.CreateTable(
                name: "PlanUserStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CurrentPhase = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanUserStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanUserStatus_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanUserStatus_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "424f26d9-c65a-462f-a2ca-4eaf9d69e415", "261dfded-9e6c-4aa2-907b-4cf3cf7c9036", "User", "USER" },
                    { "b0972fb5-37b9-45e7-8fa6-8bbc17f2db71", "61a5c606-5d67-4b94-94b4-81ef2c5bf900", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanUserStatus_PlanId",
                table: "PlanUserStatus",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanUserStatus_UserId",
                table: "PlanUserStatus",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanUserStatus");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "424f26d9-c65a-462f-a2ca-4eaf9d69e415");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0972fb5-37b9-45e7-8fa6-8bbc17f2db71");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3cacdbdb-fd69-46fa-9683-69be99589487", "9db714ab-7a8f-4d0b-9439-7f9a005d2235", "User", "USER" },
                    { "3f721173-9dfa-4264-b1db-8c3326f01e7b", "59d84c1e-5b48-46ec-8ac0-44e723fcf816", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
