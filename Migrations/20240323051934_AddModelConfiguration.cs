using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddModelConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercise_Exercise_ExerciseId",
                table: "WorkoutExercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "537da145-63ca-4758-a4d0-05ae61937fee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d3c9580-acde-4bc5-9ff8-d4f20a222242");

            migrationBuilder.RenameTable(
                name: "Exercise",
                newName: "Exercises");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PlanUserStatus",
                type: "text",
                nullable: false,
                defaultValue: "Inactive",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentPhase",
                table: "PlanUserStatus",
                type: "text",
                nullable: false,
                defaultValue: "Phase1",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a99994b-1de1-43e2-b6d7-5ddbc653b062", null, "User", "USER" },
                    { "2b0b5d4a-154a-4075-bad3-e28c1bf693dc", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercise_Exercises_ExerciseId",
                table: "WorkoutExercise",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercise_Exercises_ExerciseId",
                table: "WorkoutExercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a99994b-1de1-43e2-b6d7-5ddbc653b062");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b0b5d4a-154a-4075-bad3-e28c1bf693dc");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Exercise");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "PlanUserStatus",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "Inactive");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentPhase",
                table: "PlanUserStatus",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "Phase1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "537da145-63ca-4758-a4d0-05ae61937fee", null, "Administrator", "ADMINISTRATOR" },
                    { "6d3c9580-acde-4bc5-9ff8-d4f20a222242", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercise_Exercise_ExerciseId",
                table: "WorkoutExercise",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
