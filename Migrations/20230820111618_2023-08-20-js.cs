using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class _20230820js : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03cd2142-821b-4c41-8700-376df2bb2456");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8336f84c-b927-4705-b1db-28dbc447f1af");

            migrationBuilder.RenameColumn(
                name: "previewImage",
                table: "Workouts",
                newName: "PreviewImageUrl");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Workouts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Workouts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "Workouts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Duration",
                table: "Workouts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Hashtags",
                table: "Workouts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MuscleImageUrl",
                table: "Workouts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Workouts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "WorkoutExercise",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reps",
                table: "WorkoutExercise",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StageOrder",
                table: "WorkoutExercise",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StageRound",
                table: "WorkoutExercise",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StageType",
                table: "WorkoutExercise",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Exercise",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Exercise",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "Exercise",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PreviewImageUrl",
                table: "Exercise",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68ba2a4b-f97a-48a8-8e5b-0b0253a5718d", "ca04fcec-6d2a-4810-81e3-c1c5eb954dce", "User", "USER" },
                    { "b378e8f9-529f-4863-b5b1-f574f66a203d", "bf6fe9d8-a9f1-41fa-aeb5-aeda11c8204c", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68ba2a4b-f97a-48a8-8e5b-0b0253a5718d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b378e8f9-529f-4863-b5b1-f574f66a203d");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Hashtags",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "MuscleImageUrl",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "WorkoutExercise");

            migrationBuilder.DropColumn(
                name: "Reps",
                table: "WorkoutExercise");

            migrationBuilder.DropColumn(
                name: "StageOrder",
                table: "WorkoutExercise");

            migrationBuilder.DropColumn(
                name: "StageRound",
                table: "WorkoutExercise");

            migrationBuilder.DropColumn(
                name: "StageType",
                table: "WorkoutExercise");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "PreviewImageUrl",
                table: "Exercise");

            migrationBuilder.RenameColumn(
                name: "PreviewImageUrl",
                table: "Workouts",
                newName: "previewImage");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03cd2142-821b-4c41-8700-376df2bb2456", "09a9df18-1a7d-43df-aeda-51329f8b749d", "Administrator", "ADMINISTRATOR" },
                    { "8336f84c-b927-4705-b1db-28dbc447f1af", "742f6fab-3660-4eeb-805c-05cbb42f24e2", "User", "USER" }
                });
        }
    }
}
