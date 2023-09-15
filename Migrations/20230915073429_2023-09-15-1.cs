using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class _202309151 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutUserComments_AspNetUsers_UserId1",
                table: "WorkoutUserComments");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutUserComments_UserId1",
                table: "WorkoutUserComments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cba142e-ebae-4631-9be7-064a999c778a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "630a322e-c4f4-4a27-a685-904bea6e2e8d");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "WorkoutUserComments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WorkoutUserComments",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1368b63f-9a1e-489b-803e-9dddca49c599", "1e60d535-2518-4228-aea1-b07a82a4e1c7", "Administrator", "ADMINISTRATOR" },
                    { "237b64f1-0ccd-486b-ae8c-c2c17e801847", "fdca2e3e-8737-4a75-9c62-c0734747edc8", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutUserComments_UserId",
                table: "WorkoutUserComments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutUserComments_AspNetUsers_UserId",
                table: "WorkoutUserComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutUserComments_AspNetUsers_UserId",
                table: "WorkoutUserComments");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutUserComments_UserId",
                table: "WorkoutUserComments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1368b63f-9a1e-489b-803e-9dddca49c599");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "237b64f1-0ccd-486b-ae8c-c2c17e801847");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "WorkoutUserComments",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "WorkoutUserComments",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutUserComments_AspNetUsers_UserId1",
                table: "WorkoutUserComments",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
