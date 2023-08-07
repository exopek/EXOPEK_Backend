using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class _20230804js1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Workouts_WorkoutId",
                table: "Image");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkoutId",
                table: "Image",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Workouts_WorkoutId",
                table: "Image",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Workouts_WorkoutId",
                table: "Image");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkoutId",
                table: "Image",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Workouts_WorkoutId",
                table: "Image",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
