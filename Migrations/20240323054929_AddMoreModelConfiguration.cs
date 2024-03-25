using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreModelConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a99994b-1de1-43e2-b6d7-5ddbc653b062");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b0b5d4a-154a-4075-bad3-e28c1bf693dc");

            migrationBuilder.AlterColumn<string>(
                name: "Difficulty",
                table: "Workouts",
                type: "text",
                nullable: false,
                defaultValue: "None",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Workouts",
                type: "text",
                nullable: false,
                defaultValue: "None",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "StageType",
                table: "WorkoutExercise",
                type: "text",
                nullable: false,
                defaultValue: "Main",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Reps",
                table: "WorkoutExercise",
                type: "integer",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhaseType",
                table: "PlanWorkout",
                type: "text",
                nullable: false,
                defaultValue: "Phase1",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Target",
                table: "Plans",
                type: "text",
                nullable: false,
                defaultValue: "None",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Difficulty",
                table: "Plans",
                type: "text",
                nullable: false,
                defaultValue: "None",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Difficulty",
                table: "Exercises",
                type: "text",
                nullable: false,
                defaultValue: "None",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Exercises",
                type: "text",
                nullable: false,
                defaultValue: "None",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "SportType",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "None",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d7f67e9-90ee-40cc-9dce-89bd0cf06a95", null, "User", "USER" },
                    { "41c9c3b1-e49e-4b66-b562-fa61cf5a6a16", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d7f67e9-90ee-40cc-9dce-89bd0cf06a95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41c9c3b1-e49e-4b66-b562-fa61cf5a6a16");

            migrationBuilder.AlterColumn<int>(
                name: "Difficulty",
                table: "Workouts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "None");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Workouts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "None");

            migrationBuilder.AlterColumn<int>(
                name: "StageType",
                table: "WorkoutExercise",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "Main");

            migrationBuilder.AlterColumn<int>(
                name: "Reps",
                table: "WorkoutExercise",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PhaseType",
                table: "PlanWorkout",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "Phase1");

            migrationBuilder.AlterColumn<int>(
                name: "Target",
                table: "Plans",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "None");

            migrationBuilder.AlterColumn<int>(
                name: "Difficulty",
                table: "Plans",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "None");

            migrationBuilder.AlterColumn<int>(
                name: "Difficulty",
                table: "Exercises",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "None");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Exercises",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "None");

            migrationBuilder.AlterColumn<int>(
                name: "SportType",
                table: "AspNetUsers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "None");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a99994b-1de1-43e2-b6d7-5ddbc653b062", null, "User", "USER" },
                    { "2b0b5d4a-154a-4075-bad3-e28c1bf693dc", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
