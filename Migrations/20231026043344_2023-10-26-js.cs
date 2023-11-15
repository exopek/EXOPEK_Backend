using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class _20231026js : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f229b72-05a3-4571-8242-5bffbe20ff58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1ab4215-3553-4b63-b8c8-9e31fc9c3739");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PlanUserStatus",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PlanUserStatus",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhaseNames",
                table: "Plans",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57e4aca9-6087-4c73-b322-bee70fdf4d61", "7a2d9d9c-5974-4cb8-a11e-99d9b3e25747", "User", "USER" },
                    { "8ac1b9ba-1dc3-43af-8a68-1d4eebb3c80a", "795747c1-d4e7-4ab7-88ec-40cf7fba9736", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57e4aca9-6087-4c73-b322-bee70fdf4d61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ac1b9ba-1dc3-43af-8a68-1d4eebb3c80a");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PlanUserStatus");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PlanUserStatus");

            migrationBuilder.DropColumn(
                name: "PhaseNames",
                table: "Plans");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f229b72-05a3-4571-8242-5bffbe20ff58", "31f429f1-ac60-4e6d-83a3-f539bc87feff", "Administrator", "ADMINISTRATOR" },
                    { "a1ab4215-3553-4b63-b8c8-9e31fc9c3739", "2d010015-0cca-4307-991d-e35abc76fc8a", "User", "USER" }
                });
        }
    }
}
